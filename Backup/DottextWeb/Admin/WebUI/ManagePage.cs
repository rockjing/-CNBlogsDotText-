using System;

namespace Dottext.Web.Admin.Pages
{
	/// <summary>
	/// ManagePage ��ժҪ˵����
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
