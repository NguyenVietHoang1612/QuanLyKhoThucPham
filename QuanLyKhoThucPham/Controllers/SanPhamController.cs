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
    public class SanPhamController : Controller
    {
        private readonly QuanLyKhoThucPhamContext _context;

        public SanPhamController(QuanLyKhoThucPhamContext context)
        {
            _context = context;
        }

      

        // GET: SanPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SanPham == null)
            {
                return NotFound();
            }

            var sanPhamModel = await _context.SanPham
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }

            return View(sanPhamModel);
        }

        // GET: SanPham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSP,TenSP,SoLuong,DonGia,NhaSanXuat,MoTa")] SanPhamModel sanPhamModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPhamModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sanPhamModel);
        }

        // GET: SanPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SanPham == null)
            {
                return NotFound();
            }

            var sanPhamModel = await _context.SanPham.FindAsync(id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }
            return View(sanPhamModel);
        }

        // POST: SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSP,TenSP,SoLuong,DonGia,NhaSanXuat,MoTa")] SanPhamModel sanPhamModel)
        {
            if (id != sanPhamModel.MaSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPhamModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamModelExists(sanPhamModel.MaSP))
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
            return View(sanPhamModel);
        }

        // GET: SanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SanPham == null)
            {
                return NotFound();
            }

            var sanPhamModel = await _context.SanPham
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }

            return View(sanPhamModel);
        }

        // POST: SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SanPham == null)
            {
                return Problem("Entity set 'QuanLyKhoThucPhamContext.SanPham'  is null.");
            }
            var sanPhamModel = await _context.SanPham.FindAsync(id);
            if (sanPhamModel != null)
            {
                _context.SanPham.Remove(sanPhamModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamModelExists(int id)
        {
            return (_context.SanPham?.Any(e => e.MaSP == id)).GetValueOrDefault();
        }


        //tìm kiếm
      
        public async Task<IActionResult> Index(
            string searchString,
            string sortOrder,
            string currentFilter,
            int? pageNumber)
        {
            if (_context.SanPham == null)
            {
                return Problem("Danh sách kho hàng không có dữ liệu ");
            }

            var dsthucphams = from m in _context.SanPham select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                dsthucphams = dsthucphams.Where(s => s.TenSP.ToUpper().Contains(searchString.ToUpper()));
            }

            //phân trang
            {
                ViewData["CurrentSort"] = sortOrder;


                if (searchString != null)
                {
                    pageNumber = 1;
                }
                else
                {
                    searchString = currentFilter;
                }
                int pageSize = 3;
                return View(await PaginatedList<SanPhamModel>.CreateAsync(dsthucphams.AsNoTracking(), pageNumber ?? 1, pageSize));
            }
        }

    }
}
