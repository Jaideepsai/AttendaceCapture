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
    public class AttendancesController : Controller
    {
        private readonly AttendanceContext _context;

        public AttendancesController(AttendanceContext context)
        {
            _context = context;    
        }

        // GET: Attendances

        public async Task<IActionResult> Index()
        {
            return View(await _context.Attendance.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Index(List<Attendance> attendances, DateTime SearchString)
        {
            var filterresults = from x in _context.Attendance select x;
            if (DateTime.Compare(DateTime.MinValue, SearchString) == 0)
            {

                foreach (var i in attendances)
                {
                    var c = filterresults.Where(a => a.AttendanceID.Equals(i.AttendanceID)).FirstOrDefault();
                    if (c != null)
                    {
                     
                        c.Attendance_status = i.Attendance_status;
                    }
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
         
            if (SearchString != null)
            {
                filterresults = filterresults.Where(x => DateTime.Compare(x.Attendance_Date, SearchString)==0); 

                return View(filterresults.ToList());
            }
                return View(attendances);
            
        }
        // GET: Attendances/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance.SingleOrDefaultAsync(m => m.AttendanceID == id);
            if (attendance == null)
            {
                return NotFound();
            }
            return View(attendance);
        }

        // POST: Attendances/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttendanceID,Name,Attendance_Date,Attendance_status")] Attendance attendance)
        {
            if (id != attendance.AttendanceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceExists(attendance.AttendanceID))
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
            return View(attendance);
        }

        // GET: Attendances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance
                .SingleOrDefaultAsync(m => m.AttendanceID == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // GET: Attendances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attendances/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttendanceID,Name,Attendance_Date,Attendance_status")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(attendance);
        }

 
       
        // GET: Attendances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance
                .SingleOrDefaultAsync(m => m.AttendanceID == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendance = await _context.Attendance.SingleOrDefaultAsync(m => m.AttendanceID == id);
            _context.Attendance.Remove(attendance);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AttendanceExists(int id)
        {
            return _context.Attendance.Any(e => e.AttendanceID == id);
        }
    }
}
