using System;
using System.Collections.Generic;

namespace TechShop.Models;

public partial class TChiTietSanPham
{
    public string MaChiTietSanPham { get; set; } = null!;

    public string MaSanPham { get; set; } = null!;

    public decimal KichThuoc { get; set; }

    public string MauSac { get; set; } = null!;

    public string AnhDaiDien { get; set; } = null!;

    public decimal DonGiaBan { get; set; }

    public decimal GiamGia { get; set; }

    public int SoLuongTonKho { get; set; }

    public virtual TSanPham MaSanPhamNavigation { get; set; } = null!;

    public virtual ICollection<TAnhChiTietSanPham> TAnhChiTietSanPhams { get; } = new List<TAnhChiTietSanPham>();
}
