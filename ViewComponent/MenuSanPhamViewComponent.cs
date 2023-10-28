using Microsoft.AspNetCore.Mvc;
using TechShop.Repository;

namespace TechShop.ViewComponents
{
    public class MenuSanPhamViewComponent : ViewComponent
    {
        private readonly LoaiSanPhamRepository _menuSP;
        public MenuSanPhamViewComponent(LoaiSanPhamRepository loaiSanPhamRepository)
        {
            _menuSP = loaiSanPhamRepository;
        }
        public IViewComponentResult Invoke()
        {
            var loaisp = _menuSP.GetAllLoaiSP().OrderBy(x => x.MaLoai);
            return View(loaisp);
        }
    }
}
