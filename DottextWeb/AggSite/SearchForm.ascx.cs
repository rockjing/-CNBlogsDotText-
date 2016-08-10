namespace Dottext.Web.AggSite
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		SearchForm ��ժҪ˵����
	/// </summary>
	public class SearchForm : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox tbSearch;
		private string _width="300";
		protected System.Web.UI.HtmlControls.HtmlInputButton btnSearch;
	
		public string Width
		{
			get
			{
				return _width;
			}
			set
			{
				_width=value;
			}
		}
		
		private string _searchUrl="Search.aspx?q=";
		public string SearchUrl
		{
			get
			{
				if(!_searchUrl.ToLower().StartsWith("http://"))
				{
					_searchUrl=Dottext.Framework.Util.Globals.GetAppUrl(Request)+_searchUrl;
				}
				return _searchUrl;
			}
			set
			{
				_searchUrl=value;
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Request.QueryString["q"]!=null)
			{
				tbSearch.Text=Server.UrlDecode(Request.QueryString["q"]);
			}
			UI.Globals.RegisterMyScript(Page,"Search.js");
			tbSearch.Width=new Unit(Width);
			string scriptFunction=string.Format("Search('{0}',document.getElementById('{1}'))",SearchUrl,tbSearch.ClientID);
			tbSearch.Attributes.Add("OnKeyDown",scriptFunction);
			btnSearch.Attributes.Add("OnClick",scriptFunction);
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
			this.EnableViewState = false;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
