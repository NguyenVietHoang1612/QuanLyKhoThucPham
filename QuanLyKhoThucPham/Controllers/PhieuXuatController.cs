using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoThucPham.Models.View_Model;
using QuanLyKhoThucPham.Models;
using QuanLyKhoThucPham.Data;

namespace QuanLyKhoThucPham.Controllers
{
    public class PhieuXuatController : Controller
    {
        private readonly QuanLyKhoThucPhamContext _context;
        public PhieuXuatController(QuanLyKhoThucPhamContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var phieuXuat = _context.PhieuXuat
                .Include(p => p.KhachHang)
                .Include(p => p.NhanVien)
                .Include(p => p.KhoHang)
                .ToList();
            return View(phieuXuat);
    
        }

        public async Task<IActionResult> Create()
        {
            ViewModelPhieuXuat phieuXuatViewModel = new ViewModelPhieuXuat
            {
                DSKhachHang = await _context.KhachHang.ToListAsync(),
                DSSanPham = await _context.SanPham.ToListAsync(),
                DSKhoHang = await _context.KhoHang.ToListAsync(),
                DSNhanVien = await _context.NhanVien.ToListAsync()

            };
            if(phieuXuatViewModel.DSKhachHang != null) 
            {
                Console.WriteLine($"Khách hàng: {phieuXuatViewModel.DSKhachHang}");
                     
            } 
            else
            {
                Console.WriteLine("Không có khách hàng");
            } 
            return View(phieuXuatViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PhieuXuatModel phieuXuat, List<PhieuXuatChiTietModel> phieuXuatChiTiet)
        {
            if (!ModelState.IsValid)
            {
                ViewModelPhieuXuat phieuXuatViewModel1 = new ViewModelPhieuXuat
                {
                    DSKhachHang = await _context.KhachHang.ToListAsync(),
                    DSSanPham = await _context.SanPham.ToListAsync(),
                    DSKhoHang = await _context.KhoHang.ToListAsync(),
                    DSNhanVien = await _context.NhanVien.ToListAsync(),
                };

                return View(phieuXuatViewModel1);
            }


            phieuXuat.TongTien = phieuXuatChiTiet.Sum(t => t.SoLuong * t.DonGia);

            _context.PhieuXuat.Add(phieuXuat);

            await _context.SaveChangesAsync();

            if (phieuXuatChiTiet != null && phieuXuatChiTiet.Any())
            {
                foreach (var phieuXuatCT in phieuXuatChiTiet)
                {
                    phieuXuatCT.MaPhieuXuat = phieuXuat.MaPhieuXuat;
                    phieuXuatCT.TongTIen = phieuXuatCT.SoLuong * phieuXuatCT.DonGia;

                    var sanPham = await _context.SanPham.FindAsync(phieuXuatCT.MaSP);
                    var khoHang = await _context.KhoHang.FindAsync(phieuXuat.MaKho);

                    if(khoHang != null)
                    {
                        if (khoHang.soluongtrong + phieuXuatCT.SoLuong > khoHang.soluongtong)
                        {
                            ModelState.AddModelError("", "Kho hàng đã đủ chỗ!");
                            return View(phieuXuat);
                        }
                        khoHang.soluongtrong += phieuXuatCT.SoLuong;
                    }

                    if (sanPham != null)
                    {
                        if(sanPham.SoLuong - phieuXuatCT.SoLuong >= 0)
                        {
                            sanPham.SoLuong -= phieuXuatCT.SoLuong;
                        }
                        else
                        {

                        }
                    }

                    _context.PhieuXuatChiTiet.Add(phieuXuatCT);
                    _context.KhoHang.Update(khoHang);
                    _context.SanPham.Update(sanPham);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int maPX)
        {
            var phieuXuat = await _context.PhieuXuat
            .Include(p => p.KhachHang)
            .Include(p => p.NhanVien)
            .Include(p => p.KhoHang)
            .FirstOrDefaultAsync(p => p.MaPhieuXuat == maPX);

            if (phieuXuat == null)
            {
                return NotFound();
            }

            var chiTietPhieuXuat = await _context.PhieuXuatChiTiet
                .Where(ct => ct.MaPhieuXuat == maPX)
                .Include(ct => ct.SanPham)
                .ToListAsync();

            phieuXuat.DSChiTietPhieuXuat = chiTietPhieuXuat;

            return View(phieuXuat);
        }

    }
}
