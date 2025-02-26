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
        private readonly QuanLyKhoThucPhamContext _context;

        public PhieuNhapController(QuanLyKhoThucPhamContext context)
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
            ViewModelPhieuNhap phieuNhapViewModel = new ViewModelPhieuNhap
            {
                DSNhaCungCap = await _context.NhaCungCap.ToListAsync(),
                DSSanPham = await _context.SanPham.ToListAsync(),
                DSKhoHang = await _context.KhoHang.ToListAsync(),
                DSNhanVien = await _context.NhanVien.ToListAsync()
            };

            return View(phieuNhapViewModel);
        }



        // POST: PhieuNhap/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PhieuNhapModel phieuNhap, List<PhieuNhapChiTietModel> phieuNhapChiTiet)
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
                    DSKhoHang = await _context.KhoHang.ToListAsync(),
                    DSNhanVien = await _context.NhanVien.ToListAsync()
                };

                if (!phieuNhapViewModel1.DSKhoHang.Any()) Console.WriteLine("Danh sách kho nhập rỗng!");
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
                        sanPham.SoLuong += phieuNhapCT.SoLuong;
                    }
                    _context.SanPham.Update(sanPham);
                }
                _context.SaveChanges();
            }

            

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int maPN)
        {
            var phieuNhap = await _context.PhieuNhap
            .Include(p => p.NhaCungCap)
            .FirstOrDefaultAsync(p => p.MaPhieuNhap == maPN);

            if (phieuNhap == null)
            {
                return NotFound();
            }

            // Lọc danh sách chi tiết phiếu nhập chỉ lấy các mục có MaPhieuNhap khớp với phiếu nhập hiện tại
            var chiTietPhieuNhap = await _context.PhieuNhapChiTiet
                .Where(ct => ct.MaPhieuNhap == maPN)
                .Include(ct => ct.SanPham)
                .ToListAsync();

            // Gán danh sách chi tiết vào phiếu nhập
            phieuNhap.DSChiTietPhieuNhap = chiTietPhieuNhap;

            return View(phieuNhap);
        }

        public async Task<IActionResult> Delete(int maPN)
        {
            var phieuNhap = await _context.PhieuNhap
                .Include(p => p.DSChiTietPhieuNhap)
                .FirstOrDefaultAsync(p => p.MaPhieuNhap == maPN);

            if (phieuNhap == null)
            {
                return NotFound();
            }

            return View(phieuNhap);
        }

        // POST: PhieuNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int maPN)
        {
            var phieuNhap = await _context.PhieuNhap
         .Include(p => p.DSChiTietPhieuNhap)
         .FirstOrDefaultAsync(p => p.MaPhieuNhap == maPN);

            if (phieuNhap == null)
            {
                return NotFound();
            }

            var chiTietPhieuNhap = await _context.PhieuNhapChiTiet
               .Where(ct => ct.MaPhieuNhap == maPN)
               .Include(ct => ct.SanPham)
               .ToListAsync();

            // Gán danh sách chi tiết vào phiếu nhập
            phieuNhap.DSChiTietPhieuNhap = chiTietPhieuNhap;

            foreach (var ct in chiTietPhieuNhap)
            {
                _context.PhieuNhapChiTiet.Remove(ct);
            }


            // Xóa phiếu nhập
            _context.PhieuNhap.Remove(phieuNhap);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
