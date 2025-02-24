﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoThucPham.Models;
using QuanLyKhoThucPham.Models;

namespace QuanLyKhoThucPham.Data
{
    public class QuanLyKhoThucPhamContext : DbContext
    {
        public QuanLyKhoThucPhamContext (DbContextOptions<QuanLyKhoThucPhamContext> options)
            : base(options)
        {
        }

        public DbSet<QuanLyKhoThucPham.Models.Quanlykhachhang> Quanlykhachhang { get; set; } = default!;

        public DbSet<QuanLyKhoThucPham.Models.NhaCungCap>? NhaCungCap { get; set; }
    }
}
