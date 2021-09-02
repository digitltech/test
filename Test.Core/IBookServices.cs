using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Core
{
     public interface IBookServices
    {
       
        List<Book> GetBooks();
        Book GetBook(string id);
        Book NewBook(Book book);
        void DelBook (string id);

        Book UpdBook(Book book);

      
    }
}
