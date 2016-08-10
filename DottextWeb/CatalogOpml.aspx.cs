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
using System.Configuration;

namespace Dottext.Web
{
	/// <summary>
	/// CatalogOpml 的摘要说明。
	/// </summary>
	public class CatalogOpml : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			/*DataSet ds=new DataSet();
			ds.ReadXml(UI.UIData.SiteCatalogXmlFile);
			Response.ContentType = "text/xml";
			Dottext.Framework.Syndication.OpmlWriter.Write(ds.Tables[0],Dottext.Framework.Util.Globals.GetAppUrl(Request),ConfigurationSettings.AppSettings["AggregateTitle"],Response.OutputStream);
			*/
			Response.ContentType = "text/xml";
			Dottext.Common.Syndication.SiteCatalogOpmlWriter sco=new Dottext.Common.Syndication.SiteCatalogOpmlWriter(Response.OutputStream);
			sco.SiteTilte=UI.UIText.SiteTitle;
			sco.SiteConfigCollection=Dottext.Framework.Configuration.Config.GetSiteBlogConfigCollection();
			sco.Output();
			sco.Close();
			//Response.ContentEncoding = System.Text.Encoding.UTF8;
			//Response.Write(sco.GetXml);
			
		}		
	

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
