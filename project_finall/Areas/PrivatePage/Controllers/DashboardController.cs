using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project_finall.Models;
using project_finall.Models.Database;

namespace project_finall.Areas.PrivatePage.Controllers
{
    public class DashboardController : Controller
    {
        // GET: PrivatePage/Home
        public ActionResult Index()
        {
            return View();
        }
      

	}
}