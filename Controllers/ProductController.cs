using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechShop.Models;
using TechShop.ViewModels;
using X.PagedList;

namespace TechShop.Controllers
{
    public class ProductController : Controller
    {
        TechShopContext db = new TechShopContext();
        public IActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber = page==null||page < 0 ? 1 : page.Value;
            var listSanPham = db.TSanPhams.AsNoTracking().OrderBy(X=>X.TenSanPham);

            PagedList<TSanPham> lst = new PagedList<TSanPham>(listSanPham, pageNumber, pageSize);
            return View(lst);
        }
        public IActionResult SanPhamTheoLoai(String maloai, int? page)
        {
            int pageSize = 9;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listSanPham = db.TSanPhams.AsNoTracking().Where
                (x=>x.MaLoaiSanPham == maloai).OrderBy(X => X.TenSanPham);

            PagedList<TSanPham> lst = new PagedList<TSanPham>(listSanPham, pageNumber, pageSize);
            ViewBag.maloai = maloai;
            return View(lst);
        }
        public IActionResult ProductDetail(string maSP)
        {
            var sanPham = db.TSanPhams.SingleOrDefault(x => x.MaSanPham == maSP);
            if (sanPham == null)
            {
                return NotFound(); // Hoặc thực hiện xử lý cho trường hợp không tìm thấy sản phẩm
            }

            var productDetailViewModel = new ProductDetailViewModel
            {
                sanpham = sanPham
            };
            return View(productDetailViewModel);
        }

        public IActionResult Search(string searchText, int? page)
        {
            int pageSize = 9;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var products = db.TSanPhams.AsNoTracking().Where(p => p.TenSanPham.Contains(searchText)).OrderBy(X => X.TenSanPham);
            PagedList<TSanPham> lst = new PagedList<TSanPham>(products, pageNumber, pageSize);
            // Trả về view với danh sách sản phẩm tìm thấy
            return View(lst);
        }

    }
}
