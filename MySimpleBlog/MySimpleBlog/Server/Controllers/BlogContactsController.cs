using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySimpleBlog.Shared.Core.Data;
using MySimpleBlog.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySimpleBlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogContactsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BlogContactsController(ApplicationContext context) {
            _context = context;
        }
        // Getting all blog contacts
        [HttpGet]
        public async  Task<ActionResult<IEnumerable<BlogContact>>> GetBlogContacts()
        {
            if(_context.BlogContacts == null)
            {
                return NotFound();
            }

            var contacts = await _context.BlogContacts.ToListAsync();
            return contacts;
        }

        // Getting single blog contact with an ID
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogContact>> Get(int id)
        {
            if (_context.BlogContacts == null)
            {
                return NotFound();
            }

            var contacts = await _context.BlogContacts.FindAsync(id);

            if (contacts == null)
            {
                NotFound();
            }

            return contacts;
        }

        // Saving blog contact from the form to the Database
        [HttpPost]
        public async Task<ActionResult<BlogContact>> Post(BlogContact blogContact)
        {
            if(_context.BlogContacts == null)
            {
                return Problem("An error occurred, could not find destination table");

            }

            _context.BlogContacts.Add(blogContact);

            try
            {
                await _context.SaveChangesAsync(new CancellationToken());
            }
            catch (DbUpdateException)
            {
                
            }

            return Ok();
        }

        
    }
}
