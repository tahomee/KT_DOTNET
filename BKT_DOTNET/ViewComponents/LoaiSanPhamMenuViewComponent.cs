using BKT_DOTNET.Models;
using Microsoft.AspNetCore.Mvc;
using BKT_DOTNET.Repository;

namespace BKT_DOTNET.ViewComponents
{
    public class LoaiSanPhamMenuViewComponent : ViewComponent
    {
        private readonly ILoaiSanPhamRepository _loaiSanPham;
        public LoaiSanPhamMenuViewComponent(ILoaiSanPhamRepository loaisanpham) 
        {
            _loaiSanPham = loaisanpham;        
        }

        public IViewComponentResult Invoke()
        {
            var loaisp = _loaiSanPham.GetAllLoaiSP().OrderBy(x => x.Loai);
            return View(loaisp);
        }
    }
}
