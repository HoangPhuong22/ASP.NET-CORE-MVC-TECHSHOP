using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechShop.Models;
using X.PagedList;

namespace TechShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/tQuocGia")]
    public class tQuanLiQuocGiaController : Controller
    {
        TechShopContext db = new TechShopContext();
        [Route("tQuocGia")]
        public IActionResult tQuocGia(int? page)
        {
            int pagesize = 8;
            int pageValue = page == null || page < 0 ? 1 : page.Value;
            var lsttmp = db.TQuocGia.AsNoTracking().OrderBy(X => X.TenQuocGia);
            PagedList<TQuocGium>lst = new PagedList<TQuocGium>(lsttmp, pageValue, pagesize);    
            return View(lst);
        }
        [Route("Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TQuocGium t)
        {
            if(ModelState.IsValid)
            {
                db.Add(t);
                db.SaveChanges();
                return RedirectToAction("tquocgia");
            }
            return View(t);
        }
        [Route("Edit")]
        [HttpGet]
        public IActionResult Edit(string? qg)
        {
            var t = db.TQuocGia.Find(qg);
            return View(t);
        }
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TQuocGium t)
        {
            if (ModelState.IsValid)
            {
                db.Update(t);
                db.SaveChanges();
                return RedirectToAction("tquocgia");
            }
            return View(t);
        }
    }
}
