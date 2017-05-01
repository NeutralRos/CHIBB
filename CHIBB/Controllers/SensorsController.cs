using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CHIBB;

namespace CHIBB.Controllers
{
    public class SensorsController : Controller
    {
        private readonly CHIBBContext _context;

        public SensorsController(CHIBBContext context)
        {
            _context = context;    
        }

        // GET: Sensors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sensors.ToListAsync());
        }

        // GET: Sensors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensors = await _context.Sensors
                .SingleOrDefaultAsync(m => m.Identifier == id);
            if (sensors == null)
            {
                return NotFound();
            }

            return View(sensors);
        }

        // GET: Sensors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWithJson([FromBody] Sensors item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return CreatedAtRoute("GetTodo", new { id = item.Identifier }, item);
        }

        // POST: Sensors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identifier,Sensorname,Sensortype,Sensorcomment")] Sensors sensors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sensors);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sensors);
        }

        // GET: Sensors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensors = await _context.Sensors.SingleOrDefaultAsync(m => m.Identifier == id);
            if (sensors == null)
            {
                return NotFound();
            }
            return View(sensors);
        }

        // POST: Sensors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Identifier,Sensorname,Sensortype,Sensorcomment")] Sensors sensors)
        {
            if (id != sensors.Identifier)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sensors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SensorsExists(sensors.Identifier))
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
            return View(sensors);
        }

        // GET: Sensors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensors = await _context.Sensors
                .SingleOrDefaultAsync(m => m.Identifier == id);
            if (sensors == null)
            {
                return NotFound();
            }

            return View(sensors);
        }

        // POST: Sensors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sensors = await _context.Sensors.SingleOrDefaultAsync(m => m.Identifier == id);
            _context.Sensors.Remove(sensors);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SensorsExists(string id)
        {
            return _context.Sensors.Any(e => e.Identifier == id);
        } 
    } 
}
