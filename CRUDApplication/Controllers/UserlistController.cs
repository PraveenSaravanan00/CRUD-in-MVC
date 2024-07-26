using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDApplication.Models;

namespace CRUDApplication.Controllers
{
    public class UserlistController : Controller
    {
        private readonly PraveenContext _context;

        public UserlistController(PraveenContext context)
        {
            _context = context;
        }

        // GET: Userlist
        public async Task<IActionResult> Index()
        {
            return View(await _context.Userlistdata.ToListAsync());
        }

        // GET: Userlist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userlistdatum = await _context.Userlistdata
                .FirstOrDefaultAsync(m => m.Userid == id);
            if (userlistdatum == null)
            {
                return NotFound();
            }

            return View(userlistdatum);
        }

        // GET: Userlist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Userlist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Firstname,Lastname,Salary,Gender,Userid")] Userlistdatum userlistdatum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userlistdatum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userlistdatum);
        }

        // GET: Userlist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userlistdatum = await _context.Userlistdata.FindAsync(id);
            if (userlistdatum == null)
            {
                return NotFound();
            }
            return View(userlistdatum);
        }

        // POST: Userlist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Firstname,Lastname,Salary,Gender,Userid")] Userlistdatum userlistdatum)
        {
            if (id != userlistdatum.Userid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userlistdatum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserlistdatumExists(userlistdatum.Userid))
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
            return View(userlistdatum);
        }

        // GET: Userlist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userlistdatum = await _context.Userlistdata
                .FirstOrDefaultAsync(m => m.Userid == id);
            if (userlistdatum == null)
            {
                return NotFound();
            }

            return View(userlistdatum);
        }

        // POST: Userlist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userlistdatum = await _context.Userlistdata.FindAsync(id);
            if (userlistdatum != null)
            {
                _context.Userlistdata.Remove(userlistdatum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserlistdatumExists(int id)
        {
            return _context.Userlistdata.Any(e => e.Userid == id);
        }
    }
}
