#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using moment3_2.Data;
using moment3_2.Models;

namespace moment3_2.Controllers
{
    public class CdsController : Controller
    {
        private readonly CollectionContext _context;

        public CdsController(CollectionContext context)
        {
            _context = context;
        }

        // GET: Cds
        public async Task<IActionResult> Index()
        {
            var collectionContext = _context.Cd.Include(c => c.Artist).Include(c => c.User);
            return View(await collectionContext.ToListAsync());
        }


        //sida för att söka
        public async Task<IActionResult> Search(string searchString)
        {
            var album = from m in _context.Cd select m;
            //Lambda expression
            if (!String.IsNullOrEmpty(searchString))
            {
                album = album.Where(s => s.Album_Name!.Contains(searchString));
            }
            return View(await album.ToListAsync());
        }
        [HttpPost]
        public string Search(string SearchString, bool notUsed)
        {
            return "From[HttpPost]Serach: filter on " + SearchString;
        }


        // GET: Cds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cd = await _context.Cd
                .Include(c => c.Artist)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CdId == id);
            if (cd == null)
            {
                return NotFound();
            }

            return View(cd);
        }

        // GET: Cds/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistName");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserName");
            return View();
        }

        // POST: Cds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CdId,Album_Name,IsRented,TimeRented,ArtistId,UserId")] Cd cd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistName", cd.ArtistId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserName", cd.UserId);
            return View(cd);
        }

        // GET: Cds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cd = await _context.Cd.FindAsync(id);
            if (cd == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistName", cd.ArtistId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserName", cd.UserId);
            return View(cd);
        }

        // POST: Cds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CdId,Album_Name,IsRented,TimeRented,ArtistId,UserId")] Cd cd)
        {
            if (id != cd.CdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CdExists(cd.CdId))
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
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistName", cd.ArtistId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserName", cd.UserId);
            return View(cd);
        }

        // GET: Cds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cd = await _context.Cd
                .Include(c => c.Artist)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CdId == id);
            if (cd == null)
            {
                return NotFound();
            }

            return View(cd);
        }

        // POST: Cds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cd = await _context.Cd.FindAsync(id);
            _context.Cd.Remove(cd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CdExists(int id)
        {
            return _context.Cd.Any(e => e.CdId == id);
        }
    }
}
