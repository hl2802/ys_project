using project_finall.Models.Database;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace project_finall.Models
{
	public class Commoncs
	{

		/// <summary>
		/// hàm lấy ra tất cả các sản phẩm thuộc một loại nào đó
		/// </summary>
		/// <returns></returns>

		public static List<Product> GetProducts()
		{
			List<Product> List_products = new List<Product>();
			// khai báo một đối tượng cho database
			DbContext db = new DbContext("YS_DESIGNSEntities");
			//lấy dữ liệu
			List_products = db.Set<Product>().ToList<Product>();
			return List_products;
		}

		/// <summary>
		/// hàm lấy chi tiết sản phẩm từ ID
		/// </summary>
		/// <param name="Id_Products"></param>
		/// <returns></returns>
		public static List<Product> GetProduct(int Id_Products)
		{

			List<Product> Product_products = new List<Product>();
			DbContext db = new DbContext("YS_DESIGNSEntities");
			Product_products = db.Set<Product>().Where(x => x.Id_Products == Id_Products).ToList<Product>();
			return Product_products;
		}
		/// <summary>
		///   hàm lấy ra danh sách loại sản phẩm
		/// </summary>
		/// <returns></returns>
		public static List<Type_Product> GetType_Products()
		{

			return new DbContext("YS_DESIGNSEntities").Set<Type_Product>().ToList<Type_Product>();
		}
		/// <summary>
		/// hàm lấy ra sản phẩm từ mã loại
		/// </summary>
		/// <param name="Id_Type_Product"></param>
		/// <returns></returns>
		public static List<Product> getProductByType_Product(int Id_Type_Product)
		{
			List<Product> List_product = new List<Product>();
			DbContext db = new DbContext("YS_DESIGNSEntities");
			List_product = db.Set<Product>().Where(x => x.Id_Type_Product == Id_Type_Product).ToList<Product>();
			return List_product;
		}
		/// <summary>
		/// lấy ra thông tin của Account
		/// </summary>
		/// <returns></returns>
		public static List<Account> GetAccounts()
		{
			return new DbContext("YS_DESIGNSEntities").Set<Account>().ToList<Account>();
		}
		/// <summary>
		/// lấy thông tin của bài viết
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>

		public static List<Article> GetArticles()
		{

			return new DbContext("YS_DESIGNSEntities").Set<Article>().ToList<Article>();
		}
		public static List<Article> GetArticles(int n)
		{
			List<Article> Article_ = new List<Article>();
			YS_DESIGNSEntities db = new YS_DESIGNSEntities();
			Article_ = db.Articles.OrderByDescending(x => x.Date_Submitted).Take(n).ToList<Article>();
			return Article_;
		}
		public static List<Article> GetArticlesDetail(int Id_Articles)
		{
			List<Article> Article_articles = new List<Article>();
			DbContext db = new DbContext("YS_DESIGNSEntities");
			Article_articles = db.Set<Article>().Where(x => x.Id_Articles == Id_Articles).ToList<Article>();
			return Article_articles;
		}


		public static List<Customer> GetCustomers ()
		{
			return new DbContext("YS_DESIGNSEntities").Set<Customer>().ToList<Customer>();
		}


	}
}