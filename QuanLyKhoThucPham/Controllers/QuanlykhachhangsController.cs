using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoThucPham.Data;
using QuanLyKhoThucPham.Models;

namespace QuanLyKhoThucPham.Controllers
{
    public class QuanlykhachhangsController : Controller
    {
        private readonly QuanLyKhoThucPhamContext _context;

        public QuanlykhachhangsController(QuanLyKhoThucPhamContext context)
        {
            _context = context;
        }

        // GET: Quanlykhachhangs
        public async Task<IActionResult> Index()
        {
              return _context.Quanlykhachhang != null ? 
                          View(await _context.Quanlykhachhang.ToListAsync()) :
                          Problem("Entity set 'QuanLyKhoThucPhamContext.Quanlykhachhang'  is null.");
        }

        // GET: Quanlykhachhangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Quanlykhachhang == null)
            {
                return NotFound();
            }

            var quanlykhachhang = await _context.Quanlykhachhang
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quanlykhachhang == null)
            {
                return NotFound();
            }

            return View(quanlykhachhang);
        }

        // GET: Quanlykhachhangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quanlykhachhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenKH,MaKH,Diachi,Email,SDT")] Quanlykhachhang quanlykhachhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanlykhachhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanlykhachhang);
        }

        // GET: Quanlykhachhangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Quanlykhachhang == null)
            {
                return NotFound();
            }

            var quanlykhachhang = await _context.Quanlykhachhang.FindAsync(id);
            if (quanlykhachhang == null)
            {
                return NotFound();
            }
            return View(quanlykhachhang);
        }

        // POST: Quanlykhachhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenKH,MaKH,Diachi,Email,SDT")] Quanlykhachhang quanlykhachhang)
        {
            if (id != quanlykhachhang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanlykhachhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanlykhachhangExists(quanlykhachhang.Id))
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
            return View(quanlykhachhang);
        }

        // GET: Quanlykhachhangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Quanlykhachhang == null)
            {
                return NotFound();
            }

            var quanlykhachhang = await _context.Quanlykhachhang
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quanlykhachhang == null)
            {
                return NotFound();
            }

            return View(quanlykhachhang);
        }

        // POST: Quanlykhachhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Quanlykhachhang == null)
            {
                return Problem("Entity set 'QuanLyKhoThucPhamContext.Quanlykhachhang'  is null.");
            }
            var quanlykhachhang = await _context.Quanlykhachhang.FindAsync(id);
            if (quanlykhachhang != null)
            {
                _context.Quanlykhachhang.Remove(quanlykhachhang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanlykhachhangExists(int id)
        {
          return (_context.Quanlykhachhang?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
