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
using Dottext.Framework.Components;

namespace Dottext.Web
{
	/// <summary>
	/// Test ��ժҪ˵����
	/// </summary>
	public class Test : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.Button Button1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				bind();
			}
		}

		private void bind()
		{
			DropDownList1.Items.Add (new ListItem ("����"));
			DropDownList1.Items.Add (new ListItem ("����"));
			DropDownList1.Items.Add (new ListItem ("���º�����"));
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Write("click");
			Response.Write(DropDownList1.SelectedValue);
			
		}
		

		
	}
}
