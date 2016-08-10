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
using System.Data.SqlClient;

using Dottext.Framework.Data;
using Dottext.Framework.Components;
using Dottext.Framework;
using Dottext.Framework.Util;
using Dottext.Framework.Configuration;

namespace Dottext.Web.Pages
{
	/// <summary>
	/// AddToFavorite 的摘要说明。
	/// </summary>
	public class AddToFavorite : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Submit;
		protected System.Web.UI.WebControls.RadioButtonList CategoryList;
		protected System.Web.UI.WebControls.Label Message;
		protected System.Web.UI.WebControls.Label entryid;
		protected System.Web.UI.WebControls.CheckBox ckbNewWindow;
		protected System.Web.UI.WebControls.Label lbTitle;
		protected System.Web.UI.WebControls.Label lbAuthor;
		protected System.Web.UI.WebControls.TextBox tbCategoryName;
		protected System.Web.UI.WebControls.Button btnCreateCategory;
		protected System.Web.UI.HtmlControls.HtmlTable tbAddFavorite;
		protected System.Web.UI.HtmlControls.HtmlTable tbCreateCategory;
		protected System.Web.UI.WebControls.Button btnNewCategory;
		private BlogConfig config;
		protected System.Web.UI.WebControls.HyperLink ReturnLink;
		protected System.Web.UI.WebControls.HyperLink lnkEnterMyBlog;
		protected System.Web.UI.WebControls.Button btnReturnBefore;
		private Entry entry;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!HttpContext.Current.Request.IsAuthenticated)
			{
				Response.Redirect(Config.Settings.AggregateUrl+"login.aspx?ReturnURL="+Request.Url.AbsoluteUri);
			}
			if(Request.QueryString["id"] == null)
			{
				throw new ApplicationException("请先选择文章");
			}

			config=Config.GetConfig(HttpContext.Current.User.Identity.Name);
			entry=Entries.GetEntry(int.Parse(Request.QueryString["id"]));
			lbTitle.Text=entry.Title;
			lbAuthor.Text=entry.Author;
			if(entry==null)
			{
				throw new ApplicationException("所选文章不存在!");
			}
			ReturnLink.NavigateUrl=entry.TitleUrl;
			lnkEnterMyBlog.NavigateUrl=Config.Settings.AggregateUrl+config.CleanApplication+"/admin/EditFavorite.aspx";
            
			if(!IsPostBack)
			{
				GetCategoryList();						
			
			}
		
		}

		private void GetCategoryList()
		{
			CategoryList.Items.Clear();
			LinkCategoryCollection categorys=Links.GetCategoriesByType(config.BlogID,CategoryType.FavoriteCollention,false);
			if(categorys==null||categorys.Count==0)
			{
				tbCreateCategory.Visible=true;
				tbAddFavorite.Visible=false;
			}
			else
			{
				foreach (LinkCategory category in categorys)
				{
					CategoryList.Items.Add(new ListItem(category.Title,category.CategoryID.ToString()));

				}
				CategoryList.SelectedIndex=0;

			}
		}


		private void AddToFav()
		{
			//string titleurl=Request.QueryString["url"];
			if(entry!=null)
			{
				Link link = new Link();
				link.BlogID=config.BlogID;
				link.PostID=entry.EntryID;
				link.IsActive=true;
				link.NewWindow=ckbNewWindow.Checked;
				link.Title=entry.Title;
				/*BlogConfig config=Config.GetConfig(entry.BlogID);
					if(config==null)
					{
						
						Message.Text="添加到收藏夹出错";
						return;
					}*/
				link.Url=entry.TitleUrl;//config.Application+config.UrlFormats.EntryUrl(entry);//entry.Link;//entry.TitleUrl;
				link.CategoryID=int.Parse(CategoryList.SelectedValue);
				int linkid=Links.CreateLink(link);
				if(linkid>0)
				{
					Message.Text="成功添加到收藏夹!";
					Submit.Visible=false;
					//string url= System.Configuration.ConfigurationSettings.AppSettings["AggregateUrl"]+"/"+UserName+"/admin/EditFavorite.aspx";
					//Response.Redirect(url);
				}
				else
				{
					Message.Text="添加到收藏夹出错";
				}
			}
		}

		private void Submit_Click(object sender, System.EventArgs e)
		{
			AddToFav();
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
			this.Submit.Click += new System.EventHandler(this.Submit_Click);
			this.btnNewCategory.Click += new System.EventHandler(this.btnNewCategory_Click);
			this.btnCreateCategory.Click += new System.EventHandler(this.btnCreateCategory_Click);
			this.btnReturnBefore.Click += new System.EventHandler(this.btnReturnBefore_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnNewCategory_Click(object sender, System.EventArgs e)
		{
			tbCreateCategory.Visible=true;
			tbAddFavorite.Visible=false;
		}

		private void btnCreateCategory_Click(object sender, System.EventArgs e)
		{
			LinkCategory category=new LinkCategory();
			category.CategoryType=CategoryType.FavoriteCollention;
			category.Title=tbCategoryName.Text;
			category.BlogID=config.BlogID;
			Links.CreateLinkCategory(category);
			tbCategoryName.Text=string.Empty;
			GetCategoryList();
			tbCreateCategory.Visible=false;
			tbAddFavorite.Visible=true;
		}

		private void btnReturnBefore_Click(object sender, System.EventArgs e)
		{
			tbCreateCategory.Visible=false;
			tbAddFavorite.Visible=true;
		}
	}
}
