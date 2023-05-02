using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using project_finall.Models;
using project_finall.Models.Database;

namespace project_finall.Controllers
{
    public class LoginController : Controller
    {
		// GET: Login
		[HttpGet]
		public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Index(String Acc, string Pass)
		{
			String pass = Encode.encryptSHA256(Pass);

			Account infologin = new YS_DESIGNSEntities()
				.Accounts.Where(x => x.Username.Equals(Acc.ToUpper().Trim()) && x.Pass.Equals(pass))
				.First<Account>();

			bool isAuthentic = infologin != null && infologin.Username.Equals(Acc.ToUpper()) && infologin.Pass.Equals(pass);
			if (isAuthentic)
			{
				Session["Login"] = infologin;
			
				return RedirectToAction("Index", "Dashboard", new { Area = "PrivatePage" });
			}
			if(String.IsNullOrEmpty(Acc)==true| String .IsNullOrEmpty(Pass)==true)
			{
				ViewBag.Notification = "Notice of missing information";
			}
			var account = new mapAccount().detail(Acc);
			if( account==null )
			{
				ViewBag.Notification = "Incorrect account or password";
				ViewBag.Acc=Acc;
				return View(); ;
			}
			if(account.Pass !=Pass)
			{
				ViewBag.Notification = "Incorrect account or password";
				ViewBag.Acc = Acc;
				return View(); 
			}	
			if(account.STATUS!=true)
			{
				ViewBag.Notification = "Temporarily locked account";
				ViewBag.Acc = Acc;
				return View(); ;
			}
			Session["user"] = account;
			return RedirectToAction("Index", "Dashboard", new { Area = "PrivatePage" });
			
		}
		// log out
		public ActionResult Logout()
		{
			Session.Remove("Login");
			return RedirectToAction("Index", "Login");

		}
	}
}