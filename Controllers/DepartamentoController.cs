using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using assessment.Context;
using assessment.Models;

namespace assessment.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly InfnetDbContext _context;

        public DepartamentoController(InfnetDbContext context)
        {
            _context = context;
        }

        // GET: Departamento
        public async Task<IActionResult> Index()
        {
              return _context.Departamento != null ? 
                          View(await _context.Departamento.ToListAsync()) :
                          Problem("Entity set 'InfnetDbContext.Departamento'  is null.");
        }

        // GET: Departamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Departamento == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // GET: Departamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Local")] Departamento departamento)
        {
            Console.WriteLine("Linha 61");
            if (ModelState.IsValid)
            {
                Console.WriteLine("Linha 64");
                _context.Add(departamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }else
    {
        var errors = ModelState.Values.SelectMany(v => v.Errors);
        foreach (var error in errors)
        {
            Console.WriteLine(error.ErrorMessage);
        }
    }
            return View(departamento);
        }

        // GET: Departamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Departamento == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        // POST: Departamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Local")] Departamento departamento)
        {
            if (id != departamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(departamento.Id))
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
            return View(departamento);
        }

        // GET: Departamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Departamento == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // POST: Departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Departamento == null)
            {
                return Problem("Entity set 'InfnetDbContext.Departamento'  is null.");
            }
            var departamento = await _context.Departamento.FindAsync(id);
            if (departamento != null)
            {
                _context.Departamento.Remove(departamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentoExists(int id)
        {
          return (_context.Departamento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
