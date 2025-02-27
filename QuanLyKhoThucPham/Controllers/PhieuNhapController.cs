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
            var phieuNhap = _context.PhieuNhap
                .Include(p => p.NhaCungCap)
                .Include(p=> p.NhanVien)
                .Include(p=>p.KhoHang)
                .ToList();

            foreach (var pn in phieuNhap)
            {
                Console.WriteLine($"Phiếu nhập: {pn.MaNhaCungCap}, nhà cung cấp: {pn.NhaCungCap?.TenNhaCungCap ?? "Không có nhà cung cấp"}");
            }

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
                ViewModelPhieuNhap phieuNhapViewModel1 = new ViewModelPhieuNhap
                {
                    DSNhaCungCap = await _context.NhaCungCap.ToListAsync(),
                    DSSanPham = await _context.SanPham.ToListAsync(),
                    DSKhoHang = await _context.KhoHang.ToListAsync(),
                    DSNhanVien = await _context.NhanVien.ToListAsync(),
                    PhieuNhap = phieuNhap,
                    DSChiTietPhieuNhap = phieuNhapChiTiet
                };

                return View(phieuNhapViewModel1);
            }


            phieuNhap.TongTien = phieuNhapChiTiet.Sum(t => t.SoLuong * t.DonGia);

            _context.PhieuNhap.Add(phieuNhap);
            await _context.SaveChangesAsync(); 

            if (phieuNhapChiTiet != null && phieuNhapChiTiet.Any())
            {
                foreach (var phieuNhapCT in phieuNhapChiTiet)
                {
                    phieuNhapCT.MaPhieuNhap = phieuNhap.MaPhieuNhap; 
                    phieuNhapCT.TongTIen = phieuNhapCT.SoLuong * phieuNhapCT.DonGia;

                    var sanPham = await _context.SanPham.FindAsync(phieuNhapCT.MaSP);
                    var khoHang = await _context.KhoHang.FindAsync(phieuNhap.MaKho);

                    if (khoHang != null)
                    {
                        if (khoHang.soluongtrong - phieuNhapCT.SoLuong < 0)
                        {
                            ModelState.AddModelError("", "Kho hàng không đủ chỗ trống!");
                            return View(phieuNhap);
                        }
                        khoHang.soluongtrong -= phieuNhapCT.SoLuong;
                    }

                    if (sanPham != null)
                    {
                        sanPham.SoLuong += phieuNhapCT.SoLuong;
                    }

                    _context.PhieuNhapChiTiet.Add(phieuNhapCT);
                    _context.SanPham.Update(sanPham);
                    _context.KhoHang.Update(khoHang);
                }
                await _context.SaveChangesAsync(); 
            }

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Detail(int maPN)
        {
            var phieuNhap = await _context.PhieuNhap
            .Include(p => p.NhaCungCap)
            .Include(p => p.NhanVien)
            .Include(p => p.KhoHang)
            .FirstOrDefaultAsync(p => p.MaPhieuNhap == maPN);

            if (phieuNhap == null)
            {
                return NotFound();
            }
        
            var chiTietPhieuNhap = await _context.PhieuNhapChiTiet
                .Where(ct => ct.MaPhieuNhap == maPN)
                .Include(ct => ct.SanPham)
                .ToListAsync();

            phieuNhap.DSChiTietPhieuNhap = chiTietPhieuNhap;

            return View(phieuNhap);
        }

        public async Task<IActionResult> Delete(int maPN)
        {
            var phieuNhap = await _context.PhieuNhap
                .Include(p => p.NhaCungCap)
                .Include(p => p.NhanVien)
                .Include(p => p.KhoHang)
                .Include(p => p.DSChiTietPhieuNhap)
                    .ThenInclude(p=>p.SanPham)
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
             .FirstOrDefaultAsync(p => p.MaPhieuNhap == maPN);

            if (phieuNhap == null)
            {
                return NotFound();
            }

            var chiTietPhieuNhap = await _context.PhieuNhapChiTiet
               .Where(ct => ct.MaPhieuNhap == maPN)
               .Include(ct => ct.SanPham)
               .ToListAsync();
         

            phieuNhap.DSChiTietPhieuNhap = chiTietPhieuNhap;
            if(chiTietPhieuNhap != null) {
                foreach (var ct in chiTietPhieuNhap)
                {

                    _context.PhieuNhapChiTiet.Remove(ct);
                }
            }
            


            _context.PhieuNhap.Remove(phieuNhap);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
