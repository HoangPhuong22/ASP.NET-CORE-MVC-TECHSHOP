using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            ViewBag.ActivePage = "Product";
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
        public IActionResult SearchByPrice(string[] priceRanges, int? page)
        {
            int pageSize = 9;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            PagedList<TSanPham> productList = null;

            if (priceRanges != null && priceRanges.Length > 0)
            {
                var decimalPriceRanges = new List<decimal>();

                if (priceRanges.Contains("all"))
                {
                    // Xử lý tất cả giá
                    decimalPriceRanges.Add(0); // Đặt giá trị tùy ý cho tất cả giá

                    var t = db.TSanPhams.AsNoTracking().Where(p => decimalPriceRanges.Contains(p.GiaLonNhat)).OrderBy(X => X.TenSanPham);
                    productList = new PagedList<TSanPham>(t, pageNumber, pageSize);
                    return View(productList);
                }

                foreach (string range in priceRanges)
                {
                    if (decimal.TryParse(range, out decimal price))
                    {
                        decimalPriceRanges.Add(price);
                    }
                    else
                    {
                        // Xử lý lỗi cho các trường hợp khác
                        // return hoặc thực hiện xử lý lỗi
                    }
                }

                var filteredProducts = db.TSanPhams.AsNoTracking().Where(p => decimalPriceRanges.Contains(p.GiaLonNhat)).OrderBy(X => X.TenSanPham);
                productList = new PagedList<TSanPham>(filteredProducts, pageNumber, pageSize);
            }
            else
            {
                // Xử lý trường hợp nếu không có giá trị được chọn (không check chọn)
                // Ở đây có thể trả về toàn bộ sản phẩm hoặc thực hiện xử lý khác tùy ý
                var allProducts = db.TSanPhams;
                productList = new PagedList<TSanPham>(allProducts, pageNumber, pageSize);
            }

            return View(productList);
        }


    }
}
