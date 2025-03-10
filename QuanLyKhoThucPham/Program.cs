using Microsoft.EntityFrameworkCore;
using QuanLyKhoThucPham.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QuanLyKhoThucPhamContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuanLyKhoThucPhamContext") ?? throw new InvalidOperationException("Connection string 'QuanLyKhoThucPhamContext' not found.")));



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
