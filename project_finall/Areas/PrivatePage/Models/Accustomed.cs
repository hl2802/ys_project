using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project_finall.Models.Database;
namespace project_finall.Areas.PrivatePage.Models
{
	public class Accustomed
	{
		/// <summary>
		/// phương thức cho phép đọc thông tin của tài khoản trong session
		/// </summary>
		/// <returns></returns>
		public static Account GetAccount()
		{
			Account tk= new Account();
			tk = (Account)HttpContext.Current.Session["Login"];
			return tk;
		}
		public static string GetAccountName() 
		{
			return GetAccount().Username;
		}
	}
}