using TechShop.Models;

namespace TechShop.Repository
{
    public class LoaiSpRepository : LoaiSanPhamRepository
    {
        private readonly TechShopContext _context;
        public LoaiSpRepository(TechShopContext context)
        {
            _context = context;
        }
        public TLoaiSanPham Add(TLoaiSanPham entity)
        {
            _context.TLoaiSanPhams.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TLoaiSanPham Delete(string maloaisp)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TLoaiSanPham> GetAllLoaiSP()
        {
            return _context.TLoaiSanPhams;
        }

        public TLoaiSanPham GetLoaiSanPham(string maloaisp)
        {
            return _context.TLoaiSanPhams.Find(maloaisp);
        }

        public TLoaiSanPham Update(TLoaiSanPham entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
