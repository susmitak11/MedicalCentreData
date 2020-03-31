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
    public class DoctorDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DoctorDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.DoctorData.ToListAsync());
        }

        // GET: DoctorDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorData = await _context.DoctorData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorData == null)
            {
                return NotFound();
            }

            return View(doctorData);
        }

        // GET: DoctorDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,IsAvailable,Address,Specialization")] DoctorData doctorData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorData);
        }

        // GET: DoctorDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorData = await _context.DoctorData.FindAsync(id);
            if (doctorData == null)
            {
                return NotFound();
            }
            return View(doctorData);
        }

        // POST: DoctorDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone,IsAvailable,Address,Specialization")] DoctorData doctorData)
        {
            if (id != doctorData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorDataExists(doctorData.Id))
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
            return View(doctorData);
        }

        // GET: DoctorDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorData = await _context.DoctorData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorData == null)
            {
                return NotFound();
            }

            return View(doctorData);
        }

        // POST: DoctorDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorData = await _context.DoctorData.FindAsync(id);
            _context.DoctorData.Remove(doctorData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorDataExists(int id)
        {
            return _context.DoctorData.Any(e => e.Id == id);
        }
    }
}
