using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entity_Framework.Models;
using RolesyUsuarios.Data;

namespace RolesyUsuarios.Controllers
{
    public class ObraCategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ObraCategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ObraCategorias
        public async Task<IActionResult> Index()
        {
            return View(await _context.ObraCategorias.ToListAsync());
        }

        // GET: ObraCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obraCategoria = await _context.ObraCategorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obraCategoria == null)
            {
                return NotFound();
            }

            return View(obraCategoria);
        }

        // GET: ObraCategorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ObraCategorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] ObraCategoria obraCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obraCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obraCategoria);
        }

        // GET: ObraCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obraCategoria = await _context.ObraCategorias.FindAsync(id);
            if (obraCategoria == null)
            {
                return NotFound();
            }
            return View(obraCategoria);
        }

        // POST: ObraCategorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] ObraCategoria obraCategoria)
        {
            if (id != obraCategoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obraCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObraCategoriaExists(obraCategoria.Id))
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
            return View(obraCategoria);
        }

        // GET: ObraCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obraCategoria = await _context.ObraCategorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obraCategoria == null)
            {
                return NotFound();
            }

            return View(obraCategoria);
        }

        // POST: ObraCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obraCategoria = await _context.ObraCategorias.FindAsync(id);
            _context.ObraCategorias.Remove(obraCategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObraCategoriaExists(int id)
        {
            return _context.ObraCategorias.Any(e => e.Id == id);
        }
    }
}
