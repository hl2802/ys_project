using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project_finall.Models;
using project_finall.Models.Database;

namespace project_finall.Controllers
{
    public class ProjectsController : Controller
    {
		// GET: Projects
		YS_DESIGNSEntities db = new YS_DESIGNSEntities();
		[HttpGet]
		public ActionResult Index()
		{

			return View();
		}
	
		public ActionResult Projects_details(int Id_Products)
		{
			YS_DESIGNSEntities db = new YS_DESIGNSEntities();
			Product p = db.Products.Where(z => z.Id_Products == Id_Products).First<Product>();
			ViewData["getProduct"] = p;
			return View();
		}
		public ActionResult Projects_details_baogia(int Id_Products)
		{
			YS_DESIGNSEntities db = new YS_DESIGNSEntities();
			Product p = db.Products.Where(z => z.Id_Products == Id_Products).First<Product>();
			ViewData["getProduct"] = p;
			return View();
		}

		public ActionResult Type_Projects(int Id_Type_Product)
		{
			Type_Product x = db.Type_Product.Where(z => z.Id_Type_Product == Id_Type_Product).First<Type_Product>();
			ViewData["getTypeProduct"] = x;
			return View();
		}
	}
}