using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Xml;

using Dottext.Framework.Data;
using Dottext.Framework.Components;
using Dottext.Framework;
using Dottext.Framework.Util;
using Dottext.Framework.Configuration;

namespace Dottext.Web
{
	/// <summary>
	/// Register 的摘要说明。
	/// </summary>
	public class Register : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txbTitle;
		protected System.Web.UI.WebControls.TextBox txbSubtitle;
		protected System.Web.UI.WebControls.TextBox txbUser;
		protected System.Web.UI.WebControls.TextBox txbPwd;
		protected System.Web.UI.WebControls.TextBox txbPwd2;
		protected System.Web.UI.WebControls.LinkButton Linkbutton1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator_txbUser;
		protected System.Web.UI.WebControls.TextBox txbEmail;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator_txbPwd;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator_txbAuthor;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator_txbTitle;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator_Pwd;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator_txbEmail;
		protected System.Web.UI.WebControls.DropDownList ddlSkin;
		protected System.Web.UI.WebControls.TextBox txbAuthor;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				XmlDocument doc  = new XmlDocument();
				string filename = Server.MapPath("~/Admin/Skins.config");
				doc.Load(filename);

				XmlNodeList nodes = doc.SelectNodes("//SkinTemplates/Skins/SkinTemplate");

				foreach(XmlNode node in nodes)
				{
					if(node.Attributes["SecondaryCss"] == null)
					{
						string name = node.Attributes["Skin"].Value ;
						ddlSkin.Items.Add(new ListItem(name,name));
					}
				}
				System.Random random=new Random();
				ddlSkin.SelectedIndex=random.Next(ddlSkin.Items.Count);
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
			this.txbPwd.TextChanged += new System.EventHandler(this.txbPwd_TextChanged);
			this.Linkbutton1.Click += new System.EventHandler(this.Linkbutton1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		

		private void Linkbutton1_Click(object sender, System.EventArgs e)
		{
			if(this.txbTitle.Text=="")
			{
				this.txbTitle.Text=this.txbUser.Text;
			}
			string host = Config.Settings.AggregateHost;//ConfigurationSettings.AppSettings["AggregateHost"] as string;
			string url = Config.Settings.AggregateUrl;
			string sql = "blog_UTILITY_AddBlog";
			string conn = Dottext.Framework.Providers.DbProvider.Instance().ConnectionString;
			string city=Request.Form.Get("city");
			if(city==null)
			{
				city="";
			}
			SqlParameter[] p = 
				{
					SqlHelper.MakeInParam("@UserName",SqlDbType.NVarChar,50,this.txbUser.Text),
					SqlHelper.MakeInParam("@Password",SqlDbType.NVarChar,50,Security.Encrypt(this.txbPwd.Text)),
					SqlHelper.MakeInParam("@Email",SqlDbType.NVarChar,50,this.txbEmail.Text),
					SqlHelper.MakeInParam("@Host",SqlDbType.NVarChar,50,host),
					SqlHelper.MakeInParam("@Application",SqlDbType.NVarChar,50,this.txbUser.Text),
					SqlHelper.MakeInParam("@Author",SqlDbType.NVarChar,50,this.txbAuthor.Text),
					SqlHelper.MakeInParam("@Title",SqlDbType.NVarChar,100,this.txbTitle.Text),
					SqlHelper.MakeInParam("@SubTitle",SqlDbType.NVarChar,250,this.txbSubtitle.Text),
					SqlHelper.MakeInParam("@IsHashed",SqlDbType.Bit,0,1),
					SqlHelper.MakeInParam("@Skin",SqlDbType.NVarChar,50,this.ddlSkin.SelectedValue),
					SqlHelper.MakeInParam("@City",SqlDbType.NVarChar,50,city),
					
				};
			//int result=0;
			try
			{
				Dottext.Framework.Data.SqlHelper.ExecuteNonQuery(conn,CommandType.StoredProcedure,sql,p);
			}
			catch
			{
				Response.Write("<font color='red'>用户名已存在</font>");
				//throw; 
			}
			Response.Redirect(url+this.txbUser.Text);
		}

		private void txbPwd_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
