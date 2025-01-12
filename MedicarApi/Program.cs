using Clients;
using Employees;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IEmployeeService>(new DBEmployeeService());
builder.Services.AddSingleton<IClientService>(new DBClientService());

var app = builder.Build();

app.MapPost(
    "/employees",
    (Employee Employee, IEmployeeService service) =>
    {
        return service.CreateEmployee(Employee);
    }
);

app.MapGet(
    "/employees",
    (IEmployeeService service) =>
    {
        return service.GetEmployees();
    }
);

app.MapGet(
    "/employees/{id}",
    (string id, IEmployeeService service) =>
    {
        return service.GetEmployee(id);
    }
);

app.MapPut(
    "/employees/{id}",
    (string id, IEmployeeService service) =>
    {
        return service.GetEmployee(id);
    }
);

app.Run();
