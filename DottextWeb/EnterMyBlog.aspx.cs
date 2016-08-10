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
using Dottext.Framework.Util;
namespace Dottext.Web.Pages
{
	/// <summary>
	/// EnterMyBlog ��ժҪ˵����
	/// ������ֱ�ӽ��벩��ҳ��
	/// </summary>
	public class EnterMyBlog : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if(!HttpContext.Current.Request.IsAuthenticated)
			{
				Response.Redirect("login.aspx?ReturnURL="+Request.Url.AbsoluteUri);
			}
			else
			{
				string blogurl="~/"+HttpContext.Current.User.Identity.Name;
				if(Request.QueryString["NewPost"]=="1")
				{
					Response.Redirect(blogurl+"/admin/EditPosts.aspx?opt=1");
				}
				else if(Request.QueryString["NewArticle"]=="1")
				{
					Response.Redirect(blogurl+"/admin/EditArticles.aspx?opt=1");
				}
				else
				{
					Response.Redirect(blogurl);
				}
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
