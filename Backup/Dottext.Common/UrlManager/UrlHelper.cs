using System;
using System.Web;

namespace Dottext.Common.UrlManager
{
	/// <summary>
	/// Summary description for UrlHelper.
	/// </summary>
	public class UrlHelper
	{
		private UrlHelper()
		{}

		public static readonly string EnableUrlReWritingKey="EnableUrlReWritingKey";

		public static void SetEnableUrlReWriting(HttpContext context, bool enable)
		{
			context.Items.Add(EnableUrlReWritingKey,enable);
		}

		public static bool GetEnableUrlReWriting(HttpContext context)
		{
			object obj = context.Items[EnableUrlReWritingKey];
			if(obj == null || Convert.ToBoolean(obj))
			{
				return true;
			}
			
			return false;


		}



	}
}
