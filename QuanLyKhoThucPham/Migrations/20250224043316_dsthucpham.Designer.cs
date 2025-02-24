﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyKhoThucPham.Data;

#nullable disable

namespace QuanLyKhoThucPham.Migrations
{
    [DbContext(typeof(QuanLyKhoThucPhamContext))]
    [Migration("20250224043316_dsthucpham")]
    partial class dsthucpham
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuanLyKhoThucPham.Models.dskhohangModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("soluongtong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("soluongtrong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("dskhohangModel");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.dsthucpham", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("gia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("hsd")
                        .HasColumnType("datetime2");

                    b.Property<int>("khoID")
                        .HasColumnType("int");

                    b.Property<string>("mota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ngaysx")
                        .HasColumnType("datetime2");

                    b.Property<string>("nhasanxuat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("soluong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tenSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("khoID");

                    b.ToTable("dsthucpham");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.dsthucpham", b =>
                {
                    b.HasOne("QuanLyKhoThucPham.Models.dskhohangModel", "kho")
                        .WithMany()
                        .HasForeignKey("khoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kho");
                });
#pragma warning restore 612, 618
        }
    }
}
