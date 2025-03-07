using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using QuanLyKhoThucPham.Data;
using QuanLyKhoThucPham.Models;
using System.Diagnostics;

namespace QuanLyKhoThucPham.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private QuanLyKhoThucPhamContext _context;

        public HomeController(ILogger<HomeController> logger, QuanLyKhoThucPhamContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["SoLuongSanPham"] = _context.SanPham.Count();
            ViewData["SoLuongKho"] = _context.KhoHang.Count();
            ViewData["SoLuongNhaCungCap"] = _context.NhaCungCap.Count();
            ViewData["SoLuongNhanVien"] = _context.NhanVien.Count();
            ViewData["SoLuongPhieuNhap"] = _context.PhieuNhap.Count();
            ViewData["SoLuongPhieuXuat"] = _context.PhieuXuat.Count();
            ViewData["SoLuongKhachHang"] = _context.KhachHang.Count();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
