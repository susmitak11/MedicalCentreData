using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalCentreData.Data;
using MedicalCentreData.Models;

namespace MedicalCentreData.Controllers
{
    public class AppointmentDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AppointmentDatas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AppointmentData.Include(a => a.doctor).Include(a => a.patient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AppointmentDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentData = await _context.AppointmentData
                .Include(a => a.doctor)
                .Include(a => a.patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentData == null)
            {
                return NotFound();
            }

            return View(appointmentData);
        }

        // GET: AppointmentDatas/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.DoctorData, "Id", "Id");
            ViewData["PatientId"] = new SelectList(_context.PatientsData, "Id", "Id");
            return View();
        }

        // POST: AppointmentDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDateTime,Detail,Status,PatientId,DoctorId")] AppointmentData appointmentData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointmentData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.DoctorData, "Id", "Id", appointmentData.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.PatientsData, "Id", "Id", appointmentData.PatientId);
            return View(appointmentData);
        }

        // GET: AppointmentDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentData = await _context.AppointmentData.FindAsync(id);
            if (appointmentData == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.DoctorData, "Id", "Id", appointmentData.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.PatientsData, "Id", "Id", appointmentData.PatientId);
            return View(appointmentData);
        }

        // POST: AppointmentDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDateTime,Detail,Status,PatientId,DoctorId")] AppointmentData appointmentData)
        {
            if (id != appointmentData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentDataExists(appointmentData.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.DoctorData, "Id", "Id", appointmentData.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.PatientsData, "Id", "Id", appointmentData.PatientId);
            return View(appointmentData);
        }

        // GET: AppointmentDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentData = await _context.AppointmentData
                .Include(a => a.doctor)
                .Include(a => a.patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentData == null)
            {
                return NotFound();
            }

            return View(appointmentData);
        }

        // POST: AppointmentDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointmentData = await _context.AppointmentData.FindAsync(id);
            _context.AppointmentData.Remove(appointmentData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentDataExists(int id)
        {
            return _context.AppointmentData.Any(e => e.Id == id);
        }
    }
}
