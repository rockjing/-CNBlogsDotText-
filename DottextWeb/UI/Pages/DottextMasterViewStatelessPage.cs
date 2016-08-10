using System;

namespace Dottext.Web.UI.Pages
{
	/// <summary>
	/// Summary description for DottextMasterViewStatelessPage.
	/// </summary>
	public class DottextViewStatelessPage : System.Web.UI.Page
	{
		public DottextViewStatelessPage()
		{
			this.EnableViewState = false;
		}

		protected override object LoadPageStateFromPersistenceMedium()
		{return null;}

		protected override void SavePageStateToPersistenceMedium(object viewState){}
	}
}
