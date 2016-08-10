using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Dottext.Web.Admin.WebUI;
using Dottext.Framework.Components;
using Dottext.Web.Admin;
using Dottext.Framework;


namespace Dottext.Web.Admin.Pages
{
	/// <summary>
	/// Summary description for StatsViews.
	/// </summary>
	public class StatsView : AdminPage
	{
		private bool _isListHidden = false;
		//private int _resultsPageNumber = 1;
		protected System.Web.UI.WebControls.Repeater rprSelectionList;
		protected Dottext.Web.Admin.WebUI.Pager ResultsPager;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Results;
		protected Dottext.Web.Admin.WebUI.MessagePanel Messages;
		protected Dottext.Web.Admin.WebUI.Page PageContainer;

		private void Page_Load(object sender, System.EventArgs e)
		{
		
//			if (null != Request.QueryString[Keys.QRYSTR_PAGEINDEX])
//				_resultsPageNumber = Convert.ToInt32(Request.QueryString[Keys.QRYSTR_PAGEINDEX]);
//
//			ResultsPager.PageSize = Preferences.ListingItemCount;
//			ResultsPager.PageIndex = _resultsPageNumber;
//			Results.Collapsible = false;
//
//			BindLocalUI();
//			BindList();

		}

		public string CheckHiddenStyle()
		{
			if (_isListHidden)
				return Constants.CSSSTYLE_HIDDEN;
			else
				return String.Empty;
		}


		public string GetPageTitle(object dataItem)
		{
			ViewStat stat = (ViewStat) dataItem;
			string pageTitle = "Unknown";


			switch (stat.PageType)
			{
				case PageType.HomePage:
					pageTitle = "Home Page";
					break;
				case PageType.ImagePage:
					pageTitle = "Your Gallery";
					break;
				case PageType.RSS:
					pageTitle = "RSS";
					break;
				case PageType.Post:
				case PageType.Story:
					pageTitle = stat.PageTitle;
					break;
				case PageType.Other:
					pageTitle = "Other";
					break;
				case PageType.Date:
					pageTitle = "Date";
					break;
			}

			return pageTitle;

		}

		public void BindLocalUI()
		{
			// Setup the LH navigation.
			HyperLink lnkReferrals = Utilities.CreateHyperLink("Referrals", "Referrers.aspx");
			HyperLink lnkViews		= Utilities.CreateHyperLink("Views", "StatsView.aspx");


			// Add the buttons to the PageContainer.
			PageContainer.AddToActions(lnkReferrals);
			PageContainer.AddToActions(lnkViews);

			// Attempt to customize the breadcrumb.
			Control container = Page.FindControl("PageContainer");
			if (null != container && container is Dottext.Web.Admin.WebUI.Page)
			{	
				Dottext.Web.Admin.WebUI.Page page = (Dottext.Web.Admin.WebUI.Page) container;
				string title = "Views";

				page.BreadCrumbs.AddLastItem(title);
				page.Title = title;
			}

		}

		public void BindList()
		{
//			PagedViewStatCollection stats = Stats.GetPagedViewStats(_resultsPageNumber, ResultsPager.PageSize, DateTime.Now.AddMonths(-1), DateTime.Now);
//
//
//			
//			if (stats.Count > 0)
//			{
//				ResultsPager.ItemCount = stats.MaxItems;
//				rprSelectionList.DataSource = stats;
//				rprSelectionList.DataBind();
//			}
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion


	}
}