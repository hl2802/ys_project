using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project_finall.Models.Database;

namespace project_finall.Models
{
	public class mapAccount
	{
		public List<Account> List_Account()
		{
			try
			{
				YS_DESIGNSEntities db = new YS_DESIGNSEntities();
				return db.Accounts.ToList();
			}
			catch
			{
				return null;
			}
		}
		public Account detail (string userName)
		{
			try
			{
				 YS_DESIGNSEntities db =new YS_DESIGNSEntities();
				var model = db.Accounts.SingleOrDefault(m => m.Username == userName.ToLower());
				return model;
			}
			catch
			{
				return null;
			}
		}
		public bool AdminUpdate( Account model)
		{
			YS_DESIGNSEntities db=new YS_DESIGNSEntities();
			var updateModel= db.Accounts.SingleOrDefault(m=>m.Username == model.Username.ToLower());
			if (updateModel != null)
			{
				return false;
			}
			updateModel.Surname= model.Surname;
			updateModel.Middle_Name	= model.Middle_Name;
			updateModel.Name= model.Name;
			updateModel.Birthday= model.Birthday;
			updateModel.P_Number = model.P_Number;
			updateModel.Email= model.Email;
			db.SaveChanges();
			return true;

		}
		public bool ChangePassword(Account model)
		{
			YS_DESIGNSEntities db = new YS_DESIGNSEntities();
			var updateModel = db.Accounts.SingleOrDefault(m => m.Username == model.Username.ToLower());
			if (updateModel != null)
			{
				return false;
			}
			updateModel.Pass = model.Pass;
			db.SaveChanges();
			return true;

		}
		public bool ChangeImg(String userName, string img)
		{
			YS_DESIGNSEntities db = new YS_DESIGNSEntities();
			var updateModel = db.Accounts.SingleOrDefault(m => m.Username == userName.ToLower());
			if (updateModel != null)
			{
				return false;
			}
			updateModel.img = img;
			db.SaveChanges();
			return true;

		}

	}
}