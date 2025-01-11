using Microsoft.AspNetCore.Http.HttpResults;

namespace Users
{
    public interface IUserService
    {
        Results<Ok<User>, NotFound> GetUser(int id);
        Results<NoContent, NotFound> DeleteUser(int id);
        Results<Ok<User>, NotFound> UpdateUser(User user, int id);
        IResult CreateUser(User user);
        IResult GetUsers();
    }
}
