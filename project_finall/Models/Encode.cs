using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace project_finall.Models
{
	public class Encode
	{
		/// <summary>
		/// funcion encode
		/// </summary>
		/// <param name="PlaminText"></param>
		/// <returns></returns>
		public static string encryptSHA256(string PlaminText)
		{
			string result = "";

			//create sha256
			using (SHA256 has = SHA256.Create())
			{
				// convert plain text to a bytes array
				byte[] sourceData = Encoding.UTF8.GetBytes(PlaminText);
				// computer hash and return a byte aray
				byte[] hashResult = has.ComputeHash(sourceData);
				result = BitConverter.ToString(hashResult).Replace("-", "");
			}
			return result;
		}
	}
}