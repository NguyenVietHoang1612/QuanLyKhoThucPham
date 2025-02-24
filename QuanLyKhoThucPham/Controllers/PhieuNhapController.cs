using QuanLyKhoThucPham.Data;
using QuanLyKhoThucPham.Models;
using QuanLyKhoThucPham.Models.View_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace QuanLyKhoThucPham.Controllers
{
    public class PhieuNhapController : Controller
    {
        private readonly KhoThucPhamContext _context;

        public PhieuNhapController(KhoThucPhamContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var phieuNhap = _context.PhieuNhap;
            return View(phieuNhap);
        }

        public async Task<IActionResult> Create()
        {
            //int maNhaCC = _context.NhaCungCap.DefaultIfEmpty().Max(p => p == null ? 0 : p.MaNhaCungCap);
            //maNhaCC += 1;
            //ViewBag.ThemMaSanPham = maNhaCC;

            ViewModelPhieuNhap phieuNhapViewModel = new ViewModelPhieuNhap
            {
                DSNhaCungCap = await _context.NhaCungCap.ToListAsync(),
                DSSanPham = await _context.SanPham.ToListAsync(),
                DSKhoNhap = await _context.KhoNhap.ToListAsync(),
                DSNhanVien = await _context.NhanVien.ToListAsync()
            };

            return View(phieuNhapViewModel);
        }



        // POST: PhieuNhap/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PhieuNhap phieuNhap, List<PhieuNhapChiTiet> phieuNhapChiTiet)
        {
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        Console.WriteLine($"Lỗi tại cai nay {key}: {error.ErrorMessage}");

                    }
                }

                ViewModelPhieuNhap phieuNhapViewModel1 = new ViewModelPhieuNhap
                {
                    DSNhaCungCap = await _context.NhaCungCap.ToListAsync(),
                    DSSanPham = await _context.SanPham.ToListAsync(),
                    DSKhoNhap = await _context.KhoNhap.ToListAsync(),
                    DSNhanVien = await _context.NhanVien.ToListAsync()
                };

                if (!phieuNhapViewModel1.DSKhoNhap.Any()) Console.WriteLine("Danh sách kho nhập rỗng!");
                if (!phieuNhapViewModel1.DSNhanVien.Any()) Console.WriteLine("Danh sách nhân viên rỗng!");
                return View(phieuNhapViewModel1);
            }

            phieuNhap.NgayNhap = DateTime.Now;
            phieuNhap.TongTien = phieuNhapChiTiet.Sum(t => t.SoLuong * t.DonGia);
            _context.PhieuNhap.Add(phieuNhap);
            _context.SaveChanges();
            int phieuNhapNhieu = (int)MathF.Abs(_context.PhieuNhapChiTiet.Count());
            Console.WriteLine($"Day la phieu nhap nhieu {phieuNhapNhieu}");
            if (phieuNhapChiTiet != null && phieuNhapChiTiet.Any())
            {
                foreach (var phieuNhapCT in phieuNhapChiTiet)
                {
                    phieuNhapNhieu += 1;
                    phieuNhapCT.MaPhieuNhapChiTiet = phieuNhapNhieu;
                    phieuNhapCT.PhieuNhap = phieuNhap;
                    phieuNhapCT.MaPhieuNhap = phieuNhap.MaPhieuNhap;
                    phieuNhapCT.TongTIen = phieuNhapCT.SoLuong * phieuNhapCT.DonGia;
                    _context.PhieuNhapChiTiet.Add(phieuNhapCT);
                    var sanPham = await _context.SanPham.FindAsync(phieuNhapCT.MaSP);
                    if (sanPham != null)
                    {
                        sanPham.TonKho += phieuNhapCT.SoLuong;
                    }
                    _context.SanPham.Update(sanPham);
                }
                _context.SaveChanges();
            }

            ViewModelPhieuNhap phieuNhapViewModel = new ViewModelPhieuNhap
            {
                DSNhaCungCap = await _context.NhaCungCap.ToListAsync(),
                DSSanPham = await _context.SanPham.ToListAsync(),
                DSKhoNhap = await _context.KhoNhap.ToListAsync(),
                DSNhanVien = await _context.NhanVien.ToListAsync()
            };

            return View(phieuNhapViewModel);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var phieuNhap = await _context.PhieuNhap
            .Include(p => p.NhaCungCap)
            .FirstOrDefaultAsync(p => p.MaPhieuNhap == id);

            if (phieuNhap == null)
            {
                return NotFound();
            }

            // Lọc danh sách chi tiết phiếu nhập chỉ lấy các mục có MaPhieuNhap khớp với phiếu nhập hiện tại
            var chiTietPhieuNhap = await _context.PhieuNhapChiTiet
                .Where(ct => ct.MaPhieuNhap == id)
                .Include(ct => ct.SanPham)
                .ToListAsync();

            // Gán danh sách chi tiết vào phiếu nhập
            phieuNhap.DSChiTietPhieuNhap = chiTietPhieuNhap;

            return View(phieuNhap);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var phieuNhap = await _context.PhieuNhap
                .Include(p => p.DSChiTietPhieuNhap)
                .FirstOrDefaultAsync(p => p.MaPhieuNhap == id);

            if (phieuNhap == null)
            {
                return NotFound();
            }

            return View(phieuNhap);
        }

        // POST: PhieuNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieuNhap = await _context.PhieuNhap
                .Include(p => p.DSChiTietPhieuNhap)
                .Include(p => p.NhaCungCap)
                .FirstOrDefaultAsync(p => p.MaPhieuNhap == id);

            if (phieuNhap == null)
            {
                return NotFound();
            }

            var chiTietPhieuNhap = await _context.PhieuNhapChiTiet
               .Where(ct => ct.MaPhieuNhap == id)
               .Include(ct => ct.SanPham)
               .ToListAsync();

            // Gán danh sách chi tiết vào phiếu nhập
            phieuNhap.DSChiTietPhieuNhap = chiTietPhieuNhap;

            // Xóa các chi tiết phiếu nhập trước
            _context.PhieuNhapChiTiet.RemoveRange(phieuNhap.DSChiTietPhieuNhap);

            // Xóa phiếu nhập
            _context.PhieuNhap.Remove(phieuNhap);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
