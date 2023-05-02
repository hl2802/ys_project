using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using project_finall.Models.Database;
using project_finall.Areas.PrivatePage.Models;
using System.IO;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using System.Data.Entity.Migrations;

namespace project_finall.Areas.PrivatePage.Controllers
{
	public class ArticlesController : Controller
	{
		// GET: PrivatePage/Articles
		private static YS_DESIGNSEntities db = new YS_DESIGNSEntities();
		private static bool daDuyet;
		[HttpGet]
		public ActionResult Index()
		{
			Article x= new Article();
			
			x.Date_Submitted= DateTime.Now;
			x.Number_Of_Reads= 0;
			x.Account = Accustomed.GetAccountName();
			// đưa đường dẫn hình ra ngoài 
			ViewBag.Img="/img/demo/pt3.jpg";
			return View(x);
		}
		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Index(Article x ,HttpPostedFileBase HinhDaiDien)
		{

			try
			{           // xử lý thông tin từ view
			
				x.Date_Submitted = DateTime.Now;
				x.DADUYET = false;
				x.Account = Accustomed.GetAccountName();
				x.Number_Of_Reads = 0;
				x.Type_Articles = "news";
				
				//lưu hình vào thư mục chứa bài viết
				if (HinhDaiDien != null)
				{
					string vipath = "/img/demo/";
					string phypath = Server.MapPath("~/" + vipath);
					string ext = Path.GetExtension(HinhDaiDien.FileName);
					string tenf = "Hdd" + x.Id_Articles + "." + ext;
					HinhDaiDien.SaveAs(phypath + tenf);
					x.Img = vipath + tenf;
					//
					ViewBag.Img = x.Img;
				}
				else
					x.Img = "";
				// cập nhật đối tượng bài viết vừa đăng vào data model
				YS_DESIGNSEntities db = new YS_DESIGNSEntities();
				
					if (ModelState.IsValid)

					{

						db.Articles.Add(x);
						
					}
					
				
		
				// lưu thông tin xuống database
				db.SaveChanges();
			}
			catch {
				return RedirectToAction("Index", "Dashboard");

			}
			return View(x);
		}
		[HttpGet] 
		/// <summary>
		///  danh sách bài viết
		/// </summary>
		/// <param name="IsActive"></param>
		/// <returns></returns>
		public ActionResult List_Article(string IsActive)
		{
			daDuyet = IsActive.Equals("1");
			updateDatabase();

			return View();
		}
		[HttpPost]
		public ActionResult Delete(String ID_Article)
		{
			// dùng lệnh để xóa bài viết
			int Id = int.Parse(ID_Article);
			Article x = db.Articles.Find(Id);
			db.Articles.Remove(x);
			// cập nhật databasse
			db.SaveChanges();
			//hiển thị lại danh sách sau khi xóa
			updateDatabase();
			return View("List_Article");
		}
		[HttpPost]
		public ActionResult Active(string ID_Article)
		{ // dùng lệnh để cấm bài viết
			int Id = int.Parse(ID_Article);
			Article x = db.Articles.Find(Id);
			x.DADUYET = false;
			// cập nhật databasse
			db.SaveChanges();
			//hiển thị lại danh sách sau khi xóa
			updateDatabase();
			return View("List_Article");
		}
		/// <summary>
		/// hàm phục vụ cập nhật dữa liệu cho view của controller thông qua ViewData object
		/// </summary>
		
		
		public ActionResult PhongThuy()
		{
			PhongThuy x = new PhongThuy();

			x.Date_Submitted = DateTime.Now;
			x.Account = Accustomed.GetAccountName();
			// đưa đường dẫn hình ra ngoài 
			ViewBag.Img = "/img/demo/pt3.jpg";
			return View(x);
		}
		[HttpPost]
		[ValidateInput(false)]
		public ActionResult PhongThuy(PhongThuy x, HttpPostedFileBase HinhDaiDien)
		{

			try
			{           // xử lý thông tin từ view

				x.Date_Submitted = DateTime.Now;
				x.DADUYET = false;
				x.Account = Accustomed.GetAccountName();
				
				//lưu hình vào thư mục chứa bài viết
				if (HinhDaiDien != null)
				{
					string vipath = "/img/demo/";
					string phypath = Server.MapPath("~/" + vipath);
					string ext = Path.GetExtension(HinhDaiDien.FileName);
					string tenf = "Hdd" + x.Id_PhongThuy + "." + ext;
					HinhDaiDien.SaveAs(phypath + tenf);
					x.Img = vipath + tenf;
					//
					ViewBag.Img = x.Img;
				}
				else
					x.Img = "";
				// cập nhật đối tượng bài viết vừa đăng vào data model
				YS_DESIGNSEntities db = new YS_DESIGNSEntities();

				if (ModelState.IsValid)

				{

					db.PhongThuys.Add(x);

				}



				// lưu thông tin xuống database
				db.SaveChanges();
			}
			catch
			{
				return RedirectToAction("Index", "Dashboard");

			}
			return View(x);
		}

		public ActionResult List_PhongThuy(string IsActive)
		{
			daDuyet = IsActive.Equals("1");
			updateDatabase();

			return View();
		}
		[HttpPost]
		public ActionResult DeleteP(String ID_PhongThuy)
		{
			// dùng lệnh để xóa bài viết
			int Id = int.Parse(ID_PhongThuy);
			PhongThuy x = db.PhongThuys.Find(Id);
			db.PhongThuys.Remove(x);
			// cập nhật databasse
			db.SaveChanges();
			//hiển thị lại danh sách sau khi xóa
			updateDatabase();
			return View("List_PhongThuy");
		}
		[HttpPost]
		public ActionResult ActiveP(string ID_PhongThuy)
		{ // dùng lệnh để cấm bài viết
			int Id = int.Parse(ID_PhongThuy);
			PhongThuy x = db.PhongThuys.Find(Id);
			x.DADUYET = false;
			// cập nhật databasse
			db.SaveChanges();
			//hiển thị lại danh sách sau khi xóa
			updateDatabase();
			return View("List_Article");
		}
		/// <summary>
		/// hàm phục vụ cập nhật dữa liệu cho view của controller thông qua ViewData object
		/// </summary>

		private void updateDatabase()
		{
			List<PhongThuy> p = db.PhongThuys.Where(x => x.DADUYET == daDuyet).ToList<PhongThuy>();
			ViewData["listPhongThuy"] = p;
			ViewBag.tdButton = daDuyet ? "display ban" : "allow display";
			List<Article> l = db.Articles.Where(x => x.DADUYET == daDuyet).ToList<Article>();
			ViewData["listArticle"] = l;
			ViewBag.tdButton = daDuyet ? "display ban" : "allow display";
		}

	}
}