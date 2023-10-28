using System;
using System.Collections.Generic;

namespace TechShop.Models;

public partial class TChiTietHdb
{
    public string MaHoaDon { get; set; } = null!;

    public string MaChiTietSanPham { get; set; } = null!;

    public int SoLuongBan { get; set; }

    public decimal DonGiaBan { get; set; }

    public decimal GiamGia { get; set; }

    public string GhiChu { get; set; } = null!;

    public virtual TChiTietSanPham MaChiTietSanPhamNavigation { get; set; } = null!;

    public virtual THoaDonBan MaHoaDonNavigation { get; set; } = null!;
}
