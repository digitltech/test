using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Core
{
  public   interface IDBClient
    {
        IMongoCollection<Book> GetBooksCollection();
        IMongoCollection<User> GetUsersCollection();
    }
}
