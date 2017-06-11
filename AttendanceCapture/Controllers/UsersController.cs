using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AttendanceCapture.Data;
using AttendanceCapture.Models;

namespace AttendanceCapture.Controllers
{
    public class UsersController : Controller
    {
        private readonly AttendanceContext _context;

        public UsersController(AttendanceContext context)
        {
            _context = context;    
        }
        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }   
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(List<Users> users, DateTime selectedDate, Attendance attendance)
        {
            if (DateTime.Compare(DateTime.MinValue, selectedDate) != 0)
            {
                var AttendanceList = from x in _context.Attendance select x;
                var c = AttendanceList.Where(a => a.Attendance_Date.Equals(selectedDate)).FirstOrDefault();
                if (c == null)
                {
                    foreach (var i in users)
                    {
                        Attendance attendanceAdd = new Attendance();
                        attendanceAdd.Name = i.Name;
                        attendanceAdd.Attendance_Date = selectedDate;
                        attendanceAdd.Attendance_status = i.Temporary_status;
                        _context.Add(attendanceAdd);
                        _context.SaveChanges();
                    }
                    return RedirectToAction("Index", "Attendances");
                }
                else
                {
                    ViewBag.Message = "Samedate";
                    return View(_context.Users.ToList());
                }
            }
            else
            {
                ViewBag.Message = "nullDate";
                return View(_context.Users.ToList());
            }
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .SingleOrDefaultAsync(m => m.ID == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        public async Task<IActionResult> viewStudents()
        {
            return View(await _context.Users.ToListAsync());
        }
        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,DOB,UnivId")] Users users)
        {
            if (ModelState.IsValid)
            {
                _context.Add(users);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.SingleOrDefaultAsync(m => m.ID == id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: Users/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,DOB,UnivId")] Users users)
        {
            if (id != users.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .SingleOrDefaultAsync(m => m.ID == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.Users.SingleOrDefaultAsync(m => m.ID == id);
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
