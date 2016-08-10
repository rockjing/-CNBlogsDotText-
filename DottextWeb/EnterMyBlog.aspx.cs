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
	/// EnterMyBlog 的摘要说明。
	/// 在首面直接进入博客页面
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
