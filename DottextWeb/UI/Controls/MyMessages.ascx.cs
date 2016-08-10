namespace Dottext.Web.UI.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Dottext.Framework.Components;
	using Dottext.Framework.Data;
	using Dottext.Framework;

	/// <summary>
	///		MyMessages 的摘要说明。
	/// </summary>
	public class MyMessages : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.HyperLink lnkMessages;
		protected System.Web.UI.WebControls.HyperLink lnkPublicMsgView;
		protected System.Web.UI.WebControls.HyperLink lnkPrivateMsgView;
		protected System.Web.UI.WebControls.Literal ltMsgCount;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			this.Visible=Dottext.Web.UI.Globals.CheckContorVisible("MyMessages");
			if(!Visible)
			{
				return;
			}
			lnkPrivateMsgView.NavigateUrl=Dottext.Framework.Configuration.Config.CurrentBlog().FullyQualifiedUrl+"admin/MyMessages.aspx";
			lnkPublicMsgView.NavigateUrl=Dottext.Framework.Configuration.Config.CurrentBlog().FullyQualifiedUrl+"default.aspx?opt=msg";
			lnkMessages.NavigateUrl=Dottext.Framework.Configuration.Config.CurrentBlog().FullyQualifiedUrl+"Contact.aspx?id=1";
			EntryQuery eq=new EntryQuery();
			eq.PostType=PostType.Message;
			EntryCollection ec=Entries.GetEntryCollection(eq);
			ltMsgCount.Text=ec.Count.ToString();
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
		///		设计器支持所需的方法 - 不要使用代码编辑器
		///		修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
