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
    public class SanPhamController : Controller
    {
        private readonly QuanLyKhoThucPhamContext _context;

        public SanPhamController(QuanLyKhoThucPhamContext context)
        {
            _context = context;
        }

        // GET: dsthucpham
        public async Task<IActionResult> Index()
        {
              return _context.SanPham != null ? 
                          View(await _context.SanPham.ToListAsync()) :
                          Problem("Entity set 'QuanLyKhoThucPhamContext.dsthucpham'  is null.");
        }

        // GET: dsthucpham/Details/5
        public async Task<IActionResult> Details(int? maSP)
        {
            if (maSP == null || _context.SanPham == null)
            {
                return NotFound();
            }

            var dsthucpham = await _context.SanPham
                .FirstOrDefaultAsync(m => m.MaSP == maSP);
            if (dsthucpham == null)
            {
                return NotFound();
            }

            return View(dsthucpham);
        }

        // GET: dsthucpham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: dsthucpham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSP,TenSP,SoLuong,DonGia,NhaSanXuat,MoTa,MaNhaCungCap")] SanPhamModel dsthucpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dsthucpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dsthucpham);
        }

        // GET: dsthucpham/Edit/5
        public async Task<IActionResult> Edit(int? maSP)
        {
            if (maSP == null || _context.SanPham == null)
            {
                return NotFound();
            }

            var dsthucpham = await _context.SanPham.FindAsync(maSP);
            if (dsthucpham == null)
            {
                return NotFound();
            }
            return View(dsthucpham);
        }

        // POST: dsthucpham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? maSP, [Bind("MaSP,TenSP,SoLuong,DonGia,NhaSanXuat,MoTa")] SanPhamModel thucPham)
        {
            if (maSP != thucPham.MaSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thucPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dsthucphamExists(thucPham.MaSP))
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
            return View(thucPham);
        }

        // GET: dsthucpham/Delete/5
        public async Task<IActionResult> Delete(int? maSP)
        {
            if (maSP == null || _context.SanPham == null)
            {
                return NotFound();
            }

            var dsThucPham = await _context.SanPham
                .FirstOrDefaultAsync(m => m.MaSP == maSP);
            if (dsThucPham == null)
            {
                return NotFound();
            }

            return View(dsThucPham);
        }

        // POST: dsthucpham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int maSP)
        {
            if (_context.SanPham == null)
            {
                return Problem("Entity set 'QuanLyKhoThucPhamContext.dsthucpham'  is null.");
            }
            var dsthucpham = await _context.SanPham.FindAsync(maSP);
            if (dsthucpham != null)
            {
                _context.SanPham.Remove(dsthucpham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool dsthucphamExists(int maSP)
        {
          return (_context.SanPham?.Any(e => e.MaSP == maSP)).GetValueOrDefault();
        }

        //tìm kiếm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.SanPham == null)
            {
                return Problem("Danh sách kho hàng không có dữ liệu ");
            }

            var dsthucphams = from m in _context.SanPham select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                dsthucphams = dsthucphams.Where(s => s.TenSP.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(await dsthucphams.ToListAsync());
        }
    }
}
