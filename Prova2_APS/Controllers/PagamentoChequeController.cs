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
    public class PagamentoChequeController : Controller
    {
        private readonly MyDbContext _context;

        public PagamentoChequeController(MyDbContext context)
        {
            _context = context;
        }

        // GET: PagamentoCheque
        public async Task<IActionResult> Index()
        {
            return View(await _context.PagamentosComCheque.ToListAsync());
        }

        // GET: PagamentoCheque/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoCheque = await _context.PagamentosComCheque
                .FirstOrDefaultAsync(m => m.TipoPagamentoId == id);
            if (pagamentoCheque == null)
            {
                return NotFound();
            }

            return View(pagamentoCheque);
        }

        // GET: PagamentoCheque/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PagamentoCheque/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PagamentoChequeId,NumeroCartao,Bandeira,TipoPagamentoId,NomeDoCobrado,InformacoesAdicionais")] PagamentoCheque pagamentoCheque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamentoCheque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagamentoCheque);
        }

        // GET: PagamentoCheque/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoCheque = await _context.PagamentosComCheque.FindAsync(id);
            if (pagamentoCheque == null)
            {
                return NotFound();
            }
            return View(pagamentoCheque);
        }

        // POST: PagamentoCheque/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PagamentoChequeId,NumeroCartao,Bandeira,TipoPagamentoId,NomeDoCobrado,InformacoesAdicionais")] PagamentoCheque pagamentoCheque)
        {
            if (id != pagamentoCheque.TipoPagamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamentoCheque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoChequeExists(pagamentoCheque.TipoPagamentoId))
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
            return View(pagamentoCheque);
        }

        // GET: PagamentoCheque/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoCheque = await _context.PagamentosComCheque
                .FirstOrDefaultAsync(m => m.TipoPagamentoId == id);
            if (pagamentoCheque == null)
            {
                return NotFound();
            }

            return View(pagamentoCheque);
        }

        // POST: PagamentoCheque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagamentoCheque = await _context.PagamentosComCheque.FindAsync(id);
            _context.PagamentosComCheque.Remove(pagamentoCheque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoChequeExists(int id)
        {
            return _context.PagamentosComCheque.Any(e => e.TipoPagamentoId == id);
        }
    }
}
