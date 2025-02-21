using Microsoft.AspNetCore.Mvc;
using QuanLyKhoThucPham.Data;
using QuanLyKhoThucPham.Models;
using System.Linq;

namespace QuanLyKhoThucPham.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly KhoContext _context;

        public NhanVienController(KhoContext context)
        {
            _context = context;
        }

        // Danh sách nhân viên
        public IActionResult Index()
        {
            var nhanViens = _context.NhanViens.ToList();
            return View(nhanViens);
        }

        // Chi tiết nhân viên
        public IActionResult Details(int id)
        {
            var nhanVien = _context.NhanViens.Find(id);
            if (nhanVien == null)
                return NotFound();
            return View(nhanVien);
        }

        // Tạo mới nhân viên (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Tạo mới nhân viên (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.NhanViens.Add(nhanVien);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVien);
        }

        // Sửa nhân viên (GET)
        public IActionResult Edit(int id)
        {
            var nhanVien = _context.NhanViens.Find(id);
            if (nhanVien == null)
                return NotFound();
            return View(nhanVien);
        }

        // Sửa nhân viên (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, NhanVien nhanVien)
        {
            if (id != nhanVien.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(nhanVien);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVien);
        }

        // Xóa nhân viên (GET)
        public IActionResult Delete(int id)
        {
            var nhanVien = _context.NhanViens.Find(id);
            if (nhanVien == null)
                return NotFound();
            return View(nhanVien);
        }

        // Xóa nhân viên (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var nhanVien = _context.NhanViens.Find(id);
            if (nhanVien != null)
            {
                _context.NhanViens.Remove(nhanVien);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

