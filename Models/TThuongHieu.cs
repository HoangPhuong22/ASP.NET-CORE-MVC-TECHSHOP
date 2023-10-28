using System;
using System.Collections.Generic;

namespace TechShop.Models;

public partial class TThuongHieu
{
    public string MaThuongHieu { get; set; } = null!;

    public string TenThuongHieu { get; set; } = null!;

    public virtual ICollection<TSanPham> TSanPhams { get; } = new List<TSanPham>();
}
