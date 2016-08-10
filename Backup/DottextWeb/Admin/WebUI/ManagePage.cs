using System;

namespace Dottext.Web.Admin.Pages
{
	/// <summary>
	/// ManagePage 的摘要说明。
	/// </summary>
	public class ManagePage : AdminPage
	{
		public ManagePage()
		{
			
		}

		protected override bool ValidateUser
		{
			get
			{
				if(!base.ValidateUser)
				{
					return false;
				}
				return Dottext.Framework.Security.IsInRole("administrators");

			}
		}

		

	}
}
