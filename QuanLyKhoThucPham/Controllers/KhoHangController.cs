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
    public class KhoHangController : Controller
    {
        private readonly QuanLyKhoThucPhamContext _context;

        public KhoHangController(QuanLyKhoThucPhamContext context)
        {
            _context = context;
        }

        // GET: dskhohangModels
        public async Task<IActionResult> Index()
        {
            return _context.KhoHang != null ?
                        View(await _context.KhoHang.ToListAsync()) :
                          Problem("Entity set 'QuanLyKhoThucPhamContext.dskhohangModel'  is null.");
        }

        // GET: dskhohangModels/Details/5
        public async Task<IActionResult> Details(int? maKhoHang)
        {
            if (maKhoHang == null || _context.KhoHang == null)
            {
                return NotFound();
            }

            var dskhohangModel = await _context.KhoHang
                .FirstOrDefaultAsync(m => m.MaKho == maKhoHang);
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
        public async Task<IActionResult> Create([Bind("MaKho,TenKho,soluongtong,soluongtrong,mota")] KhoHangModel dskhohangModel)
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
        public async Task<IActionResult> Edit(int? maKhoHang)
        {
            if (maKhoHang == null || _context.KhoHang == null)
            {
                return NotFound();
            }

            var dskhohangModel = await _context.KhoHang.FindAsync(maKhoHang);
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
        public async Task<IActionResult> Edit(int maKhoHang, [Bind("MaKho,TenKho,soluongtong,soluongtrong,mota")] KhoHangModel dskhohangModel)
        {
            if (maKhoHang != dskhohangModel.MaKho)
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
                    if (!dskhohangModelExists(dskhohangModel.MaKho))
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
        public async Task<IActionResult> Delete(int? maKhoHang)
        {
            if (maKhoHang == null || _context.KhoHang == null)
            {
                return NotFound();
            }

            var dskhohangModel = await _context.KhoHang
                .FirstOrDefaultAsync(m => m.MaKho == maKhoHang);
            if (dskhohangModel == null)
            {
                return NotFound();
            }

            return View(dskhohangModel);
        }

        // POST: dskhohangModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int maKhoHang)
        {
            if (_context.KhoHang == null)
            {
                return Problem("Entity set 'QuanLyKhoThucPhamContext.dskhohangModel'  is null.");
            }
            var dskhohangModel = await _context.KhoHang.FindAsync(maKhoHang);
            if (dskhohangModel != null)
            {
                _context.KhoHang.Remove(dskhohangModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool dskhohangModelExists(int maKhoHang)
        {
          return (_context.KhoHang?.Any(e => e.MaKho == maKhoHang)).GetValueOrDefault();
        }
        //tìm kiếm
         [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.KhoHang == null)
            {
                return Problem("Danh sách kho hàng không có dữ liệu ");
            }

            var dskhohangs = from m in _context.KhoHang select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                dskhohangs = dskhohangs.Where(s => s.TenKho.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(await dskhohangs.ToListAsync());
        }
    }
}
