using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechShop.Models;
using X.PagedList;

namespace TechShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/tQuanLiThuongHieu")]
    public class tQuanLiThuongHieuController : Controller
    {
        TechShopContext db = new TechShopContext();
        [Route("tthuonghieu")]
        public IActionResult tThuongHieu(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lsttmp = db.TThuongHieus.AsNoTracking().OrderBy(X => X.TenThuongHieu);
            PagedList<TThuongHieu> lst = new PagedList<TThuongHieu>(lsttmp, pageNumber, pageSize);
            return View(lst);
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TThuongHieu t)
        {
            if(ModelState.IsValid)
            {
                db.Add(t);
                db.SaveChanges();
                return RedirectToAction("tThuongHieu");
            }
            return View(t);
        }
        [Route("Edit")]
        [HttpGet]
        public IActionResult Edit(string? mth)
        {
            var ThuongHieu = db.TThuongHieus.Find(mth);
            return View(ThuongHieu);
        }
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TThuongHieu t)
        {
            Console.WriteLine(ModelState.IsValid);
            if (ModelState.IsValid)
            {
                db.Update(t);
                db.SaveChanges();
                return RedirectToAction("tThuongHieu");
            }
            return View(t);
        }
    }
}
