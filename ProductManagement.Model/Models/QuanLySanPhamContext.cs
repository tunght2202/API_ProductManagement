using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProductManagement.Model.Models
{
    public partial class QuanLySanPhamContext : DbContext
    {
        public QuanLySanPhamContext()
        {
        }

        public QuanLySanPhamContext(DbContextOptions<QuanLySanPhamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.ToTable("SanPham");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Gia)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("gia");

                entity.Property(e => e.MoTa)
                    .HasColumnType("text")
                    .HasColumnName("mo_ta");

                entity.Property(e => e.NgayCapNhat)
                    .HasColumnType("datetime")
                    .HasColumnName("ngay_cap_nhat");

                entity.Property(e => e.NgayTao)
                    .HasColumnType("datetime")
                    .HasColumnName("ngay_tao");

                entity.Property(e => e.SoLuong)
                    .HasColumnName("so_luong")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TenSanPham)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ten_san_pham");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
