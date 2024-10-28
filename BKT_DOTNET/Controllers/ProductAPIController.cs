using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BKT_DOTNET.Models;
using BKT_DOTNET.Models.ProductModels;

namespace BKT_DOTNET.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductAPIController : ControllerBase
	{
		private QlbanVaLiContext db = new QlbanVaLiContext();

		[HttpGet]
		public IEnumerable<Product> GetAllProducts()
		{
			var sanPham = (from p in db.TDanhMucSps
						   select new Product
						   {
							   MaSp = p.MaSp,
							   TenSp = p.TenSp,
							   MaLoai = p.MaLoai,
							   AnhDaiDien = p.AnhDaiDien,
							   GiaNhoNhat = p.GiaNhoNhat,
						   }).ToList();
			return sanPham;
		}

		[HttpGet("{maloai}")]
		public IEnumerable<Product> GetProductByCategory(string maloai)
		{
			var sanPham = (from p in db.TDanhMucSps
						   where p.MaLoai == maloai
						   select new Product
						   {
							   MaSp = p.MaSp,
							   TenSp = p.TenSp,
							   MaLoai = p.MaLoai,
							   AnhDaiDien = p.AnhDaiDien,
							   GiaNhoNhat = p.GiaNhoNhat,
						   }).ToList();
			return sanPham;
		}
	}
}