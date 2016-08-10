namespace Dottext.Web.UI.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI;
	using System.Web.UI.HtmlControls;
	using Dottext.Framework.Configuration;

	/// <summary>
	///		MySearch ��ժҪ˵����
	/// </summary>
	public class MySearch : BaseControl
	{
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.Visible=Dottext.Web.UI.Globals.CheckContorVisible("MySearch");
			Control con=this.FindControl("SearchForm1");
			if(con!=null&& con is AggSite.SearchForm)
			{
				((AggSite.SearchForm)con).SearchUrl=string.Format("{0}BlogSearch.aspx?q=",CurrentBlog.FullyQualifiedUrl);
			}
			
			
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
		///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
		///		�޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/*private void ButtonSearch_Click(object sender, System.EventArgs e)
		{
			
			string searchText = tbSearch.Text;
            if(searchText.Trim().Length > 0)
			{
				Response.Redirect(string.Format("{0}BlogSearch.aspx?q={1}",CurrentBlog.FullyQualifiedUrl,Server.UrlEncode(searchText)));
				Response.End();
			}
			else
			{
				Response.Redirect(string.Format("{0}BlogSearch.aspx",CurrentBlog.FullyQualifiedUrl));
				Response.End();
			}
		}*/
	}
}
