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
            TempData["SearchText"] = searchText;
            int pageSize = 9;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var products = db.TSanPhams.AsNoTracking().Where(p => p.TenSanPham.Contains(searchText)).OrderBy(X => X.TenSanPham);
            PagedList<TSanPham> lst = new PagedList<TSanPham>(products, pageNumber, pageSize);
            // Trả về view với danh sách sản phẩm tìm thấy
            return View(lst);
        }
        public IActionResult SearchByPrice(string[] priceRanges, int? page)
        {
            TempData["PriceRanges"] = priceRanges;
            int pageSize = 9;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            if (priceRanges != null && priceRanges.Length > 0)
            {
                var priceRangeFilters = priceRanges.Select(r =>
                {
                    if (r == "all")
                    {
                        // Trường hợp chọn "All Price", không áp dụng bất kỳ điều kiện nào.
                        return (0, 100000000000);
                    }

                    var range = r.Split('-');
                    if (range.Length != 2)
                    {
                        return (decimal.MinValue, decimal.MaxValue);
                    }

                    if (decimal.TryParse(range[0], out var minPrice) && decimal.TryParse(range[1], out var maxPrice))
                    {
                        return (minPrice, maxPrice);
                    }

                    return (decimal.MinValue, decimal.MaxValue);
                }).ToArray();

                var query = db.TSanPhams.AsNoTracking();
                var r = query.ToList(); // Chuyển dữ liệu sang danh sách
                var filteredProducts = r.Where(p =>
                    priceRangeFilters.Any(range =>
                        p.GiaLonNhat >= range.Item1 && p.GiaLonNhat <= range.Item2))
                    .OrderBy(p => p.TenSanPham);

                PagedList<TSanPham> t = new PagedList<TSanPham>(filteredProducts, pageNumber, pageSize);

                return View(t);
            }

            var allProducts = db.TSanPhams;
            PagedList<TSanPham> lst = new PagedList<TSanPham>(allProducts, pageNumber, pageSize);

            return View(lst);
        }
    }
}
