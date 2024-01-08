using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;
using System.Data;

namespace ProjetoFinal.Controllers
{
    public class ComprasController : Controller
    {
        private readonly Contexto _contexto;

        public ComprasController(Contexto contexto)
        {
            _contexto = contexto;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {
            var contexto = _contexto.Compras.Include(c => c.Cliente).Include(p => p.Produto);
            return View(await contexto.ToListAsync());
        }

        [HttpPost]
        public IActionResult FechamentoCaixa(DateTime dataSel)
        {
            ViewData["dataSel"] = dataSel;

            var fechamento = _contexto.Compras
                .Where(c => c.DataCompra.Date == dataSel.Date)
                .Include(p => p.Produto)
                .Include(cl => cl.Cliente)
                .ToList();
            return View(fechamento);
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _contexto.Compras == null)
            {
                return NotFound();
            }

            var compra = await _contexto.Compras
                .Include(c => c.Cliente)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.CompraID == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            ViewData["ClienteID"] = new SelectList(_contexto.Clientes, "ClienteID", "Nome");
            ViewData["ProdutoID"] = new SelectList(_contexto.Produtos, "ProdutoID", "Nome");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompraID,ClienteID,ProdutoID,DataCompra,FormaPagamento")] Compra compra)
        {
            ViewData["ClienteID"] = new SelectList(_contexto.Clientes, "ClienteID", "Nome", compra.ClienteID);
            ViewData["ProdutoID"] = new SelectList(_contexto.Produtos, "ProdutoID", "Nome", compra.ProdutoID);

            //if (ModelState.IsValid)
            //{
                _contexto.Add(compra);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _contexto.Compras == null)
            {
                return NotFound();
            }

            var compra = await _contexto.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            ViewData["ClienteID"] = new SelectList(_contexto.Clientes, "ClienteID", "Nome", compra.ClienteID);
            ViewData["ProdutoID"] = new SelectList(_contexto.Produtos, "ProdutoID", "Nome", compra.ProdutoID);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompraID,ClienteID,ProdutoID,DataCompra,FormaPagamento")] Compra compra)
        {
            if (id != compra.CompraID)
            {
                return NotFound();
            }

            ViewData["ClienteID"] = new SelectList(_contexto.Clientes, "ClienteID", "Nome", compra.ClienteID);
            ViewData["ProdutoID"] = new SelectList(_contexto.Produtos, "ProdutoID", "Nome", compra.ProdutoID);
            //if (ModelState.IsValid)
            //{
                try
                {
                    _contexto.Update(compra);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.CompraID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //return View(compra);
            //}
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _contexto.Compras == null)
            {
                return NotFound();
            }

            var compra = await _contexto.Compras
                .Include(c => c.Cliente)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.CompraID == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_contexto.Compras == null)
            {
                return Problem("Entity set 'Contexto.Compras'  is null.");
            }
            var compra = await _contexto.Compras.FindAsync(id);
            if (compra != null)
            {
                _contexto.Compras.Remove(compra);
            }
            
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
          return (_contexto.Compras?.Any(e => e.CompraID == id)).GetValueOrDefault();
        }
    }
}
