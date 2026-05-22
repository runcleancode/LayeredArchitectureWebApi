using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Repositories.EFCore;




namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        //Dependency Injection
        private readonly RepositoryContext _context;

        public BooksController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _context.Books.ToList();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var book = _context
          .Books
          .Find(id);

                if (book is null)
                    return NotFound();

                return Ok(book);
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();

                _context.Add(book);
                _context.SaveChanges();
                return StatusCode(201, book);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            try
            {
                var entity = _context
     .Books
     .Where(b => b.Id.Equals(id))
     .SingleOrDefault();

                if (entity is null)
                    return NotFound();

                if (id != book.Id)
                    return BadRequest();

                entity.Title = book.Title;
                entity.Price = book.Price;

                _context.SaveChanges();

                return Ok(book);

            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = _context
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();

                if (entity is null)
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = $"Book with id {id} was not found"
                    });

                _context.Books.Remove(entity);
                _context.SaveChanges();

                return NoContent();

            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            try
            {
                var entity = _context
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();

                if (entity is null)
                    return NotFound();

                bookPatch.ApplyTo(entity);
                _context.SaveChanges();

                return NoContent();
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}