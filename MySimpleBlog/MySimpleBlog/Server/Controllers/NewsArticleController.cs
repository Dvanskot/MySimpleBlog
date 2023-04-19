using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySimpleBlog.Shared.Core.Data;
using MySimpleBlog.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySimpleBlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsArticleController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public NewsArticleController(ApplicationContext context)
        {
            _context = context;
        }

        // Getting all Articles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsArticle>>> GetNewsArticles()
        {
            if (_context.NewsArticles == null)
            {
                return NotFound();
            }

            var articles = await _context.NewsArticles.OrderByDescending(e=> e.DateCreated).ToListAsync();
            return articles;
        }

        // Getting Article with an ID
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsArticle>> GetNewsArticle(int id)
        {
            if (_context.NewsArticles == null)
            {
                return NotFound();
            }

            var article = await _context.NewsArticles.FindAsync(id);

            if (article == null)
            {
                NotFound();
            }

            return article;
        }

        // Saving blog contact from the form to the Database
        [HttpPost]
        public async Task<ActionResult<NewsArticle>> Post(NewsArticle newsArticle)
        {
            if (_context.NewsArticles == null)
            {
                return Problem("An error occurred, could not find destination table");

            }

            _context.NewsArticles.Add(newsArticle);

            try
            {
                await _context.SaveChangesAsync(new CancellationToken());
            }
            catch (DbUpdateException)
            {

            }

            return Ok();
        }

        // Updating an Article
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, NewsArticle newsArticle)
        {
            if (_context.NewsArticles == null)
            {
                return Problem("Entity set 'NewsArticle'  is null.");
            }
            _context.NewsArticles.Add(newsArticle);
            await _context.SaveChangesAsync(new CancellationToken());

            return CreatedAtAction("GetNewsArticle", new { id = newsArticle.Id }, newsArticle);
        }

        // Deleting an article
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.NewsArticles == null)
            {
                return Problem("Entity set 'NewsArticle'  is null.");
            }

            var article = await _context.NewsArticles.FindAsync(id);

            article.Deleted = DateTimeOffset.Now;

            _context.NewsArticles.Add(article);
            await _context.SaveChangesAsync(new CancellationToken());

            return CreatedAtAction("GetNewsArticle", new { id = article.Id }, article);
        }
    }
}
