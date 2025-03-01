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
    public class dskhohangModelsController : Controller
    {
        private readonly QuanLyKhoThucPhamContext _context;

        public dskhohangModelsController(QuanLyKhoThucPhamContext context)
        {
            _context = context;
        }

        // GET: KhoHang
        public async Task<IActionResult> Index()
        {
<<<<<<< Updated upstream:QuanLyKhoThucPham/Controllers/dskhohangModelsController.cs
            return _context.dskhohangModel != null ?
                        View(await _context.dskhohangModel.ToListAsync()) :
                          Problem("Entity set 'QuanLyKhoThucPhamContext.dskhohangModel'  is null.");
        }

        // GET: dskhohangModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.dskhohangModel == null)
=======
            return _context.KhoHang != null ?
                        View(await _context.KhoHang.ToListAsync()) :
                        Problem("Entity set 'QuanLyKhoThucPhamContext.KhoHang'  is null.");
        }

        // GET: KhoHang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KhoHang == null)
>>>>>>> Stashed changes:QuanLyKhoThucPham/Controllers/KhoHangController.cs
            {
                return NotFound();
            }

<<<<<<< Updated upstream:QuanLyKhoThucPham/Controllers/dskhohangModelsController.cs
            var dskhohangModel = await _context.dskhohangModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dskhohangModel == null)
=======
            var khoHangModel = await _context.KhoHang
                .FirstOrDefaultAsync(m => m.MaKho == id);
            if (khoHangModel == null)
>>>>>>> Stashed changes:QuanLyKhoThucPham/Controllers/KhoHangController.cs
            {
                return NotFound();
            }

            return View(khoHangModel);
        }

        // GET: KhoHang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhoHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< Updated upstream:QuanLyKhoThucPham/Controllers/dskhohangModelsController.cs
        public async Task<IActionResult> Create([Bind("ID,Name,mota,soluongtong,soluongtrong")] dskhohangModel dskhohangModel)
=======
        public async Task<IActionResult> Create([Bind("MaKho,TenKho,mota,soluongtong,soluongtrong")] KhoHangModel khoHangModel)
>>>>>>> Stashed changes:QuanLyKhoThucPham/Controllers/KhoHangController.cs
        {
            if (ModelState.IsValid)
            {
                _context.Add(khoHangModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khoHangModel);
        }

<<<<<<< Updated upstream:QuanLyKhoThucPham/Controllers/dskhohangModelsController.cs
        // GET: dskhohangModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.dskhohangModel == null)
=======
        // GET: KhoHang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KhoHang == null)
>>>>>>> Stashed changes:QuanLyKhoThucPham/Controllers/KhoHangController.cs
            {
                return NotFound();
            }

<<<<<<< Updated upstream:QuanLyKhoThucPham/Controllers/dskhohangModelsController.cs
            var dskhohangModel = await _context.dskhohangModel.FindAsync(id);
            if (dskhohangModel == null)
=======
            var khoHangModel = await _context.KhoHang.FindAsync(id);
            if (khoHangModel == null)
>>>>>>> Stashed changes:QuanLyKhoThucPham/Controllers/KhoHangController.cs
            {
                return NotFound();
            }
            return View(khoHangModel);
        }

        // POST: KhoHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< Updated upstream:QuanLyKhoThucPham/Controllers/dskhohangModelsController.cs
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,mota,soluongtong,soluongtrong")] dskhohangModel dskhohangModel)
        {
            if (id != dskhohangModel.ID)
=======
        public async Task<IActionResult> Edit(int id, [Bind("MaKho,TenKho,mota,soluongtong,soluongtrong")] KhoHangModel khoHangModel)
        {
            if (id != khoHangModel.MaKho)
>>>>>>> Stashed changes:QuanLyKhoThucPham/Controllers/KhoHangController.cs
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khoHangModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
<<<<<<< Updated upstream:QuanLyKhoThucPham/Controllers/dskhohangModelsController.cs
                    if (!dskhohangModelExists(dskhohangModel.ID))
=======
                    if (!KhoHangModelExists(khoHangModel.MaKho))
>>>>>>> Stashed changes:QuanLyKhoThucPham/Controllers/KhoHangController.cs
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
            return View(khoHangModel);
        }

<<<<<<< Updated upstream:QuanLyKhoThucPham/Controllers/dskhohangModelsController.cs
        // GET: dskhohangModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.dskhohangModel == null)
=======
        // GET: KhoHang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KhoHang == null)
>>>>>>> Stashed changes:QuanLyKhoThucPham/Controllers/KhoHangController.cs
            {
                return NotFound();
            }

<<<<<<< Updated upstream:QuanLyKhoThucPham/Controllers/dskhohangModelsController.cs
            var dskhohangModel = await _context.dskhohangModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dskhohangModel == null)
=======
            var khoHangModel = await _context.KhoHang
                .FirstOrDefaultAsync(m => m.MaKho == id);
            if (khoHangModel == null)
>>>>>>> Stashed changes:QuanLyKhoThucPham/Controllers/KhoHangController.cs
            {
                return NotFound();
            }

            return View(khoHangModel);
        }

        // POST: KhoHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.dskhohangModel == null)
            {
                return Problem("Entity set 'QuanLyKhoThucPhamContext.KhoHang'  is null.");
            }
<<<<<<< Updated upstream:QuanLyKhoThucPham/Controllers/dskhohangModelsController.cs
            var dskhohangModel = await _context.dskhohangModel.FindAsync(id);
            if (dskhohangModel != null)
            {
                _context.dskhohangModel.Remove(dskhohangModel);
=======
            var khoHangModel = await _context.KhoHang.FindAsync(id);
            if (khoHangModel != null)
            {
                _context.KhoHang.Remove(khoHangModel);
>>>>>>> Stashed changes:QuanLyKhoThucPham/Controllers/KhoHangController.cs
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

<<<<<<< Updated upstream:QuanLyKhoThucPham/Controllers/dskhohangModelsController.cs
        private bool dskhohangModelExists(int id)
        {
          return (_context.dskhohangModel?.Any(e => e.ID == id)).GetValueOrDefault();
=======
        private bool KhoHangModelExists(int id)
        {
            return (_context.KhoHang?.Any(e => e.MaKho == id)).GetValueOrDefault();
>>>>>>> Stashed changes:QuanLyKhoThucPham/Controllers/KhoHangController.cs
        }

        //tìm kiếm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.dskhohangModel == null)
            {
                return Problem("Danh sách kho hàng không có dữ liệu ");
            }

<<<<<<< Updated upstream:QuanLyKhoThucPham/Controllers/dskhohangModelsController.cs
            var dskhohangs = from m in _context.dskhohangModel select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                dskhohangs = dskhohangs.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
=======
            var dskhohang = from m in _context.KhoHang select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                dskhohang = dskhohang.Where(s => s.TenKho.ToUpper().Contains(searchString.ToUpper()));
>>>>>>> Stashed changes:QuanLyKhoThucPham/Controllers/KhoHangController.cs
            }

            return View(await dskhohang.ToListAsync());
        }
    }
}
