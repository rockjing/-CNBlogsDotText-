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
	/// CatalogOpml ��ժҪ˵����
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
	

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
