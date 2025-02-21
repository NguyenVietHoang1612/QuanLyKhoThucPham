using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoThucPham.Data;
using QuanLyKhoThucPham.Models;

namespace QuanLyKhoThucPham.Controllers
{
    public class dskhohangModelsController : Controller
    {
        private readonly QuanLyKhoThucPhamContext _context;

        public dskhohangModelsController(QuanLyKhoThucPhamContext context)
        {
            _context = context;
        }

        // GET: dskhohangModels
        public async Task<IActionResult> Index()
        {
            return _context.dskhohangModel != null ?
                        View(await _context.dskhohangModel.ToListAsync()) :
                          Problem("Entity set 'QuanLyKhoThucPhamContext.dskhohangModel'  is null.");
        }

        // GET: dskhohangModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.dskhohangModel == null)
            {
                return NotFound();
            }

            var dskhohangModel = await _context.dskhohangModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dskhohangModel == null)
            {
                return NotFound();
            }

            return View(dskhohangModel);
        }

        // GET: dskhohangModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: dskhohangModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,mota,soluongtong,soluongtrong")] dskhohangModel dskhohangModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dskhohangModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dskhohangModel);
        }

        // GET: dskhohangModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.dskhohangModel == null)
            {
                return NotFound();
            }

            var dskhohangModel = await _context.dskhohangModel.FindAsync(id);
            if (dskhohangModel == null)
            {
                return NotFound();
            }
            return View(dskhohangModel);
        }

        // POST: dskhohangModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,mota,soluongtong,soluongtrong")] dskhohangModel dskhohangModel)
        {
            if (id != dskhohangModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dskhohangModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dskhohangModelExists(dskhohangModel.ID))
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
            return View(dskhohangModel);
        }

        // GET: dskhohangModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.dskhohangModel == null)
            {
                return NotFound();
            }

            var dskhohangModel = await _context.dskhohangModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dskhohangModel == null)
            {
                return NotFound();
            }

            return View(dskhohangModel);
        }

        // POST: dskhohangModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.dskhohangModel == null)
            {
                return Problem("Entity set 'QuanLyKhoThucPhamContext.dskhohangModel'  is null.");
            }
            var dskhohangModel = await _context.dskhohangModel.FindAsync(id);
            if (dskhohangModel != null)
            {
                _context.dskhohangModel.Remove(dskhohangModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool dskhohangModelExists(int id)
        {
          return (_context.dskhohangModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
        //tìm kiếm
        
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.dskhohangModel == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var dskhohangModels = from m in _context.dskhohangModel
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                dskhohangModels = dskhohangModels.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(await dskhohangModels.ToListAsync());
        }
    }
}
