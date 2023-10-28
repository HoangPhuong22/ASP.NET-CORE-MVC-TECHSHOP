using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechShop.Models;
using X.PagedList;

namespace TechShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class tQuanLiChatLieuController : Controller
    {
        TechShopContext db = new TechShopContext();
        [Route("tQuanChatLieu")]
        public IActionResult tQuanLiChatLieu(int? page)
        {
            int pagesize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lsttmp = db.TChatLieus.AsNoTracking().OrderBy(x => x.TenChatLieu);
            PagedList<TChatLieu>lst = new PagedList<TChatLieu>(lsttmp, pageNumber, pagesize);   
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
        public IActionResult Create(TChatLieu chatlieu)
        {
           

            if (ModelState.IsValid)
            {
                db.TChatLieus.Add(chatlieu);
                db.SaveChanges();
                return RedirectToAction("tQuanLiChatLieu");
            }
            
            return View(chatlieu);
        }
    }
}
