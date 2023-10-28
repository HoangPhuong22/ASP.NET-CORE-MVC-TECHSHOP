using System;
using System.Collections.Generic;

namespace TechShop.Models;

public partial class TLoaiSanPham
{
    public string MaLoai { get; set; } = null!;

    public string TenLoai { get; set; } = null!;

    public virtual ICollection<TSanPham> TSanPhams { get; } = new List<TSanPham>();
}
