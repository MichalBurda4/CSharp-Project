using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PZ2_PROJECT.Data;
using PZ2_PROJECT.Models;

namespace PZ2_PROJECT.Controllers
{
    public class OpinionController : Controller
    {
        private readonly AppDbContext _context;

        public OpinionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Opinion
        public async Task<IActionResult> Index()
        {
            var opinions = _context.Opinion.Include(o => o.Movie).Include(o => o.User);
            return View(await opinions.ToListAsync());
        }

        // GET: Opinion/Details/5
        public async Task<IActionResult> Details(string movieId, string userId)
        {
            if (movieId == null || userId == null)
            {
                return NotFound();
            }

            var opinion = await _context.Opinion
                .Include(o => o.Movie)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.MovieID == movieId && m.UserID == userId);
            if (opinion == null)
            {
                return NotFound();
            }

            return View(opinion);
        }

        // GET: Opinion/Create
        public IActionResult Create()
        {
            ViewData["MovieID"] = new SelectList(_context.Movie, "MovieID", "Name");
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "Login");
            return View();
        }

        // POST: Opinion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieID,UserID,Login,Name,Category,ReviewText,Rating")] Opinion opinion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opinion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieID"] = new SelectList(_context.Movie, "MovieID", "Name", opinion.MovieID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "Login", opinion.UserID);
            return View(opinion);
        }

        // GET: Opinion/Edit/5
        public async Task<IActionResult> Edit(string movieId, string userId)
        {
            if (movieId == null || userId == null)
            {
                return NotFound();
            }

            var opinion = await _context.Opinion.FindAsync(movieId, userId);
            if (opinion == null)
            {
                return NotFound();
            }
            ViewData["MovieID"] = new SelectList(_context.Movie, "MovieID", "Name", opinion.MovieID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "Login", opinion.UserID);
            return View(opinion);
        }

        // POST: Opinion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string movieId, string userId, [Bind("MovieID,UserID,Login,Name,Category,ReviewText,Rating")] Opinion opinion)
        {
            if (movieId != opinion.MovieID || userId != opinion.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opinion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpinionExists(opinion.MovieID, opinion.UserID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieID"] = new SelectList(_context.Movie, "MovieID", "Name", opinion.MovieID);
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "Login", opinion.UserID);
            return View(opinion);
        }

        // GET: Opinion/Delete/5
        public async Task<IActionResult> Delete(string movieId, string userId)
        {
            if (movieId == null || userId == null)
            {
                return NotFound();
            }

            var opinion = await _context.Opinion
                .Include(o => o.Movie)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.MovieID == movieId && m.UserID == userId);
            if (opinion == null)
            {
                return NotFound();
            }

            return View(opinion);
        }

        // POST: Opinion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string movieId, string userId)
        {
            var opinion = await _context.Opinion.FindAsync(movieId, userId);
            _context.Opinion.Remove(opinion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpinionExists(string movieId, string userId)
        {
            return _context.Opinion.Any(e => e.MovieID == movieId && e.UserID == userId);
        }
    }
}
