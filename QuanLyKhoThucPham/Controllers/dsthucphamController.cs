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
    public class dsthucphamController : Controller
    {
        private readonly QuanLyKhoThucPhamContext _context;

        public dsthucphamController(QuanLyKhoThucPhamContext context)
        {
            _context = context;
        }

        // GET: dsthucpham
        public async Task<IActionResult> Index()
        {
              return _context.dsthucpham != null ? 
                          View(await _context.dsthucpham.ToListAsync()) :
                          Problem("Entity set 'QuanLyKhoThucPhamContext.dsthucpham'  is null.");
        }

        // GET: dsthucpham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.dsthucpham == null)
            {
                return NotFound();
            }

            var dsthucpham = await _context.dsthucpham
                .FirstOrDefaultAsync(m => m.ID == id);
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
        public async Task<IActionResult> Create([Bind("ID,tenSP,mota,soluong,ngaysx,hsd,nhasanxuat,gia")] dsthucpham dsthucpham)
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.dsthucpham == null)
            {
                return NotFound();
            }

            var dsthucpham = await _context.dsthucpham.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,tenSP,mota,soluong,ngaysx,hsd,nhasanxuat,gia")] dsthucpham dsthucpham)
        {
            if (id != dsthucpham.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dsthucpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dsthucphamExists(dsthucpham.ID))
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
            return View(dsthucpham);
        }

        // GET: dsthucpham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.dsthucpham == null)
            {
                return NotFound();
            }

            var dsthucpham = await _context.dsthucpham
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dsthucpham == null)
            {
                return NotFound();
            }

            return View(dsthucpham);
        }

        // POST: dsthucpham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.dsthucpham == null)
            {
                return Problem("Entity set 'QuanLyKhoThucPhamContext.dsthucpham'  is null.");
            }
            var dsthucpham = await _context.dsthucpham.FindAsync(id);
            if (dsthucpham != null)
            {
                _context.dsthucpham.Remove(dsthucpham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool dsthucphamExists(int id)
        {
          return (_context.dsthucpham?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        //tìm kiếm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.dsthucpham == null)
            {
                return Problem("Danh sách kho hàng không có dữ liệu ");
            }

            var dsthucphams = from m in _context.dsthucpham select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                dsthucphams = dsthucphams.Where(s => s.tenSP.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(await dsthucphams.ToListAsync());
        }
    }
}
