using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers
{
    public class ExampleProjectController : Controller
    {
        private readonly Context _context;

        public ExampleProjectController(Context context)
        {
            _context = context;
        }

        // GET: ExampleProject
        public async Task<IActionResult> Index()
        {
            var context = _context.ExampleProjects.Include(e => e.Outcome).Include(e => e.Student);
            return View(await context.ToListAsync());
        }

        // GET: ExampleProject/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exampleProject = await _context.ExampleProjects
                .Include(e => e.Outcome)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exampleProject == null)
            {
                return NotFound();
            }

            return View(exampleProject);
        }

        // GET: ExampleProject/Create
        public IActionResult Create()
        {
            ViewData["OutcomeId"] = new SelectList(_context.Outcomes, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: ExampleProject/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,OutcomeId,Name,Id")] ExampleProject exampleProject)
        {
            if (ModelState.IsValid)
            {
                exampleProject.Id = Guid.NewGuid();
                _context.Add(exampleProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OutcomeId"] = new SelectList(_context.Outcomes, "Id", "Id", exampleProject.OutcomeId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", exampleProject.StudentId);
            return View(exampleProject);
        }

        // GET: ExampleProject/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exampleProject = await _context.ExampleProjects.FindAsync(id);
            if (exampleProject == null)
            {
                return NotFound();
            }
            ViewData["OutcomeId"] = new SelectList(_context.Outcomes, "Id", "Id", exampleProject.OutcomeId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", exampleProject.StudentId);
            return View(exampleProject);
        }

        // POST: ExampleProject/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("StudentId,OutcomeId,Name,Id")] ExampleProject exampleProject)
        {
            if (id != exampleProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exampleProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExampleProjectExists(exampleProject.Id))
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
            ViewData["OutcomeId"] = new SelectList(_context.Outcomes, "Id", "Id", exampleProject.OutcomeId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", exampleProject.StudentId);
            return View(exampleProject);
        }

        // GET: ExampleProject/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exampleProject = await _context.ExampleProjects
                .Include(e => e.Outcome)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exampleProject == null)
            {
                return NotFound();
            }

            return View(exampleProject);
        }

        // POST: ExampleProject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var exampleProject = await _context.ExampleProjects.FindAsync(id);
            _context.ExampleProjects.Remove(exampleProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExampleProjectExists(Guid id)
        {
            return _context.ExampleProjects.Any(e => e.Id == id);
        }
    }
}
