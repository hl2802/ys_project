using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project_finall.Areas.PrivatePage.Models;
using project_finall.Models.Database;
using System.IO;
namespace project_finall.Areas.PrivatePage.Controllers
{
    public class ProductController : Controller
    {

		// GET: PrivatePage/Product
		private static YS_DESIGNSEntities db = new YS_DESIGNSEntities();
	
		[HttpGet]

        public ActionResult Index()
        {
             Product x = new Product();
            x.Date_Submitted = DateTime.Now;
			x.Username = Accustomed.GetAccountName();
		
			// đưa đường dẫn hình ra ngoài 
			ViewBag.Img = "/img/demo/pt3.jpg";
			return View(x);
		}
		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Index(Product x, HttpPostedFileBase HinhDaiDien)
		{

			try
			{           // xử lý thông tin từ view
				
				x.Date_Submitted = DateTime.Now;
				x.DADUYET = false;
				x.Username = Accustomed.GetAccountName();
		
				//lưu hình vào thư mục chứa bài viết
				if (HinhDaiDien != null)
				{
					string vipath = "/img/demo/";
					string phypath = Server.MapPath("~/" + vipath);
					string ext = Path.GetExtension(HinhDaiDien.FileName);
					string tenf = "Hdd" + x.Id_Products + "." + ext;
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

					db.Products.Add(x);

				}

	
				// lưu thông tin xuống database
				db.SaveChanges();
			}
			catch {
				return RedirectToAction("Index", "Dashboard");
			}
			return View(x);
		}



		private static bool isEdit= false;
        public ActionResult ProductType()
        {
            List<Type_Product> Type_products = new YS_DESIGNSEntities().Type_Product.OrderBy(x => x.Name_Type_Product).ToList<Type_Product>();
            ViewData["DsLoai"] = Type_products;
            return View();
        }
		public ActionResult ListProduct()
		{
			
			return View();
		}

		/// <summary>
		/// hàm phục vụ cập nhật dữa liệu cho view của controller thông qua ViewData object
		/// </summary>
		

		[HttpPost]
        public ActionResult ProductType(Type_Product type_Product)
        {
            YS_DESIGNSEntities db = new YS_DESIGNSEntities();
            // ADD
            if(!isEdit)
                db.Type_Product.Add(type_Product);
            else
            {
                Type_Product x=db.Type_Product.Find(type_Product.Id_Type_Product);
                x.Name_Type_Product = type_Product.Name_Type_Product;
                x.Note=type_Product.Note;
                isEdit = false;
            }    
            db.Type_Product.Add(type_Product);
            //save
            db.SaveChanges();
            // update
            if (ModelState.IsValid)
                ModelState.Clear();
            ViewData["DsLoai"] = db.Type_Product.OrderBy(z => z.Name_Type_Product).ToList<Type_Product>();

            return View();
        }
        [HttpPost]
        public ActionResult Delete(String Id_Type_Product)
        {
            YS_DESIGNSEntities db = new YS_DESIGNSEntities();
            int Id = int.Parse(Id_Type_Product);
            // Find Type Product in data model by id
            Type_Product type_Product = db.Type_Product.Find(Id);
            // remove  Type product from data model
            db.Type_Product.Remove(type_Product);
            //update
            db.SaveChanges();
            //
            ViewData["DsLoai"] = db.Type_Product.OrderBy(z => z.Name_Type_Product).ToList<Type_Product>();
            return View("ProductType");
        }

        [HttpPost]
        public ActionResult Edit(String Edit)
        {
			YS_DESIGNSEntities db = new YS_DESIGNSEntities();
			int Id = int.Parse(Edit);
			// 

            isEdit = true;
			Type_Product type_Product = db.Type_Product.Find(Id);
			//
			ViewData["DsLoai"] = db.Type_Product.OrderBy(z => z.Name_Type_Product).ToList<Type_Product>();
			return View("ProductType",type_Product);
        }

    }
}