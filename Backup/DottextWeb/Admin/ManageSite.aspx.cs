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
using Dottext.Framework.Util;
using Dottext.Framework.Components;
using Dottext.Framework.Configuration;
using Dottext.Framework.Data;
using System.Data.SqlClient;

using Dottext.Search;
using Dottext.Framework.Logger;
using Dottext.Framework.Email;
using Dottext.Framework.Providers;

namespace Dottext.Web.Admin.Pages
{
	/// <summary>
	/// ManageGroup 的摘要说明。
	/// </summary>
	public class ManageSite : AdminPage
	{
		protected System.Web.UI.WebControls.TextBox txbUrl;
		protected System.Web.UI.WebControls.Button ButtonRead;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Results;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected Dottext.Web.Admin.WebUI.MessagePanel Messages;
		protected Entry entry;
		protected System.Web.UI.WebControls.Button btnPutTech;
		protected System.Web.UI.WebControls.Button btnDisableMain;
		protected System.Web.UI.WebControls.Button btnPutPicked;
		protected System.Web.UI.WebControls.RadioButtonList cklPickedCategory;
		protected System.Web.UI.WebControls.Literal Title;
		protected System.Web.UI.WebControls.Literal PostID;
		private string msg;
		protected System.Web.UI.WebControls.Literal ltBlogID;
		protected System.Web.UI.WebControls.Literal ltGroup;
		protected System.Web.UI.WebControls.RadioButtonList cklSiteGroups;
		protected System.Web.UI.WebControls.Button ButtonPickedRemove;
	
		protected Dottext.Web.Admin.WebUI.Page PageContainer;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			BindLocalUI();
			//this.PageContainer.TabSectionID="manage";
			if(!IsPostBack)
			{
				
				/*cklGroups.DataSource = Links.GetCategoriesByType(-1,CategoryType.Group,false);
				cklGroups.DataValueField = "CategoryID";
				cklGroups.DataTextField = "Title";
				cklGroups.DataBind();*/
				
			}
		}

		private void BindCategoryList()
		{
			cklSiteGroups.DataSource = Links.GetCategoriesByType(-1,CategoryType.Global,false);
			cklSiteGroups.DataValueField = "CategoryID";
			cklSiteGroups.DataTextField = "Title";
			cklSiteGroups.DataBind();
			LinkCollection lc=Links.GetLinkCollectionByPostID(int.Parse(ltBlogID.Text),int.Parse(PostID.Text));
			foreach (Link lnk in lc)
			{
			
				ListItem item=cklSiteGroups.Items.FindByValue(lnk.CategoryID.ToString());
				if(item!=null)
				{
					
					item.Selected=true;
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
			this.ButtonRead.Click += new System.EventHandler(this.ButtonRead_Click);
			this.btnPutTech.Click += new System.EventHandler(this.btnPutTech_Click);
			this.btnDisableMain.Click += new System.EventHandler(this.btnDisableMain_Click);
			this.btnPutPicked.Click += new System.EventHandler(this.btnPutPicked_Click);
			this.ButtonPickedRemove.Click += new System.EventHandler(this.ButtonPickedRemove_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ButtonRead_Click(object sender, System.EventArgs e)
		{
			
			string url=txbUrl.Text;
			string id;
			
			try
			{
				id= WebPathStripper.GetReqeustedFileName(url);
			}
			catch
			{
				Messages.ShowError("读取Url出错!");
				return;
			}
			
			if(url.ToLower().IndexOf(Config.Settings.AggregateHost)<0)
			{
				Messages.ShowError("非本站点Url, 无法进行管理!");
				return;
			}

			if(!WebPathStripper.IsNumeric(id))
			{
				Messages.ShowError("读取文章ID出错!");
				return;
			}
			
			entry=Entries.GetEntry(int.Parse(id));
			if(entry!=null)
			{
				Title.Text=entry.Title;
				Title.Visible=true;
				PostID.Text=entry.EntryID.ToString();
				PostID.Visible=true;
				ltBlogID.Text=entry.BlogID.ToString();
					
			}
			/*
			int startindex=url.LastIndexOf("/")+1;
			int stopindex=url.LastIndexOf(".");
			if(stopindex>startindex)
			{
				//Response.Write(url.Substring(startindex,stopindex-startindex));
				entry=Entries.GetEntry(int.Parse(url.Substring(startindex,stopindex-startindex)));
				if(entry!=null)
				{
					Title.Text=entry.Title;
					Title.Visible=true;
					PostID.Text=entry.EntryID.ToString();
					PostID.Visible=true;
					ltBlogID.Text=entry.BlogID.ToString();
					
				}
			}
			*/
			BindCategoryList();
			BindPickedCategory();

		}

		private void btnMove_Click(object sender, System.EventArgs e)
		{
			//Entries.Update(entry);
			/*ArrayList al = new ArrayList();
			int count = cklGroups.Items.Count;
			
			Link link=Links.GetSingleLink(int.Parse(LinkID.Text));
			link.CategoryID=int.Parse(cklGroups.SelectedItem.Value);
			Links.UpdateLink(link);
			Messages.Message="移动成功";*/
		}

		private void btnPutPicked_Click(object sender, System.EventArgs e)
		{
			
			if(cklPickedCategory.SelectedIndex<0)
			{
				Messages.ShowMessage("请选择一个精华区分类");
				return;
			}
			LinkCollection lc=Links.GetLinkCollectionByPostID(-1,int.Parse(PostID.Text));
			int cateid=int.Parse(cklPickedCategory.SelectedValue);
			foreach (Link alink in lc)
			{
				if(alink.CategoryID==cateid)
				{
					Messages.ShowMessage("精华区已存在该文章");
					return;
				}
				if(cklPickedCategory.Items.FindByValue(alink.CategoryID.ToString())!=null)
				{
					alink.CategoryID=cateid;
					Links.UpdateLink(alink);
					Messages.ShowMessage("成功更新\""+Title.Text+"\"精华区中的分类");
					return;
				}
			
			}
			Link link=new Link();
			link.BlogID=-1;//int.Parse(this.ltBlogID.Text);
			link.CategoryID=cateid;
			link.IsActive=true;
			link.Title=this.Title.Text;
			link.PostID=int.Parse(this.PostID.Text);
			Links.CreateLink(link);
			msg="将\""+Title.Text+"\"成功放入精华区";
			Messages.ShowMessage(msg);
			Dottext.Framework.Logger.LogManager.Log("放入精华区","["+User.Identity.Name+"]"+msg);
			this.SendMail();
		}

		private void SendMail()
		{
			try
			{
				// create and format an email to the site admin with comment details
				IMailProvider im = EmailProvider.Instance();
				Entry pickedEntry=Entries.GetEntry(int.Parse(PostID.Text));
				BlogConfig config=Config.GetConfig(pickedEntry.BlogID);	
				string To = config.NotifyMail;
				string From = Config.Settings.BlogProviders.EmailProvider.AdminEmail;
				string Subject = String.Format("[博客园邮件通知]你有文章被收入精华区");
				string Body = String.Format("你的文章({0})被收入精华区。\r\n谢谢你对博客园的支持！\r\n=====================================\r\n该邮件是系统自动生成,请不要回复该邮件", 
					pickedEntry.Title);			
				im.Send(To,From,Subject,Body);
			}
			catch(Exception e)
			{
				Dottext.Framework.Logger.LogManager.CreateExceptionLog(e,"SendMail");
			}
			
			
		}

		private void BindPickedCategory()
		{
			
			cklPickedCategory.DataSource = Links.GetCategoriesByType(-1,CategoryType.Picked,false);
			cklPickedCategory.DataValueField = "CategoryID";
			cklPickedCategory.DataTextField = "Title";
			cklPickedCategory.DataBind();
			LinkCollection lc=Links.GetLinkCollectionByPostID(-1,int.Parse(PostID.Text));
			foreach (Link alink in lc)
			{
				
				if(cklPickedCategory.Items.FindByValue(alink.CategoryID.ToString())!=null)
				{
					cklPickedCategory.Items.FindByValue(alink.CategoryID.ToString()).Selected=true;
				}
			
			}

		}

		private void btnPutTech_Click(object sender, System.EventArgs e)
		{
			ChangeGroup(int.Parse(cklSiteGroups.SelectedValue),cklSiteGroups.SelectedItem.Text);
			//PutGroup("技术区");
		}
	
		private void ChangeGroup(int categoryID,string GroupName)
		{
			LinkCollection lc=Links.GetLinkCollectionByPostID(int.Parse(ltBlogID.Text),int.Parse(PostID.Text));
			LinkCategoryCollection lcc=Links.GetCategoriesByType(-1,CategoryType.Global,false);
			msg="\""+Title.Text+"\"已放入"+GroupName;
			foreach (Link alink in lc)
			{
				//Messages.ShowMessage(techid.ToString());
				foreach(LinkCategory alc in lcc)
				{
					if(alink.CategoryID==alc.CategoryID)
					{
						alink.CategoryID=categoryID;
						Links.UpdateLink(alink);
						
						Messages.ShowMessage(msg);
						Dottext.Framework.Logger.LogManager.Log("放入"+GroupName,"["+User.Identity.Name+"]"+msg);
						BindCategoryList();
						
					}
					
				}
			}

		}
		private void PutGroup(string GroupName)
		{
			int techid=0;
			
			LinkCollection lc=Links.GetLinkCollectionByPostID(int.Parse(ltBlogID.Text),int.Parse(PostID.Text));
			LinkCategoryCollection lcc=Links.GetCategoriesByType(-1,CategoryType.Global,false);
			foreach(LinkCategory alc in lcc)
			{
				Messages.ShowMessage(alc.Title);
				if(alc.Title==GroupName)
				{
					techid=alc.CategoryID;
					break;
				}
			}
			if(techid==0)
			{
				
				return;
			}
			msg="\""+Title.Text+"\"已放入"+GroupName;
			//Messages.ShowMessage(techid.ToString());
			foreach (Link alink in lc)
			{
				//Messages.ShowMessage(techid.ToString());
				foreach(LinkCategory alc in lcc)
				{
					if(alink.CategoryID==alc.CategoryID)
					{
						alink.CategoryID=techid;
						Links.UpdateLink(alink);
						
						Messages.ShowMessage(msg);
						Dottext.Framework.Logger.LogManager.Log("放入"+GroupName,"["+User.Identity.Name+"]"+msg);
						BindCategoryList();
						//BindGroupSelect(techid.ToString());
						return;
					}
					
				}
			}
			Link link=new Link();
			link.BlogID=int.Parse(this.ltBlogID.Text);
			link.CategoryID=techid;
			link.IsActive=true;
			//link.Title=this.Title.Text;
			link.PostID=int.Parse(this.PostID.Text);
			Links.CreateLink(link);
			Messages.ShowMessage(msg);
			Dottext.Framework.Logger.LogManager.Log("放入"+GroupName,"["+User.Identity.Name+"]"+msg);
			BindCategoryList();
			//BindGroupSelect(techid.ToString());

		}

		private void btnPutNoTech_Click(object sender, System.EventArgs e)
		{
			PutGroup("非技术区");
		}

		private void BindGroupSelect(string id)
		{
			ListItem item=cklSiteGroups.Items.FindByValue(id);
			if(item!=null)
			{
					
				item.Selected=true;
			}
		}

		private void ButtonPickedRemove_Click(object sender, System.EventArgs e)
		{
			LinkCollection lc=Links.GetLinkCollectionByPostID(-1,int.Parse(PostID.Text));
			LinkCategoryCollection lcc=Links.GetCategoriesByType(-1,CategoryType.Picked,false);
			foreach(Link lnk in lc)
			{
				foreach(LinkCategory lnkcate in lcc)
				{
					if(lnk.CategoryID==lnkcate.CategoryID)
					{
						Links.DeleteLink(lnk.LinkID);
						msg="将\""+Title.Text+"\"成功移出精华区";
						Messages.ShowMessage(msg);
						Dottext.Framework.Logger.LogManager.Log("移出精华区","["+User.Identity.Name+"]"+msg);
					}
				}
			}
		}

		private void btnDisableMain_Click(object sender, System.EventArgs e)
		{
			int PostConfig=29;
			string conn = Dottext.Framework.Providers.DbProvider.Instance().ConnectionString;

			SqlParameter[] p = 
				{
					SqlHelper.MakeInParam("@EntryID",SqlDbType.Int,4,int.Parse(PostID.Text)),
					SqlHelper.MakeInParam("@PostConfig",SqlDbType.Int,4,PostConfig)
				};
		
			int result=Dottext.Framework.Data.SqlHelper.ExecuteNonQuery(conn,CommandType.StoredProcedure,"blog_UpdatePostConfig",p);
			if(result>0)
			{
				msg="已成功禁止显示在首页";
				Messages.ShowMessage(msg);
				Dottext.Framework.Logger.LogManager.Log("禁止显示在首页","["+User.Identity.Name+"]"+msg);
			}
			else
			{
				msg="禁止显示在首页操作失败";
				Messages.ShowMessage(msg);
				Dottext.Framework.Logger.LogManager.Log("禁止显示在首页","["+User.Identity.Name+"]"+msg);
			}
			//DataTable feedData = SqlHelper.ExecuteDataTable(conn,CommandType.StoredProcedure,sql,p);
		}

		private void BindLocalUI()
		{
			if(Dottext.Framework.Security.IsInRole("administrators"))
			{
				string strEditCateUrl=String.Format("ManageRoles.aspx");
				HyperLink hlManageRoles = Utilities.CreateHyperLink("角色管理",strEditCateUrl);
				PageContainer.AddToActions(hlManageRoles);

				strEditCateUrl="ManageGlobalCategory.aspx";//String.Format("EditCategories.aspx?{0}={1}",Keys.QRYSTR_CATEGORYID,((int)CategoryType.Global).ToString());
				//ViewState["CategoryType"]=CategoryType.FavoriteCollention;
				HyperLink hlEditCategories = Utilities.CreateHyperLink("编辑网站分类",strEditCateUrl);
				PageContainer.AddToActions(hlEditCategories);

				strEditCateUrl=String.Format("EditCategories.aspx?{0}={1}",Keys.QRYSTR_CATEGORYID,((int)CategoryType.Picked).ToString());
				//ViewState["CategoryType"]=CategoryType.FavoriteCollention;
				hlEditCategories = Utilities.CreateHyperLink("编辑精华区分类",strEditCateUrl);
				PageContainer.AddToActions(hlEditCategories);

				HyperLink hlManageDataBase = Utilities.CreateHyperLink("数据库管理","ManageDataBase.aspx");
				PageContainer.AddToActions(hlManageDataBase);
				
				PageContainer.AddToActions(Utilities.CreateHyperLink("删除Blog帐户","ManageUserDelete.aspx"));

				/*LinkButton lkbBuildIndex = Utilities.CreateLinkButton("直接建立索引");
				lkbBuildIndex.CausesValidation = false;
				lkbBuildIndex.Click += new System.EventHandler(lkbBuildIndex_Click);
				PageContainer.AddToActions(lkbBuildIndex);

				LinkButton lkbReBuildIndex = Utilities.CreateLinkButton("调度建立索引");
				lkbReBuildIndex.CausesValidation = false;
				lkbReBuildIndex.Click += new System.EventHandler(lkbReBuildIndex_Click);
				PageContainer.AddToActions(lkbReBuildIndex);*/
			}
		}

		private void btnFAQ_Click(object sender, System.EventArgs e)
		{
			PutGroup("提问区");
		}

		private void lkbBuildIndex_Click(object sender, System.EventArgs e)
		{
			Messages.ShowMessage("成功建立索引");
			Log log = new Log();
			log.Title = "Search Index";
			log.Message = string.Format("Manual ({0}) Build",log.StartDate.ToShortDateString());

			IndexManager.RebuildSafeIndex(30);

			log.EndDate = DateTime.Now;
			
			LogManager.Create(log);
			
		}

		private void lkbReBuildIndex_Click(object sender, System.EventArgs e)
		{
			//IndexQueue que = new IndexQueue();
			//que.Run();
			//Dottext.Framework.Util.ManagedThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(que.Run));
			IndexQueue que=new IndexQueue();
			Messages.ShowMessage("建立索引已被成功调用度");
			Dottext.Framework.Util.ManagedThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(que.Run));
			
		}
	
	
	}
}
