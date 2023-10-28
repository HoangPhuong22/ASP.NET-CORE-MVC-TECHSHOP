using System;
using System.Collections.Generic;

namespace TechShop.Models;

public partial class TKhachHang
{
    public string MaKhachHang { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string TenKhachHang { get; set; } = null!;

    public DateTime NgaySinh { get; set; }

    public string SoDienThoai { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string? AnhKhachHang { get; set; }

    public virtual ICollection<THoaDonBan> THoaDonBans { get; } = new List<THoaDonBan>();

    public virtual TTaiKhoan UserNameNavigation { get; set; } = null!;
}
