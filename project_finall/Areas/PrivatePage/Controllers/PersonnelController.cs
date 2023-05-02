using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project_finall.Models;

namespace project_finall.Areas.PrivatePage.Controllers
{
    public class PersonnelController : Controller
    {
        // GET: PrivatePage/Personnel
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List_Account() 
        {
            return View(new mapAccount().List_Account());        
        }
     


        public ActionResult Edit(int id) 
        {
            return View();
        }
        public ActionResult Delete(int id) 
        {
            return RedirectToAction("Index");
        }
		public ActionResult ChangeImg(string username)
		{
			return View(new mapAccount().detail(username));
		}
		[HttpPost]
		public ActionResult ChangeImg(string username, HttpPostedFileBase avatar)
		{
            if (avatar == null)
            {
                ViewBag.error = "file not selected";
				return View(new mapAccount().detail(username));

			}
            var link = "/Data/avatar";
            var linktd= Server.MapPath(link);
            // đường dẫn lưu ảnh
            var imgts = link + avatar.FileName;
            var imgPath = linktd + avatar.FileName;
            //lưu
            avatar.SaveAs(imgPath);
            // cập nhật link ảnh
            new mapAccount().ChangeImg(username, imgts);

			return RedirectToAction("Index");
		}
	}
}