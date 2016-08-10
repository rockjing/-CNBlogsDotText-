namespace Dottext.Web.AggSite
{
	using System;
	using System.Configuration;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Dottext.Framework.Logger;

	/// <summary>
	///		Summary description for Template.
	/// </summary>
	public class AdvPageTemplate : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.HyperLink TitleLink;
		protected Dottext.Web.UI.WebControls.ContentRegion LeftColumn;
		protected System.Web.UI.WebControls.HyperLink ListLink;
		protected System.Web.UI.WebControls.HyperLink fastcounter;
		protected System.Web.UI.WebControls.HyperLink lnkReturn;
		protected System.Web.UI.WebControls.HyperLink lnkReturnDefault;
		protected System.Web.UI.WebControls.Literal CalTitle;
		protected System.Web.UI.WebControls.HyperLink Hyperlink1;
		protected System.Web.UI.WebControls.Repeater LinkList;
		protected Dottext.Web.UI.WebControls.ContentRegion MPMain;
		protected Dottext.Web.UI.WebControls.ContentRegion Contentregion1;
		
		protected Literal TitleTag;

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if(null != Request.QueryString["date"])
			{
				lnkReturnDefault.Visible=true;
				
			}
			else
			{
				lnkReturnDefault.Visible=false;
			}

			if(null != Request.QueryString["cate"]&&null != Request.QueryString["title"])
			{
				lnkReturnDefault.NavigateUrl+=string.Format("?cate={0}&title={1}",Request.QueryString["cate"],Request.QueryString["title"]);
				CalTitle.Text=Request.QueryString["title"];
			}
			
			DataSet ds =new DataSet();
			ds.ReadXml(UI.UIData.SiteCatalogXmlFile);
			LinkList.DataSource=ds;
			LinkList.DataBind();
		}

		

		protected bool CheckVisible(string cateid)
		{
			if(cateid==null||cateid=="")
			{
				return false;
			}
			else
			{
				return true;
			}
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
