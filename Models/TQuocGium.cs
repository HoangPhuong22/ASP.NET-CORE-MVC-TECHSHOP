using System;
using System.Collections.Generic;

namespace TechShop.Models;

public partial class TQuocGium
{
    public string MaQuocGia { get; set; } = null!;

    public string? TenQuocGia { get; set; }

    public virtual ICollection<TSanPham> TSanPhams { get; } = new List<TSanPham>();
}
