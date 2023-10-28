using System;
using System.Collections.Generic;

namespace TechShop.Models;

public partial class TTaiKhoan
{
    public string UserName { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public string LoaiUser { get; set; } = null!;

    public virtual ICollection<TKhachHang> TKhachHangs { get; } = new List<TKhachHang>();
}
