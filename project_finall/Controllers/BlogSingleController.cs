using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using project_finall.Models;
using project_finall.Models.Database;

namespace project_finall.Controllers
{
    public class BlogSingleController : Controller
    {
	[HttpGet]
        // GET: BlogSingle
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Articles(int Id_Articles)
		{
			YS_DESIGNSEntities db = new YS_DESIGNSEntities();
			Article a = db.Articles.Where(z => z.Id_Articles == Id_Articles).First<Article>();
			ViewData["getArticles"] = a;
			return View();
		}
		[HttpPost]
		public ActionResult comment(Customer x)
		{
			//
			using (var context = new YS_DESIGNSEntities())
			{
				using (DbContextTransaction trans= context.Database.BeginTransaction())
				{
					try 
					{
						//update customer infor to CUSTOMER object you have just creared before
						//
						// add customer info to data model
						x.Id_Customer = x.Id_Customer;
						var z = context.Customers.Find(x.Id_Customer);
						if (z == null)
						{
							context.Set<Customer>().Add(x);
							//save to database--------------[table custommer]
						
						}
						
						
						//
						context.Customers.Add(x);
						context.SaveChanges();
						trans.Commit();
						
					}
					catch (Exception e) 
					{
					
						trans.Rollback();
						string s = e.Message;
					}
				}	
			}
			return RedirectToAction("Index", "Home");
		}
		 public ActionResult PhongThuy()
		{
			return View();
		}

	}
	

}