using System;
using System.Collections.Generic;

namespace TechShop.Models;

public partial class TSanPham
{
    public string MaSanPham { get; set; } = null!;

    public string TenSanPham { get; set; } = null!;

    public DateTime HanBaoHanh { get; set; }

    public string? AnhSanPham { get; set; }

    public decimal GiaNhoNhat { get; set; }

    public decimal KhoiLuong { get; set; }

    public decimal DoDay { get; set; }

    public decimal GiaLonNhat { get; set; }

    public string MaLoaiSanPham { get; set; } = null!;

    public string MaChatLieu { get; set; } = null!;

    public string MaThuongHieu { get; set; } = null!;

    public string MaQuocGia { get; set; } = null!;
    public virtual TChatLieu MaChatLieuNavigation { get; set; } = null!;

    public virtual TLoaiSanPham MaLoaiSanPhamNavigation { get; set; } = null!;

    public virtual TQuocGium MaQuocGiaNavigation { get; set; } = null!;

    public virtual TThuongHieu MaThuongHieuNavigation { get; set; } = null!;
    
    public virtual ICollection<TChiTietSanPham> TChiTietSanPhams { get; } = new List<TChiTietSanPham>();
}
