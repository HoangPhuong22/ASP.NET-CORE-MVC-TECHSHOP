using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TechShop.Models;

public partial class TechShopContext : DbContext
{
    public TechShopContext()
    {
    }

    public TechShopContext(DbContextOptions<TechShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TAnhChiTietSanPham> TAnhChiTietSanPhams { get; set; }

    public virtual DbSet<TChatLieu> TChatLieus { get; set; }

    public virtual DbSet<TChiTietHdb> TChiTietHdbs { get; set; }

    public virtual DbSet<TChiTietSanPham> TChiTietSanPhams { get; set; }

    public virtual DbSet<THoaDonBan> THoaDonBans { get; set; }

    public virtual DbSet<TKhachHang> TKhachHangs { get; set; }

    public virtual DbSet<TLoaiSanPham> TLoaiSanPhams { get; set; }

    public virtual DbSet<TQuocGium> TQuocGia { get; set; }

    public virtual DbSet<TSanPham> TSanPhams { get; set; }

    public virtual DbSet<TTaiKhoan> TTaiKhoans { get; set; }

    public virtual DbSet<TThuongHieu> TThuongHieus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HOANGPHUONGDEPT\\SQLEXPRESS;Initial Catalog=TechShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TAnhChiTietSanPham>(entity =>
        {
            entity.HasKey(e => e.TenFileAnh).HasName("PK__tAnhChiT__8E7F3621A0D88C7B");

            entity.ToTable("tAnhChiTietSanPham");

            entity.Property(e => e.TenFileAnh).HasMaxLength(100);
            entity.Property(e => e.MaChiTietSanPham).HasMaxLength(100);

            entity.HasOne(d => d.MaChiTietSanPhamNavigation).WithMany(p => p.TAnhChiTietSanPhams)
                .HasForeignKey(d => d.MaChiTietSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaChiTietSanPham");
        });

        modelBuilder.Entity<TChatLieu>(entity =>
        {
            entity.HasKey(e => e.MaChatLieu).HasName("PK__tChatLie__453995BC037C4B42");

            entity.ToTable("tChatLieu");

            entity.Property(e => e.MaChatLieu).HasMaxLength(100);
            entity.Property(e => e.TenChatLieu).HasMaxLength(500);
        });

        modelBuilder.Entity<TChiTietHdb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tChiTietHDB");

            entity.Property(e => e.DonGiaBan).HasColumnType("money");
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.GiamGia).HasColumnType("money");
            entity.Property(e => e.MaChiTietSanPham).HasMaxLength(100);
            entity.Property(e => e.MaHoaDon).HasMaxLength(100);

            entity.HasOne(d => d.MaChiTietSanPhamNavigation).WithMany()
                .HasForeignKey(d => d.MaChiTietSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tChiTietH__MaChi__628FA481");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany()
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tChiTietH__MaHoa__6383C8BA");
        });

        modelBuilder.Entity<TChiTietSanPham>(entity =>
        {
            entity.HasKey(e => e.MaChiTietSanPham).HasName("PK__tChiTiet__A6B023B070CC30BC");

            entity.ToTable("tChiTietSanPham");

            entity.Property(e => e.MaChiTietSanPham).HasMaxLength(100);
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DonGiaBan).HasColumnType("money");
            entity.Property(e => e.GiamGia).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.KichThuoc).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.MaSanPham).HasMaxLength(100);
            entity.Property(e => e.MauSac).HasMaxLength(100);

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.TChiTietSanPhams)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tChiTietS__MaSan__571DF1D5");
        });

        modelBuilder.Entity<THoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__tHoaDonB__835ED13B3B947932");

            entity.ToTable("tHoaDonBan");

            entity.Property(e => e.MaHoaDon).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.GiamGia).HasColumnType("money");
            entity.Property(e => e.MaKhachHang).HasMaxLength(100);
            entity.Property(e => e.MaSoThue).HasMaxLength(100);
            entity.Property(e => e.NgayLap).HasColumnType("datetime");
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(1000);
            entity.Property(e => e.TongTien).HasColumnType("money");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.THoaDonBans)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tHoaDonBa__MaKha__60A75C0F");
        });

        modelBuilder.Entity<TKhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__tKhachHa__88D2F0E531D158C3");

            entity.ToTable("tKhachHang");

            entity.Property(e => e.MaKhachHang).HasMaxLength(100);
            entity.Property(e => e.AnhKhachHang).HasMaxLength(100);
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.SoDienThoai).HasMaxLength(100);
            entity.Property(e => e.TenKhachHang).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.TKhachHangs)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tKhachHan__UserN__5DCAEF64");
        });

        modelBuilder.Entity<TLoaiSanPham>(entity =>
        {
            entity.HasKey(e => e.MaLoai).HasName("PK__tLoaiSan__730A57592276C7B3");

            entity.ToTable("tLoaiSanPham");

            entity.Property(e => e.MaLoai).HasMaxLength(100);
            entity.Property(e => e.TenLoai).HasMaxLength(500);
        });

        modelBuilder.Entity<TQuocGium>(entity =>
        {
            entity.HasKey(e => e.MaQuocGia).HasName("PK__tQuocGia__30D69ACB1FF837B1");

            entity.ToTable("tQuocGia");

            entity.Property(e => e.MaQuocGia).HasMaxLength(100);
            entity.Property(e => e.TenQuocGia).HasMaxLength(100);
        });

        modelBuilder.Entity<TSanPham>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("PK__tSanPham__FAC7442DAFDDDEC6");

            entity.ToTable("tSanPham");

            entity.Property(e => e.MaSanPham).HasMaxLength(100);
            entity.Property(e => e.AnhSanPham).HasMaxLength(1000);
            entity.Property(e => e.DoDay).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.GiaLonNhat).HasColumnType("money");
            entity.Property(e => e.GiaNhoNhat).HasColumnType("money");
            entity.Property(e => e.HanBaoHanh).HasColumnType("datetime");
            entity.Property(e => e.KhoiLuong).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaChatLieu).HasMaxLength(100);
            entity.Property(e => e.MaLoaiSanPham).HasMaxLength(100);
            entity.Property(e => e.MaQuocGia).HasMaxLength(100);
            entity.Property(e => e.MaThuongHieu).HasMaxLength(100);
            entity.Property(e => e.TenSanPham).HasMaxLength(500);

            entity.HasOne(d => d.MaChatLieuNavigation).WithMany(p => p.TSanPhams)
                .HasForeignKey(d => d.MaChatLieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tSanPham__MaChat__52593CB8");

            entity.HasOne(d => d.MaLoaiSanPhamNavigation).WithMany(p => p.TSanPhams)
                .HasForeignKey(d => d.MaLoaiSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tSanPham__MaLoai__5165187F");

            entity.HasOne(d => d.MaQuocGiaNavigation).WithMany(p => p.TSanPhams)
                .HasForeignKey(d => d.MaQuocGia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tSanPham__MaQuoc__5441852A");

            entity.HasOne(d => d.MaThuongHieuNavigation).WithMany(p => p.TSanPhams)
                .HasForeignKey(d => d.MaThuongHieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tSanPham__MaThuo__534D60F1");
        });

        modelBuilder.Entity<TTaiKhoan>(entity =>
        {
            entity.HasKey(e => e.UserName).HasName("PK__tTaiKhoa__C9F284576718EF5E");

            entity.ToTable("tTaiKhoan");

            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.LoaiUser).HasMaxLength(100);
            entity.Property(e => e.PassWord)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TThuongHieu>(entity =>
        {
            entity.HasKey(e => e.MaThuongHieu).HasName("PK__tThuongH__A3733E2C4A588FE0");

            entity.ToTable("tThuongHieu");

            entity.Property(e => e.MaThuongHieu).HasMaxLength(100);
            entity.Property(e => e.TenThuongHieu).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
