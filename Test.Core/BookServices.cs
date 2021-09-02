using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Test.Core
{
    public class BookServices : IBookServices
    {
        private readonly IMongoCollection<Book> _books;
        public BookServices(IDBClient dBClient)
        {
           _books= dBClient.GetBooksCollection();
        }

        public void DelBook(string id)
        {
            _books.DeleteOne(book => book.Id == id);
        }

        public Book GetBook(string id) => _books.Find(book => book.Id == id).First();
      

        public List<Book> GetBooks()=> _books.Find(book => true).ToList();

        public Book NewBook(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public Book UpdBook(Book book)
        {
            GetBook(book.Id);
            _books.ReplaceOne(b => b.Id == book.Id, book);
            return book;
        }
    }
}
