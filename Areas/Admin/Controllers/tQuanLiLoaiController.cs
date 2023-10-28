using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechShop.Models;
using X.PagedList;

namespace TechShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/tQuanLiLoaiSanPham")]
    public class tQuanLiLoaiController : Controller
    {
        TechShopContext db = new TechShopContext();
        [Route("tloaisanpham")]
        [Route("")]
        public IActionResult tLoaiSanPham(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lsttmp = db.TLoaiSanPhams.AsNoTracking().OrderBy(X => X.TenLoai);
            PagedList<TLoaiSanPham> lst = new PagedList<TLoaiSanPham>(lsttmp, pageNumber, pageSize);
            return View(lst);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TLoaiSanPham t)
        {
            if(ModelState.IsValid)
            {
                db.TLoaiSanPhams.Add(t);
                db.SaveChanges();
                return RedirectToAction("tLoaiSanPham");
            }
            return View(t);
        }
    }
}
