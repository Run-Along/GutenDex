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
    public class AuthorController : ControllerBase
    {
        private readonly GutenDexAPIDBContext _context;

        public AuthorController(GutenDexAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Author
        [HttpGet]
        public async Task<ActionResult<AuthorResponse>> GetAuthors()
        {
            var author = await _context.Authors.Include(a => a.Books).ToListAsync();
            var response = new AuthorResponse();

            if(author.Count == 0)
            {
                response.statusCode = 400;
                response.statusDescription = "Celebrate!!! Process Failed!!! Cannot Load List of Authors Forced Upon You In High School. Empty Database";
            }
            else
            {
                response.statusCode = 200;
                response.statusDescription = "Nooooooo!!! Success!!! loading List Of Authors Forced Upon You in High School";
                response.author = author;
            }
            return response;
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorResponse>> GetAuthor(int id)
        {
            var author = await _context.Authors.Include(a => a.Books).SingleOrDefaultAsync(a => a.AuthorId == id);
            var response = new AuthorResponse();
            response.statusCode = 400;
            response.statusDescription = "Process Failed. Author Does Not Exist.";

            // maybe I should use .count - 1;
            if (author != null)
            {
                response.statusCode = 200;
                response.statusDescription = "Success. Loading Requested Author.";
                response.author.Add(author);
            }

            return response;
        }

        // PUT: api/Author/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.AuthorId)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        // POST: api/Author
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuthorResponse>> PostAuthor(Author author)
        {
            var response = new AuthorResponse();

            var result  = _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            response.statusCode = 400;
            response.statusDescription = "Process Failed. Please Check Author Values.";

            if (result != null)
            {
                response.statusCode = 200;
                response.statusDescription = "Success. New Author Added.";
                response.author.Add(author);
            }    
            

            return response;
        }


        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorResponse>> DeleteAuthor(int id)
        {
            var author = await _context.Authors.Include(a => a.Books).SingleOrDefaultAsync(a => a.AuthorId == id);
            var response = new AuthorResponse();

            if (!AuthorExists(id))
            {
                response.statusCode = 400;
                response.statusDescription = "Process Failed. Author Does Not Exist.";
            }
            else
            {
                response.statusCode = 200;
                response.statusDescription = "Success. Author Removed";
                _context.Authors.Remove(author);
                //response.author.Remove(author);
            }
            await _context.SaveChangesAsync();
            return response;
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.AuthorId == id);
        }
    }
}
