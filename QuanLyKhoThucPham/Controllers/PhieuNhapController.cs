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

        public async Task<IActionResult> Index(int? pageNumber, string searchString, DateTime? searchDate)
        {
            var phieuNhap = _context.PhieuNhap
                .Include(p => p.NhaCungCap)
                .Include(p => p.NhanVien)
                .Include(p => p.KhoHang)
                .AsNoTracking();

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentDateFilter"] = searchDate?.ToString("yyyy-MM-dd"); 

            if (!string.IsNullOrEmpty(searchString))
            {
                phieuNhap = phieuNhap.Where(s => s.MaPhieuNhap.ToString().ToLower().Contains(searchString));
            }

            if (searchDate.HasValue)
            {
                phieuNhap = phieuNhap.Where(s => s.NgayNhap.Date == searchDate.Value.Date);
            }

            int pageSize = 3;

            var phieuNhapPage = await PaginatedList<PhieuNhapModel>.CreateAsync(phieuNhap, pageNumber ?? 1, pageSize);

            return View(phieuNhapPage);
        }


        private async Task<ViewModelPhieuNhap> GetPhieuNhapViewModel()
        {
            return new ViewModelPhieuNhap
            {
                DSNhaCungCap = await _context.NhaCungCap.ToListAsync(),
                DSSanPham = await _context.SanPham.ToListAsync(),
                DSKhoHang = await _context.KhoHang.ToListAsync(),
                DSNhanVien = await _context.NhanVien.ToListAsync()
            };
        }

        public async Task<IActionResult> Create()
        {
            var phieuNhapViewModel = await GetPhieuNhapViewModel();

            return View(phieuNhapViewModel);
        }



        // POST: PhieuNhap/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PhieuNhapModel phieuNhap, List<PhieuNhapChiTietModel> phieuNhapChiTiet)
        {
            if (!ModelState.IsValid)
            {

                var phieuNhapViewModel = await GetPhieuNhapViewModel();
                phieuNhapViewModel.PhieuNhap = phieuNhap;
                phieuNhapViewModel.DSChiTietPhieuNhap = phieuNhapChiTiet;


                return View(phieuNhapViewModel);
            }


            phieuNhap.TongTien = phieuNhapChiTiet.Sum(t => t.SoLuong * t.DonGia);

            _context.PhieuNhap.Add(phieuNhap);
            await _context.SaveChangesAsync(); 

            if (phieuNhapChiTiet != null)
            {
                foreach (var phieuNhapCT in phieuNhapChiTiet)
                {
                    phieuNhapCT.MaPhieuNhap = phieuNhap.MaPhieuNhap; 
                    phieuNhapCT.TongTIen = phieuNhapCT.SoLuong * phieuNhapCT.DonGia;

                    var sanPham = await _context.SanPham.FindAsync(phieuNhapCT.MaSP);
                    var khoHang = await _context.KhoHang.FindAsync(phieuNhap.MaKho);


                    if (khoHang.soluongtrong - phieuNhapCT.SoLuong < 0)
                    {
                        ModelState.AddModelError("", $"Kho hàng '{khoHang.TenKho}' không đủ chỗ.");
                        var phieuNhapViewModel = await GetPhieuNhapViewModel();
                        return View(phieuNhapViewModel);
                    }

                    khoHang.soluongtrong -= phieuNhapCT.SoLuong;

                    if (sanPham != null)
                    {
                        sanPham.SoLuong += phieuNhapCT.SoLuong;
                    }
                    else
                    {
                        ModelState.AddModelError("", $"Sản phẩm '{sanPham.TenSP}' không tồn tại.");
                        var phieuNhapViewModel = await GetPhieuNhapViewModel();
                        return View(phieuNhapViewModel);
                    }

                    _context.PhieuNhapChiTiet.Add(phieuNhapCT);
                    _context.KhoHang.Update(khoHang);
                    _context.SanPham.Update(sanPham);
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

        //Get
        public async Task<IActionResult> Delete(int maPN)
        {
            var phieuNhap = await _context.PhieuNhap
                .Include(p => p.NhaCungCap)
                .Include(p => p.NhanVien)
                .Include(p => p.KhoHang)
                .Include(p => p.DSChiTietPhieuNhap)
                    .ThenInclude(p => p.SanPham)
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
               .ToListAsync();
              
            _context.PhieuNhapChiTiet.RemoveRange(chiTietPhieuNhap);
            _context.PhieuNhap.Remove(phieuNhap);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
