namespace Dottext.Web.UI.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	using Dottext.Framework.Components;

	/// <summary>
	///		PreviewPost ��ժҪ˵����
	/// </summary>
	public class PreviewPost : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.HyperLink TitleUrl;
		protected System.Web.UI.WebControls.Literal Body;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Entry entry=(Entry)Context.Cache["PreviewPost"];
			if(entry!=null)
			{
				TitleUrl.Text=entry.Title;
				Body.Text=entry.Body;
			}
			Context.Cache.Remove("PreviewPost");
			Response.Expires=-1;
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
	}
}
