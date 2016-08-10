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
	/// ManageGroup ��ժҪ˵����
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
				Messages.ShowError("��ȡUrl����!");
				return;
			}
			
			if(url.ToLower().IndexOf(Config.Settings.AggregateHost)<0)
			{
				Messages.ShowError("�Ǳ�վ��Url, �޷����й���!");
				return;
			}

			if(!WebPathStripper.IsNumeric(id))
			{
				Messages.ShowError("��ȡ����ID����!");
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
			Messages.Message="�ƶ��ɹ�";*/
		}

		private void btnPutPicked_Click(object sender, System.EventArgs e)
		{
			
			if(cklPickedCategory.SelectedIndex<0)
			{
				Messages.ShowMessage("��ѡ��һ������������");
				return;
			}
			LinkCollection lc=Links.GetLinkCollectionByPostID(-1,int.Parse(PostID.Text));
			int cateid=int.Parse(cklPickedCategory.SelectedValue);
			foreach (Link alink in lc)
			{
				if(alink.CategoryID==cateid)
				{
					Messages.ShowMessage("�������Ѵ��ڸ�����");
					return;
				}
				if(cklPickedCategory.Items.FindByValue(alink.CategoryID.ToString())!=null)
				{
					alink.CategoryID=cateid;
					Links.UpdateLink(alink);
					Messages.ShowMessage("�ɹ�����\""+Title.Text+"\"�������еķ���");
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
			msg="��\""+Title.Text+"\"�ɹ����뾫����";
			Messages.ShowMessage(msg);
			Dottext.Framework.Logger.LogManager.Log("���뾫����","["+User.Identity.Name+"]"+msg);
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
				string Subject = String.Format("[����԰�ʼ�֪ͨ]�������±����뾫����");
				string Body = String.Format("�������({0})�����뾫������\r\nлл��Բ���԰��֧�֣�\r\n=====================================\r\n���ʼ���ϵͳ�Զ�����,�벻Ҫ�ظ����ʼ�", 
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
			//PutGroup("������");
		}
	
		private void ChangeGroup(int categoryID,string GroupName)
		{
			LinkCollection lc=Links.GetLinkCollectionByPostID(int.Parse(ltBlogID.Text),int.Parse(PostID.Text));
			LinkCategoryCollection lcc=Links.GetCategoriesByType(-1,CategoryType.Global,false);
			msg="\""+Title.Text+"\"�ѷ���"+GroupName;
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
						Dottext.Framework.Logger.LogManager.Log("����"+GroupName,"["+User.Identity.Name+"]"+msg);
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
			msg="\""+Title.Text+"\"�ѷ���"+GroupName;
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
						Dottext.Framework.Logger.LogManager.Log("����"+GroupName,"["+User.Identity.Name+"]"+msg);
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
			Dottext.Framework.Logger.LogManager.Log("����"+GroupName,"["+User.Identity.Name+"]"+msg);
			BindCategoryList();
			//BindGroupSelect(techid.ToString());

		}

		private void btnPutNoTech_Click(object sender, System.EventArgs e)
		{
			PutGroup("�Ǽ�����");
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
						msg="��\""+Title.Text+"\"�ɹ��Ƴ�������";
						Messages.ShowMessage(msg);
						Dottext.Framework.Logger.LogManager.Log("�Ƴ�������","["+User.Identity.Name+"]"+msg);
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
				msg="�ѳɹ���ֹ��ʾ����ҳ";
				Messages.ShowMessage(msg);
				Dottext.Framework.Logger.LogManager.Log("��ֹ��ʾ����ҳ","["+User.Identity.Name+"]"+msg);
			}
			else
			{
				msg="��ֹ��ʾ����ҳ����ʧ��";
				Messages.ShowMessage(msg);
				Dottext.Framework.Logger.LogManager.Log("��ֹ��ʾ����ҳ","["+User.Identity.Name+"]"+msg);
			}
			//DataTable feedData = SqlHelper.ExecuteDataTable(conn,CommandType.StoredProcedure,sql,p);
		}

		private void BindLocalUI()
		{
			if(Dottext.Framework.Security.IsInRole("administrators"))
			{
				string strEditCateUrl=String.Format("ManageRoles.aspx");
				HyperLink hlManageRoles = Utilities.CreateHyperLink("��ɫ����",strEditCateUrl);
				PageContainer.AddToActions(hlManageRoles);

				strEditCateUrl="ManageGlobalCategory.aspx";//String.Format("EditCategories.aspx?{0}={1}",Keys.QRYSTR_CATEGORYID,((int)CategoryType.Global).ToString());
				//ViewState["CategoryType"]=CategoryType.FavoriteCollention;
				HyperLink hlEditCategories = Utilities.CreateHyperLink("�༭��վ����",strEditCateUrl);
				PageContainer.AddToActions(hlEditCategories);

				strEditCateUrl=String.Format("EditCategories.aspx?{0}={1}",Keys.QRYSTR_CATEGORYID,((int)CategoryType.Picked).ToString());
				//ViewState["CategoryType"]=CategoryType.FavoriteCollention;
				hlEditCategories = Utilities.CreateHyperLink("�༭����������",strEditCateUrl);
				PageContainer.AddToActions(hlEditCategories);

				HyperLink hlManageDataBase = Utilities.CreateHyperLink("���ݿ����","ManageDataBase.aspx");
				PageContainer.AddToActions(hlManageDataBase);
				
				PageContainer.AddToActions(Utilities.CreateHyperLink("ɾ��Blog�ʻ�","ManageUserDelete.aspx"));

				/*LinkButton lkbBuildIndex = Utilities.CreateLinkButton("ֱ�ӽ�������");
				lkbBuildIndex.CausesValidation = false;
				lkbBuildIndex.Click += new System.EventHandler(lkbBuildIndex_Click);
				PageContainer.AddToActions(lkbBuildIndex);

				LinkButton lkbReBuildIndex = Utilities.CreateLinkButton("���Ƚ�������");
				lkbReBuildIndex.CausesValidation = false;
				lkbReBuildIndex.Click += new System.EventHandler(lkbReBuildIndex_Click);
				PageContainer.AddToActions(lkbReBuildIndex);*/
			}
		}

		private void btnFAQ_Click(object sender, System.EventArgs e)
		{
			PutGroup("������");
		}

		private void lkbBuildIndex_Click(object sender, System.EventArgs e)
		{
			Messages.ShowMessage("�ɹ���������");
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
			Messages.ShowMessage("���������ѱ��ɹ����ö�");
			Dottext.Framework.Util.ManagedThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(que.Run));
			
		}
	
	
	}
}
