using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using BKT_DOTNET.Models;

namespace BKT_DOTNET.Controllers
{
	public class AccessController : Controller
	{
		private QlbanVaLiContext db = new QlbanVaLiContext();

		[HttpGet]
		public IActionResult Login()
		{
			if (HttpContext.Session.GetString("UserName") == null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpPost]
		public IActionResult Login(TUser user)
		{
			if (HttpContext.Session.GetString("UserName") == null)
			{
				var u = db.TUsers.Where(x => x.Username.Equals(user.Username) &&
				x.Password.Equals(user.Password)).FirstOrDefault();
				if (u != null)
				{
					HttpContext.Session.SetString("UserName", u.Username.ToString());
					return RedirectToAction("Index", "Home");
				}
			}
			return View();
		}
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(TUser user)
        {
            if (ModelState.IsValid)
            {
                db.TUsers.Add(user);
                db.SaveChanges();
                HttpContext.Session.SetString("UserName", user.Username.ToString());
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			HttpContext.Session.Remove("UserName");
			return RedirectToAction("Login", "Access");
		}
	}
}