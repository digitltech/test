using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Core
{
    public interface IUserServices
    {
        List<User> GetUsers();
        User GetUser(string id);
        User Create (User user);
    }
}
