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
    public class PatientsDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientsDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientsDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientsData.ToListAsync());
        }

        // GET: PatientsDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientsData = await _context.PatientsData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientsData == null)
            {
                return NotFound();
            }

            return View(patientsData);
        }

        // GET: PatientsDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientsDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Token,Name,Sex,BirthDate,Phone,Address,Cities,Height,Weight,Appointments")] PatientsData patientsData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientsData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientsData);
        }

        // GET: PatientsDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientsData = await _context.PatientsData.FindAsync(id);
            if (patientsData == null)
            {
                return NotFound();
            }
            return View(patientsData);
        }

        // POST: PatientsDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Token,Name,Sex,BirthDate,Phone,Address,Cities,Height,Weight,Appointments")] PatientsData patientsData)
        {
            if (id != patientsData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientsData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientsDataExists(patientsData.Id))
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
            return View(patientsData);
        }

        // GET: PatientsDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientsData = await _context.PatientsData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientsData == null)
            {
                return NotFound();
            }

            return View(patientsData);
        }

        // POST: PatientsDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientsData = await _context.PatientsData.FindAsync(id);
            _context.PatientsData.Remove(patientsData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientsDataExists(int id)
        {
            return _context.PatientsData.Any(e => e.Id == id);
        }
    }
}
