using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Models;

namespace AttendanceSystem.Controllers
{
    public class SignUpsController : Controller
    {
        private readonly MyDbContext _context;

        public SignUpsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: SignUps
        public async Task<IActionResult> Index()
        {
              return _context.SignUps != null ? 
                          View(await _context.SignUps.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.SignUps'  is null.");
        }

        // GET: SignUps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SignUps == null)
            {
                return NotFound();
            }

            var signUp = await _context.SignUps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signUp == null)
            {
                return NotFound();
            }

            return View(signUp);
        }

        // GET: SignUps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SignUps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,Email,PasswordConfirmed,PhoneNumber,Address")] SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signUp);
        }

        // GET: SignUps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SignUps == null)
            {
                return NotFound();
            }

            var signUp = await _context.SignUps.FindAsync(id);
            if (signUp == null)
            {
                return NotFound();
            }
            return View(signUp);
        }

        // POST: SignUps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,Email,PasswordConfirmed,PhoneNumber,Address")] SignUp signUp)
        {
            if (id != signUp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signUp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignUpExists(signUp.Id))
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
            return View(signUp);
        }

        // GET: SignUps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SignUps == null)
            {
                return NotFound();
            }

            var signUp = await _context.SignUps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signUp == null)
            {
                return NotFound();
            }

            return View(signUp);
        }

        // POST: SignUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SignUps == null)
            {
                return Problem("Entity set 'MyDbContext.SignUps'  is null.");
            }
            var signUp = await _context.SignUps.FindAsync(id);
            if (signUp != null)
            {
                _context.SignUps.Remove(signUp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignUpExists(int id)
        {
          return (_context.SignUps?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
