using bookDemo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using bookDemo.Models;

namespace bookDemo.Controller
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllBook()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var book = ApplicationContext
                .Books
                .Where(x => x.Id.Equals(id))
                .SingleOrDefault();
            if (book is null) {
                return NotFound();
            }
            return Ok(book);

        }


        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();
                ApplicationContext.Books.Add(book);
                return StatusCode(201, book);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public IActionResult UptadeOneBook([FromRoute(Name = "id")] int id,
           [FromBody] Book book) {
            var entitiy = ApplicationContext
                 .Books
                 .Find(b => b.Id.Equals(id));

            if (entitiy is null) return NotFound();

            if (id != book.Id) return BadRequest();

            ApplicationContext.Books.Remove(entitiy);
            book.Id = entitiy.Id;
            ApplicationContext.Books.Add(book);
            return Ok(book);
        }

        [HttpDelete]
        public  IActionResult DeleteAllBooks()
        {
            ApplicationContext.Books.Clear();
            return NoContent();
        }


        [HttpDelete("{id.int}")]
        public IActionResult DeleteOneBook(int id) { 
            var entitiy =ApplicationContext
                .Books
                .Find(B=>B.Id.Equals(id));

            if(entitiy is null) return NotFound(new
            {
                statusCode=404,
                message=$"book with id:{id} could not found."
            });
            ApplicationContext.Books.Remove(entitiy);
            return NoContent();

        }

        
    }
}
