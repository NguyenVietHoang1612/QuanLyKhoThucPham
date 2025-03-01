﻿using System;
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
    public class NhanVienController : Controller
    {
        private readonly QuanLyKhoThucPhamContext _context;

        public NhanVienController(QuanLyKhoThucPhamContext context)
        {
            _context = context;
        }

        // GET: NhanVien
        public async Task<IActionResult> Index()
        {
              return _context.NhanVien != null ? 
                          View(await _context.NhanVien.ToListAsync()) :
                          Problem("Entity set 'QuanLyKhoThucPhamContext.NhanVien'  is null.");
        }

        // GET: NhanVien/Details/5
        public async Task<IActionResult> Details(int? maNV)
        {
            if (maNV == null || _context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien
                .FirstOrDefaultAsync(m => m.MaNhanVien == maNV);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: NhanVien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNhanVien,HoTen,GioiTinh,ChucVu")] NhanVienModel nhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVien);
        }

        // GET: NhanVien/Edit/5
        public async Task<IActionResult> Edit(int? maNV)
        {
            if (maNV == null || _context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien.FindAsync(maNV);
            if (nhanVien == null)
            {
                return NotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int maNV, [Bind("MaNhanVien,HoTen,GioiTinh,ChucVu")] NhanVienModel nhanVien)
        {
            if (maNV != nhanVien.MaNhanVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.MaNhanVien))
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
            return View(nhanVien);
        }

        // GET: NhanVien/Delete/5
        public async Task<IActionResult> Delete(int? maNV)
        {
            if (maNV == null || _context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien
                .FirstOrDefaultAsync(m => m.MaNhanVien == maNV);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int maNV)
        {
            if (_context.NhanVien == null)
            {
                return Problem("Entity set 'QuanLyKhoThucPhamContext.NhanVien'  is null.");
            }
            var nhanVien = await _context.NhanVien.FindAsync(maNV);
            if (nhanVien != null)
            {
                _context.NhanVien.Remove(nhanVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(int maNV)
        {
          return (_context.NhanVien?.Any(e => e.MaNhanVien == maNV)).GetValueOrDefault();
        }



    }
}
