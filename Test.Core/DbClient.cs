using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Test.Core
{
    public class DbClient : IDBClient
    {
        private readonly IMongoCollection<Book> _books;
        private readonly IMongoCollection<User> _users;
        public DbClient(IOptions<TestDbConfig> testdbConfig)
        {
            var client = new MongoClient(testdbConfig.Value.CONNECTION_STRING);
            var db = client.GetDatabase(testdbConfig.Value.DATABASE_Name);
            _books = db.GetCollection<Book>(testdbConfig.Value.BOOKS_Collection_Name);
            _users = db.GetCollection<User>(testdbConfig.Value.USERS_Collection_Name);

        }
        public IMongoCollection<Book> GetBooksCollection() => _books;
        public IMongoCollection<User> GetUsersCollection() => _users;
    }
}
