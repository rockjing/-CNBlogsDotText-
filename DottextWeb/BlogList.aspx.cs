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

namespace Dottext.Web
{
	/// <summary>
	/// BlogList ��ժҪ˵����
	/// </summary>
	public class BlogList : System.Web.UI.Page
	{
		protected Dottext.Web.UI.WebControls.ContentRegion MPMain;
		protected Dottext.Web.UI.WebControls.ContentRegion LeftColumn;
		protected Dottext.Web.UI.WebControls.MasterPage MPContainer;
		protected Literal pageTitle;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			pageTitle.Text=UI.UIText.SiteTitle;
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
