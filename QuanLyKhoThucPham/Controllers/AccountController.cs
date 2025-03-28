using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using QuanLyKhoThucPham.Models; // Đảm bảo namespace này chính xác  
using Microsoft.AspNetCore.Authorization;

namespace QuanLyKhoThucPham.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Thêm để bảo vệ khỏi tấn công CSRF  
        public async Task<IActionResult> Login(string TaiKhoan, string MatKhau, bool GhiNho)
        {
            if (TaiKhoan == "admin" && MatKhau == "password")
            {
                // Tạo claims  
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, TaiKhoan),
                    new Claim(ClaimTypes.Role, "Admin"), // Ví dụ về role  
                };

                // Tạo identity  
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Xác thực  
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = GhiNho, // Ghi nhớ đăng nhập  
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                // Chuyển hướng đến trang home  
                return RedirectToAction("Index", "Home"); // Chuyển hướng đến HomeController/Index  
            }

            // Nếu đăng nhập không thành công  
            ModelState.AddModelError("", "Thông tin đăng nhập không hợp lệ.");
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View(); // Tạo một view AccessDenied nếu cần  
        }
    }
}