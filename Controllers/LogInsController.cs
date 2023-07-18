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
    public class LogInsController : Controller
    {
        private readonly MyDbContext _context;

        public LogInsController(MyDbContext context)
        {
            _context = context;
        }


        // GET: LogIns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LogIns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password")] LogIn logIn)
        {
            try
            {
                var logInExit = await _context.SignUps.FirstOrDefaultAsync(x => x.Username == logIn.Username
                && x.Password == logIn.Password);
                if (logInExit == null)
                {
                    return RedirectToAction("Create", "SignUps");
                }
            }
            catch (Exception ex)
            {

            }
            return View(logIn);
        }
    }
}
