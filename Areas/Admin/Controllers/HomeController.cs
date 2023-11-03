using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TechShop.Models;
using X.PagedList;

namespace TechShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Route("Admin/Home")]
    public class HomeController : Controller
    {
        TechShopContext db = new TechShopContext();
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("tsanpham")]
        public IActionResult tSanPham(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanPham = db.TSanPhams.AsNoTracking().OrderBy(X => X.TenSanPham);
            PagedList<TSanPham>lst = new PagedList<TSanPham>(lstSanPham, pageNumber, pageSize); 
            return View(lst);
        }
        [Route("Create")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoaiSanPham = new SelectList(db.TLoaiSanPhams.ToList(), "MaLoai", "TenLoai");
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "TenChatLieu");
            ViewBag.MaThuongHieu = new SelectList(db.TThuongHieus.ToList(), "MaThuongHieu", "TenThuongHieu");
            ViewBag.MaQuocGia = new SelectList(db.TQuocGia.ToList(), "MaQuocGia", "TenQuocGia");
            return View();
        }
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult Create(TSanPham sanpham)
        //{
        //    ModelState.Remove("MaChatLieuNavigation");
        //    ModelState.Remove("MaQuocGiaNavigation");
        //    ModelState.Remove("MaLoaiSanPhamNavigation");
        //    ModelState.Remove("MaThuongHieuNavigation");

        //    if (ModelState.IsValid)
        //    {

        //        db.TSanPhams.Add(sanpham);
        //        db.SaveChanges();
        //        return RedirectToAction("tSanPham");
        //    }
        //    Console.WriteLine("TenSanPham: " + sanpham.TenSanPham);
        //    Console.WriteLine("Mathuong: " + sanpham.MaThuongHieu);
        //    Console.WriteLine("MaLoai: " + sanpham.MaLoaiSanPham);
        //    Console.WriteLine("MaQuocGIa: " + sanpham.MaQuocGia);
        //    Console.WriteLine("MaChatLieu: " + sanpham.MaChatLieu);

        //    foreach (var modelError in ModelState.Values.SelectMany(entry => entry.Errors))
        //    {
        //        Console.WriteLine(modelError.ErrorMessage);
        //    }

        //    ViewBag.MaLoaiSanPham = new SelectList(db.TLoaiSanPhams.ToList(), "MaLoai", "TenLoai");
        //    ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "TenChatLieu");
        //    ViewBag.MaThuongHieu = new SelectList(db.TThuongHieus.ToList(), "MaThuongHieu", "TenThuongHieu");
        //    ViewBag.MaQuocGia = new SelectList(db.TQuocGia.ToList(), "MaQuocGia", "TenQuocGia");
        //    return View(sanpham);
        //}

        
        public IActionResult Create(TSanPham sanpham, IFormFile AnhSanPham)
        {
            if (AnhSanPham != null && AnhSanPham.Length > 0)
            {
                // Lấy đường dẫn tuyệt đối đến thư mục wwwroot/img/
                var webRootPath = _webHostEnvironment.WebRootPath;
                var imagePath = Path.Combine(webRootPath, "img");

                // Đảm bảo thư mục tồn tại
                Directory.CreateDirectory(imagePath);

                // Tạo tên tệp duy nhất cho ảnh
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + AnhSanPham.FileName;

                // Tạo đường dẫn đến tệp lưu trong thư mục img/
                var imagePathWithFileName = Path.Combine(imagePath, uniqueFileName);

                // Copy tệp tải lên vào thư mục img/
                using (var stream = new FileStream(imagePathWithFileName, FileMode.Create))
                {
                    AnhSanPham.CopyTo(stream);
                }

                // Lưu tên tệp ảnh trong đối tượng sanpham
                sanpham.AnhSanPham = uniqueFileName;
            }

            ModelState.Remove("MaChatLieuNavigation");
            ModelState.Remove("MaQuocGiaNavigation");
            ModelState.Remove("MaLoaiSanPhamNavigation");
            ModelState.Remove("MaThuongHieuNavigation");

            if (ModelState.IsValid)
            {
                db.TSanPhams.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("tSanPham");
            }

            ViewBag.MaLoaiSanPham = new SelectList(db.TLoaiSanPhams.ToList(), "MaLoai", "TenLoai");
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "TenChatLieu");
            ViewBag.MaThuongHieu = new SelectList(db.TThuongHieus.ToList(), "MaThuongHieu", "TenThuongHieu");
            ViewBag.MaQuocGia = new SelectList(db.TQuocGia.ToList(), "MaQuocGia", "TenQuocGia");
            return View(sanpham);
        }





        [Route("Edit")]
        [HttpGet]
        public IActionResult Edit(string masp)
        {
            ViewBag.MaLoaiSanPham = new SelectList(db.TLoaiSanPhams.ToList(), "MaLoai", "TenLoai");
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "TenChatLieu");
            ViewBag.MaThuongHieu = new SelectList(db.TThuongHieus.ToList(), "MaThuongHieu", "TenThuongHieu");
            ViewBag.MaQuocGia = new SelectList(db.TQuocGia.ToList(), "MaQuocGia", "TenQuocGia");
            var sanpham = db.TSanPhams.Find(masp);
            return View(sanpham);
        }
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TSanPham sanpham)
        {
            ModelState.Remove("MaChatLieuNavigation");
            ModelState.Remove("MaQuocGiaNavigation");
            ModelState.Remove("MaLoaiSanPhamNavigation");
            ModelState.Remove("MaThuongHieuNavigation");
            Console.WriteLine(ModelState.IsValid);
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("tSanPham");
            }
            else
            {
                ViewBag.MaLoaiSanPham = new SelectList(db.TLoaiSanPhams.ToList(), "MaLoai", "TenLoai");
                ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "TenChatLieu");
                ViewBag.MaThuongHieu = new SelectList(db.TThuongHieus.ToList(), "MaThuongHieu", "TenThuongHieu");
                ViewBag.MaQuocGia = new SelectList(db.TQuocGia.ToList(), "MaQuocGia", "TenQuocGia");
                return View(sanpham);
            }
        }
        [Route("Delete")]
        [HttpGet]
        public IActionResult Delete(string msp)
        {
            var chiTietSanPham= db.TChiTietSanPhams.Where(x=>x.MaSanPham == msp);
            Console.WriteLine("Phương");
            if(chiTietSanPham.Count() > 0)
            {
                TempData["error"] = "Không xóa được sản phẩm";
                return RedirectToAction("tSanPham");
            }
            Console.WriteLine("Phương");
            db.Remove(db.TSanPhams.Find(msp));
            db.SaveChanges();
            TempData["success"] = "Sản phẩm đã được xóa";
            return RedirectToAction("tSanPham");
        }
    }
}
