#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prova2_APS.Models;
using democsharp.Models;

namespace Prova2_APS.Controllers
{
    public class NotaVendaController : Controller
    {
        private readonly MyDbContext _context;

        public NotaVendaController(MyDbContext context)
        {
            _context = context;
        }

        // GET: NotaVenda
        public async Task<IActionResult> Index()
        {
            return View(await _context.NotasVenda.ToListAsync());
        }

        // GET: NotaVenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaVenda = await _context.NotasVenda
                .FirstOrDefaultAsync(m => m.NotaVendaId == id);
            if (notaVenda == null)
            {
                return NotFound();
            }

            return View(notaVenda);
        }

        // GET: NotaVenda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NotaVenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NotaVendaId,Data,Tipo")] NotaVenda notaVenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notaVenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notaVenda);
        }

        // GET: NotaVenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaVenda = await _context.NotasVenda.FindAsync(id);
            if (notaVenda == null)
            {
                return NotFound();
            }
            return View(notaVenda);
        }

        // POST: NotaVenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NotaVendaId,Data,Tipo")] NotaVenda notaVenda)
        {
            if (id != notaVenda.NotaVendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notaVenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaVendaExists(notaVenda.NotaVendaId))
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
            return View(notaVenda);
        }

        // GET: NotaVenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaVenda = await _context.NotasVenda
                .FirstOrDefaultAsync(m => m.NotaVendaId == id);
            if (notaVenda == null)
            {
                return NotFound();
            }

            return View(notaVenda);
        }

        // POST: NotaVenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notaVenda = await _context.NotasVenda.FindAsync(id);
            _context.NotasVenda.Remove(notaVenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaVendaExists(int id)
        {
            return _context.NotasVenda.Any(e => e.NotaVendaId == id);
        }
    }
}
