using Microsoft.AspNetCore.Http.HttpResults;

namespace Clients
{
    public interface IClientService
    {
        Results<Ok<Client>, NotFound> GetClient(string id);
        Results<NoContent, NotFound> DeleteClient(string id);
        Results<Ok<Client>, NotFound> UpdateClient(Client Client, string id);
        IResult CreateClient(Client Client);
        IResult GetClients();
    }

    public class DBClientService : IClientService
    {
        public IResult CreateClient(Client Client)
        {
            using var db = new ClientContext();
            db.Add(Client);
            db.SaveChanges();
            return TypedResults.Created("/Clients/{id}", Client);
        }

        public Results<NoContent, NotFound> DeleteClient(string id)
        {
            using var db = new ClientContext();
            var dbClient = db.Clients.SingleOrDefault(dbClient => dbClient.Id == id);

            if (dbClient is null)
                return TypedResults.NotFound();

            db.Remove(dbClient);
            db.SaveChanges();
            return TypedResults.NoContent();
        }

        public Results<Ok<Client>, NotFound> GetClient(string id)
        {
            using var db = new ClientContext();
            var dbClient = db.Clients.SingleOrDefault(dbClient => dbClient.Id == id);
            return dbClient is null ? TypedResults.NotFound() : TypedResults.Ok(dbClient);
        }

        public IResult GetClients()
        {
            using var db = new ClientContext();
            return TypedResults.Ok(db.Clients);
        }

        public Results<Ok<Client>, NotFound> UpdateClient(Client Client, string id)
        {
            using var db = new ClientContext();
            var dbClient = db.Clients.SingleOrDefault(dbClient => dbClient.Id == id);

            if (dbClient is null)
                return TypedResults.NotFound();

            dbClient.Name = Client.Name;
            dbClient.Email = Client.Email;
            dbClient.Password = Client.Password;
            dbClient.UpdatedAt = DateTime.Now;

            db.SaveChanges();
            return TypedResults.Ok(dbClient);
        }
    }
}
