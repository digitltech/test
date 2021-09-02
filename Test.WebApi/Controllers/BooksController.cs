using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Core;

namespace Test.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices _bookServices;
        public BooksController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_bookServices.GetBooks());
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(string id) 
        {
            return Ok(_bookServices.GetBook(id));
        }

        [HttpPost]
        public IActionResult NewBook (Book book)
        {
            _bookServices.NewBook(book);
            return CreatedAtRoute("GetBook", new { id = book.Id},book);
        }

        [HttpDelete("{id}")]
        public IActionResult DelBook (string id)
        {
            _bookServices.DelBook(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdBook (Book book)
        {
            return Ok(_bookServices.UpdBook(book));
        }
    }
}
