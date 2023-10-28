using TechShop.Models;

namespace TechShop.Repository
{
    public interface LoaiSanPhamRepository
    {
        TLoaiSanPham Add(TLoaiSanPham entity);
        TLoaiSanPham Update(TLoaiSanPham entity);
        TLoaiSanPham Delete(String maloaisp);
        TLoaiSanPham GetLoaiSanPham(String maloaisp);
        IEnumerable<TLoaiSanPham> GetAllLoaiSP();
    }
}
