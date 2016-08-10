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

using Dottext.Framework;
using Dottext.Framework.Components;
using Dottext.Framework.Configuration;
using Dottext.Web.Admin.WebUI;
using Dottext.Web.Admin.UserControls;

namespace Dottext.Web.Admin.Pages
{
	/// <summary>
	/// EditSiteBlogConfig 的摘要说明。
	/// </summary>
	public class EditSiteBlogConfig : AdminPage
	{
		protected System.Web.UI.WebControls.TextBox txbTitle;
		protected System.Web.UI.WebControls.TextBox txbCategoryID;
		private SiteBlogConfig sbc;
		protected System.Web.UI.WebControls.TextBox txbBlogID;
		protected System.Web.UI.WebControls.TextBox txbItemCount;
		protected Dottext.Web.Admin.WebUI.Page PageContainer;
		protected Dottext.Web.Admin.WebUI.MessagePanel Messages;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel GlobalCategoryPanel;
		protected System.Web.UI.WebControls.Button btnDelete;
		private int index=-1;
		protected System.Web.UI.WebControls.Button btnSave;
		private int CategoryID;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			btnDelete.Attributes.Add("OnClick","return confirm('您真的要删除吗?')");
			if(Request.QueryString["cateid"]!=null&&Request.QueryString["cateid"]!="")
			{
				CategoryID=int.Parse(Request.QueryString["cateid"]);
				GetSiteBlogConfig(CategoryID);
			}
			if(!IsPostBack)
			{
				BindCategoryData();
			}
		}

		private void GetSiteBlogConfig(int CategoryID)
		{
			sbc=Config.GetSiteBlogConfigByCategoryID(CategoryID);
			if(sbc==null)
			{
				btnSave.Text="添加";
				sbc=new SiteBlogConfig();
				sbc.BlogID=GetNewBlogID();
				sbc.CategoryID=CategoryID;
				sbc.Title=Links.GetLinkCategory(CategoryID,false,-1).Title;
				sbc.Author=Framework.Util.Globals.GetWebConfig("AggregateTitle","CNDottext");
				sbc.ItemCount=30;
				SkinConfig skin=new SkinConfig();
				skin.SkinName="AggSite";
				skin.SkinPath="~/";
				skin.ControlPath="~/AggSite/";
				skin.TeamplateFile="Template.ascx";
				sbc.Skin=skin;					
			}
			else
			{
				btnSave.Text="修改";
				index=Config.GetSiteBlogConfigCollection().IndexOf(sbc);
			}
			
		}

		private void BindCategoryData()
		{
			txbTitle.Text=sbc.Title;
			txbCategoryID.Text=sbc.CategoryID.ToString();
			txbBlogID.Text=sbc.BlogID.ToString();
			txbItemCount.Text=sbc.ItemCount.ToString();
		}

		private void SaveConfig()
		{
			SiteBlogConfigCollection sbcc = Config.GetSiteBlogConfigCollection();
			if(index>0)
			{
				sbcc.RemoveAt(index);
				sbcc.Insert(index,sbc);
			}
			else
			{
				sbcc.Add(sbc);
			}
			Config.SaveSiteBlogConfigCollection(sbcc);
			//string dataFile=System.Web.HttpContext.Current.Server.MapPath("~/SiteBlogConfig.config");
			//Dottext.Framework.Util.SerializationHelper.Save(sbcc,dataFile);
			Messages.ShowMessage(btnSave.Text+"成功!");
				
		}

		private int GetNewBlogID()
		{
			int BlogID=-1;
			SiteBlogConfigCollection sbc = Config.GetSiteBlogConfigCollection();
			for(int i=0;i<sbc.Count;i++)
			{
				BlogID=System.Math.Min(sbc[i].BlogID,BlogID);
				
			}
			return BlogID-1;

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
			this.btnSave.Click += new System.EventHandler(this.lbSubmit_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lbSubmit_Click(object sender, System.EventArgs e)
		{
			sbc.Title=txbTitle.Text;
			sbc.ItemCount=int.Parse(txbItemCount.Text);
			SaveConfig();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			Config.RemoveSiteBlogConfigByCategoryID(this.CategoryID);
			Messages.ShowMessage("删除成功!");
			btnSave.Text="添加";
		}
	}
}
