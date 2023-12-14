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
    public class PagamentoCartaoController : Controller
    {
        private readonly MyDbContext _context;

        public PagamentoCartaoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: PagamentoCartao
        public async Task<IActionResult> Index()
        {
            return View(await _context.PagamentosCartao.ToListAsync());
        }

        // GET: PagamentoCartao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoCartao = await _context.PagamentosCartao
                .FirstOrDefaultAsync(m => m.TipoPagamentoId == id);
            if (pagamentoCartao == null)
            {
                return NotFound();
            }

            return View(pagamentoCartao);
        }

        // GET: PagamentoCartao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PagamentoCartao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PagamentoCartaoId,NumeroCartao,Bandeira,TipoPagamentoId,NomeDoCobrado,InformacoesAdicionais")] PagamentoCartao pagamentoCartao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamentoCartao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagamentoCartao);
        }

        // GET: PagamentoCartao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoCartao = await _context.PagamentosCartao.FindAsync(id);
            if (pagamentoCartao == null)
            {
                return NotFound();
            }
            return View(pagamentoCartao);
        }

        // POST: PagamentoCartao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PagamentoCartaoId,NumeroCartao,Bandeira,TipoPagamentoId,NomeDoCobrado,InformacoesAdicionais")] PagamentoCartao pagamentoCartao)
        {
            if (id != pagamentoCartao.TipoPagamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamentoCartao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoCartaoExists(pagamentoCartao.TipoPagamentoId))
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
            return View(pagamentoCartao);
        }

        // GET: PagamentoCartao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoCartao = await _context.PagamentosCartao
                .FirstOrDefaultAsync(m => m.TipoPagamentoId == id);
            if (pagamentoCartao == null)
            {
                return NotFound();
            }

            return View(pagamentoCartao);
        }

        // POST: PagamentoCartao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagamentoCartao = await _context.PagamentosCartao.FindAsync(id);
            _context.PagamentosCartao.Remove(pagamentoCartao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoCartaoExists(int id)
        {
            return _context.PagamentosCartao.Any(e => e.TipoPagamentoId == id);
        }
    }
}
