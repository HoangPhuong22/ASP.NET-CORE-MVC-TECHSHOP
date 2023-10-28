using System;
using System.Collections.Generic;

namespace TechShop.Models;

public partial class TChatLieu
{
    public string MaChatLieu { get; set; } = null!;

    public string TenChatLieu { get; set; } = null!;

    public virtual ICollection<TSanPham> TSanPhams { get; } = new List<TSanPham>();
}
