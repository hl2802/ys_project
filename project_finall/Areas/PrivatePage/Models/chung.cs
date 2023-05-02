using project_finall.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_finall.Areas.PrivatePage.Models
{
	public class chung
	{
		public static List<Product> getListProducts()
		{
			List<Product> List_products = new List<Product>();
			// khai báo một đối tượng cho database
			DbContext db = new DbContext("YS_DESIGNSEntities");
			//lấy dữ liệu
			List_products = db.Set<Product>().ToList<Product>();
			return List_products;
		}
	

	}

}