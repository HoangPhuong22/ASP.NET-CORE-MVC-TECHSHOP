using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechShop.Models;
using X.PagedList;

namespace TechShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/tTaiKhoan")]
    public class tQuanLiTaiKhoanController : Controller
    {
        TechShopContext db = new TechShopContext();
        [Route("tTaiKhoan")]
        public IActionResult tTaiKhoan(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lsttmp = db.TTaiKhoans.AsNoTracking().OrderBy(X => X.UserName);
            PagedList<TTaiKhoan> lst = new PagedList<TTaiKhoan>(lsttmp, pageNumber, pageSize);
            return View(lst);
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(TTaiKhoan t)
        {
            if(ModelState.IsValid)
            {
                db.Add(t);
                db.SaveChanges();
                return RedirectToAction("tTaiKhoan");
            }
            return View(t);
        }
    }
}
