using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SA_CarSales.Data;
using SA_CarSales.Models;
using SA_CarSales.ViewModels;

namespace SA_CarSales.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            
            var vTypes = _context.VehicleTypes.ToList();
            ViewBag.VehicleTypes = new List<SelectListItem>();
            foreach (var item in vTypes)
            {
                ViewBag.VehicleTypes.Add(new SelectListItem() { Text = item.Name, Value = item.VehicleTypeId.ToString() });
            }
            var applicationDbContext = _context.Vehicles.Include(v => v.VehicleType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(m => m.Id == id);
                     
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            var vTypes = _context.VehicleTypes.ToList();
            ViewBag.VehicleTypes = new List<SelectListItem>();
            foreach (var item in vTypes)
            {
                ViewBag.VehicleTypes.Add(new SelectListItem() { Text = item.Name, Value = item.VehicleTypeId.ToString() });
            }

            //ViewBag.VehicleTypes = _context.VehicleTypes.ToList();
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeId,Make,Model,NoOfDoors,NoOfWheels")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.Id = Guid.NewGuid();
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeId"] = new SelectList(_context.VehicleTypes, "VehicleTypeId", "VehicleTypeId", vehicle.VehicleType);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vTypes = _context.VehicleTypes.ToList();
            ViewBag.VehicleTypes = new List<SelectListItem>();
            foreach (var item in vTypes)
            {
                ViewBag.VehicleTypes.Add(new SelectListItem() { Text = item.Name, Value = item.VehicleTypeId.ToString() });
            }
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["TypeId"] = new SelectList(_context.VehicleTypes, "VehicleTypeId", "VehicleTypeId", vehicle.VehicleType);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TypeId,Make,Model,NoOfDoors,NoOfWheels")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
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
            ViewData["TypeId"] = new SelectList(_context.VehicleTypes, "VehicleTypeId", "VehicleTypeId", vehicle.VehicleType);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(Guid id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}
