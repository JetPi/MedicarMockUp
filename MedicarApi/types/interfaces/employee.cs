using Microsoft.AspNetCore.Http.HttpResults;

namespace Employees
{
    public interface IEmployeeService
    {
        Results<Ok<Employee>, NotFound> GetEmployee(string id);
        Results<NoContent, NotFound> DeleteEmployee(string id);
        Results<Ok<Employee>, NotFound> UpdateEmployee(Employee Employee, string id);
        IResult CreateEmployee(Employee Employee);
        IResult GetEmployees();
    }

    public class DBEmployeeService : IEmployeeService
    {
        public IResult CreateEmployee(Employee Employee)
        {
            using var db = new EmployeeContext();
            db.Add(Employee);
            db.SaveChanges();
            return TypedResults.Created("/Employees/{id}", Employee);
        }

        public Results<NoContent, NotFound> DeleteEmployee(string id)
        {
            using var db = new EmployeeContext();
            var dbEmployee = db.Employees.SingleOrDefault(dbEmployee => dbEmployee.Id == id);

            if (dbEmployee is null)
                return TypedResults.NotFound();

            db.Remove(dbEmployee);
            db.SaveChanges();
            return TypedResults.NoContent();
        }

        public Results<Ok<Employee>, NotFound> GetEmployee(string id)
        {
            using var db = new EmployeeContext();
            var dbEmployee = db.Employees.SingleOrDefault(dbEmployee => dbEmployee.Id == id);
            return dbEmployee is null ? TypedResults.NotFound() : TypedResults.Ok(dbEmployee);
        }

        public IResult GetEmployees()
        {
            using var db = new EmployeeContext();
            return TypedResults.Ok(db.Employees);
        }

        public Results<Ok<Employee>, NotFound> UpdateEmployee(Employee Employee, string id)
        {
            using var db = new EmployeeContext();
            var dbEmployee = db.Employees.SingleOrDefault(dbEmployee => dbEmployee.Id == id);

            if (dbEmployee is null)
                return TypedResults.NotFound();

            dbEmployee.Name = Employee.Name;
            dbEmployee.Email = Employee.Email;
            dbEmployee.Password = Employee.Password;
            dbEmployee.UpdatedAt = DateTime.Now;

            db.SaveChanges();
            return TypedResults.Ok(dbEmployee);
        }
    }
}
