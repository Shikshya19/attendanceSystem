using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Models;
using AttendanceSystem.ViewModel;

namespace AttendanceSystem.Controllers
{
    public class StudentRegistrationsController : Controller
    {
        private readonly MyDbContext _context;

        public StudentRegistrationsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: StudentRegistrations
        public async Task<IActionResult> Index()
        {
            var studentList = new List<StudentRegistrationViewModel>();
            try
            {
                if (_context.StudentRegistrations != null) 
                {
                    var getData = await _context.StudentRegistrations.ToListAsync();
                    foreach (var item in getData) 
                    {
                        var groupName = await _context.Groups.
                            FirstOrDefaultAsync(x => x.Id == item.GroupId); 
                        var levelName = await _context.Levels.
                            FirstOrDefaultAsync(x => x.Id == item.LevelId);
                        studentList.Add(new StudentRegistrationViewModel
                        {
                            Id = item.Id,
                            Name = item.Name,
                            GroupName = groupName != null ? groupName.Name : "",
                            LevelName = levelName != null ? levelName.Name : "",
                            LevelId = item.LevelId,
                            GroupId = item.GroupId


                        });
                    }

                }

            }
            catch(Exception ex)
            {


            }
            return View(studentList);


              //return _context.StudentRegistrations != null ? 
              //  View(await _context.StudentRegistrations.ToListAsync()) :
              //Problem("Entity set 'MyDbContext.StudentRegistrations'  is null.");
        }

        // GET: StudentRegistrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentRegistrations == null)
            {
                return NotFound();
            }

            var studentRegistration = await _context.StudentRegistrations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentRegistration == null)
            {
                return NotFound();
            }

            return View(studentRegistration);
        }

        // GET: StudentRegistrations/Create
        public async Task<IActionResult> Create()
        {
            var model = new StudentRegistrationViewModel(); //creating instance
            try 
            {
                var groupList = await _context.Groups.ToListAsync();
                foreach (var da in groupList) 
                {
                    model.GroupData.Add(new SelectListItem //Instance inside
                    {
                        Value = da.Id.ToString(),
                        Text = da.Name

                    });
                }
                var levelList = await _context.Levels.ToListAsync();
                foreach (var da in levelList)
                {
                    model.LevelData.Add(new SelectListItem //Instance inside
                    {
                        Value = da.Id.ToString(),
                        Text = da.Name

                    });
                }
                }
            catch(Exception ex)
            {

            }
            return View(model);
        }

        // POST: StudentRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,GroupId,LevelId")] StudentRegistration studentRegistration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentRegistration);
        }

        // GET: StudentRegistrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var studentRegistration = await _context.StudentRegistrations.FindAsync(id);
            var model = new StudentRegistrationViewModel(); //creating instance
            try
            {
                var groupList = await _context.Groups.ToListAsync();
                foreach (var da in groupList)
                {
                    model.GroupData.Add(new SelectListItem //Instance inside
                    {
                        Value = da.Id.ToString(),
                        Text = da.Name

                    });
                }
                var levelList = await _context.Levels.ToListAsync();
                foreach (var da in levelList)
                {
                    model.LevelData.Add(new SelectListItem //Instance inside
                    {
                        Value = da.Id.ToString(),
                        Text = da.Name

                    });
                }
                model.Name = studentRegistration.Name;
                model.Id = studentRegistration.Id;
                model.GroupId = studentRegistration.GroupId;
                model.LevelId = studentRegistration.LevelId;

            }
            catch (Exception ex)
            {

            }
            return View(model);
        }
        

        // POST: StudentRegistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,GroupId,LevelId")] StudentRegistration studentRegistration)
        {
            if (id != studentRegistration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentRegistrationExists(studentRegistration.Id))
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
            return View(studentRegistration);
        }

        // GET: StudentRegistrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentRegistrations == null)
            {
                return NotFound();
            }

            var studentRegistration = await _context.StudentRegistrations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentRegistration == null)
            {
                return NotFound();
            }

            return View(studentRegistration);
        }

        // POST: StudentRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentRegistrations == null)
            {
                return Problem("Entity set 'MyDbContext.StudentRegistrations'  is null.");
            }
            var studentRegistration = await _context.StudentRegistrations.FindAsync(id);
            if (studentRegistration != null)
            {
                _context.StudentRegistrations.Remove(studentRegistration);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentRegistrationExists(int id)
        {
          return (_context.StudentRegistrations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
