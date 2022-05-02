#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GutenDexAPI.Models;

namespace GutenDexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly GutenDexAPIDBContext _context;

        public BookController(GutenDexAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Book
        [HttpGet]
        public async Task<ActionResult<BookResponse>> GetBooks()
        {
            var response = new BookResponse();
            var book = await _context.Books.ToListAsync();

            if (book.Count == 0)
            {
                response.statusCode = 400;
                response.statusDescription = "Process Failed!!! Empty Database. How Will You Gain Approximate Knowledge of Many Things?";
                
            }
            else
            {
                response.statusCode = 200;
                response.statusDescription = "Success!!! Enjoy Your Books. You And I Both Know You're Just Browsing My Shelves To Look Smart";
                response.book = book;
            }

            return response;
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponse>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            var response = new BookResponse();
            response.statusCode = 400;
            response.statusDescription = "Process Failed. Book Does Not Exist";

            if (book != null)
            {
                response.statusCode = 200;
                response.statusDescription = "Success. Loading Requested Book";
                response.book.Add(book);
            }

            return response;
        }

        // PUT: api/Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookResponse>> PostBook(Book book)
        {
            var response = new BookResponse();

            var result = _context.Books.Add(book);

            await _context.SaveChangesAsync();

            response.statusCode = 400;
            response.statusDescription = "Process Failed. Please Check Book Values";

            if(result != null)
            {
                response.statusCode = 200;
                response.statusDescription = "Success. New Book Added";
                response.book.Add(book);
            }

            return response;
        }

        /*
        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.BookId }, book);
        }
        */

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookResponse>> DeleteBook(int id)
        {
            var response = new BookResponse();

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Process Failed. Book Does Not Exist.";
            }
            else
            {
                response.statusCode = 200;
                response.statusDescription = "Success. Book Removed";
                _context.Books.Remove(book);
                //response.book.Remove(book);
            }
            
            await _context.SaveChangesAsync();

            return response;
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
