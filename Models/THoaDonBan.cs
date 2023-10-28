using System;
using System.Collections.Generic;

namespace TechShop.Models;

public partial class THoaDonBan
{
    public string MaHoaDon { get; set; } = null!;

    public DateTime NgayLap { get; set; }

    public string MaKhachHang { get; set; } = null!;

    public decimal TongTien { get; set; }

    public decimal GiamGia { get; set; }

    public string PhuongThucThanhToan { get; set; } = null!;

    public string MaSoThue { get; set; } = null!;

    public string GhiChu { get; set; } = null!;

    public virtual TKhachHang MaKhachHangNavigation { get; set; } = null!;
}
