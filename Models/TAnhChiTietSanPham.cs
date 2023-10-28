using System;
using System.Collections.Generic;

namespace TechShop.Models;

public partial class TAnhChiTietSanPham
{
    public string MaChiTietSanPham { get; set; } = null!;

    public string TenFileAnh { get; set; } = null!;

    public virtual TChiTietSanPham MaChiTietSanPhamNavigation { get; set; } = null!;
}
