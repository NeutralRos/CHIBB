using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CHIBB;
using CHIBB.Models;

namespace CHIBB.Controllers
{
    public class SensorvaluesController : Controller
    {
        private readonly CHIBBContext _context;
        private readonly ISensorsRepository _sensorsRepository;

        public SensorvaluesController(CHIBBContext context, ISensorsRepository sensorsRepository)
        {
            _context = context;
            _sensorsRepository = sensorsRepository;
        } 

        // GET: Sensorvalues
        public async Task<IActionResult> Index()
        {
            var cHIBBContext = _context.Sensorvalues.Include(s => s.IdentifierNavigation);
            return View(await cHIBBContext.ToListAsync());
        }

        [HttpGet]
        public IEnumerable<Sensorvalues> GetAll()
        {
            return _sensorsRepository.GetAll();
        }

        // GET: Sensorvalues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensorvalues = await _context.Sensorvalues
                .Include(s => s.IdentifierNavigation)
                .SingleOrDefaultAsync(m => m.Valuekey == id);
            if (sensorvalues == null)
            {
                return NotFound();
            }

            return View(sensorvalues);
        }

        // GET: Sensorvalues/Create
        public IActionResult Create()
        {
            ViewData["Identifier"] = new SelectList(_context.Sensors, "Identifier", "Identifier");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWithJson([FromBody] Sensorvalues item)
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

        // POST: Sensorvalues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Valuekey,Identifier,Sensordata,Datadate,Ipadress")] Sensorvalues sensorvalues)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sensorvalues);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Identifier"] = new SelectList(_context.Sensors, "Identifier", "Identifier", sensorvalues.Identifier);
            return View(sensorvalues);
        }

        // GET: Sensorvalues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensorvalues = await _context.Sensorvalues.SingleOrDefaultAsync(m => m.Valuekey == id);
            if (sensorvalues == null)
            {
                return NotFound();
            }
            ViewData["Identifier"] = new SelectList(_context.Sensors, "Identifier", "Identifier", sensorvalues.Identifier);
            return View(sensorvalues);
        }

        // POST: Sensorvalues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Valuekey,Identifier,Sensordata,Datadate,Ipadress")] Sensorvalues sensorvalues)
        {
            if (id != sensorvalues.Valuekey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sensorvalues);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SensorvaluesExists(sensorvalues.Valuekey))
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
            ViewData["Identifier"] = new SelectList(_context.Sensors, "Identifier", "Identifier", sensorvalues.Identifier);
            return View(sensorvalues);
        }

        // GET: Sensorvalues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensorvalues = await _context.Sensorvalues
                .Include(s => s.IdentifierNavigation)
                .SingleOrDefaultAsync(m => m.Valuekey == id);
            if (sensorvalues == null)
            {
                return NotFound();
            }

            return View(sensorvalues);
        }

        // POST: Sensorvalues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sensorvalues = await _context.Sensorvalues.SingleOrDefaultAsync(m => m.Valuekey == id);
            _context.Sensorvalues.Remove(sensorvalues);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SensorvaluesExists(int id)
        {
            return _context.Sensorvalues.Any(e => e.Valuekey == id);
        } 
    }
}
