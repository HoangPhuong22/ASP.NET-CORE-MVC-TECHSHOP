using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechShop.Models;
using X.PagedList;

namespace TechShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/tQuanliChiTietSanPham")]
    public class tQuanLiChiTietSanPhamController : Controller
    {
        TechShopContext db = new TechShopContext();
        [Route("tChiTietSanPham")]
        public IActionResult tChiTietSanPham(int? page)
        {
            int pagesize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lsttmp = db.TChiTietSanPhams.AsNoTracking().OrderBy(x => x.MaChiTietSanPham);
            PagedList<TChiTietSanPham> lst = new PagedList<TChiTietSanPham>(lsttmp, pageNumber, pagesize);
            return View(lst);
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            ViewBag.MaSanPham = new SelectList(db.TSanPhams, "MaSanPham", "TenSanPham");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public IActionResult Create(TChiTietSanPham t)
        {
            ModelState.Remove("MaSanPhamNavigation");
            if (ModelState.IsValid)
            {
                db.Add(t);
                db.SaveChanges();
                return RedirectToAction("tChiTietSanPham");
            }
            ViewBag.MaSanPham = new SelectList(db.TSanPhams, "MaSanPham", "TenSanPham");
            return View(t);
        }
    }
}
