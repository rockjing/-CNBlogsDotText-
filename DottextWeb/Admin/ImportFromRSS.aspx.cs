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
using Dottext.Framework.Util;
namespace Dottext.Web.Admin.Pages
{
	/// <summary>
	/// ImportRSS 的摘要说明。
	/// </summary>
	public class ImportFromRSS : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBoxAddress;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected skmRss.RssFeed RssFeed1;
		protected System.Web.UI.WebControls.Button ButtonImport;
		protected Dottext.Web.Admin.WebUI.MessagePanel Messages;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Results;
		protected Dottext.Web.Admin.WebUI.Page PageContainer;
		protected System.Web.UI.WebControls.Button ButtonRead;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		private PostType _entryPostType;
		protected System.Web.UI.WebControls.Literal LiteralMsg;
		protected System.Web.UI.WebControls.CheckBox ckbIsOriginalTime;
		protected System.Web.UI.WebControls.CheckBox ckbIsShowImportFlag;
		
		private int ImportLimit=20;
		private int ImportSuccessCount=0;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			int intPostType=0;
			string strPostType=Request.QueryString[Keys.QRYSTR_CATEGORYID];
			if((strPostType!=null)&&(strPostType!=""))
			{
				intPostType=int.Parse(strPostType);
				if(intPostType==1)
				{
					PageContainer.TabSectionID="Posts";
					EntryPostType=PostType.BlogPost;
				}
				if(intPostType==2)
				{
					PageContainer.TabSectionID="Articles";
					EntryPostType=PostType.Article;
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
			this.ButtonImport.Click += new System.EventHandler(this.ButtonImport_Click);
			this.RssFeed1.ItemCreated += new skmRss.RssFeedItemEventHandler(this.RssFeed1_ItemCreated);
			this.RssFeed1.ItemDataBound += new skmRss.RssFeedItemEventHandler(this.RssFeed1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public PostType EntryPostType
		{
			get { return _entryPostType; }
			set { _entryPostType = value; }
		}

		private void ButtonRead_Click(object sender, System.EventArgs e)
		{
			RssFeed1.ShowHeader=true;
			RssFeed1.MaxItems=50;
			//RssFeed1.CacheDuration=
			RssFeed1.DataSource=TextBoxAddress.Text;
			RssFeed1.DataBind();
			ButtonImport.Visible=true;
			LiteralMsg.Visible=true;
			ckbIsOriginalTime.Visible=true;
			ckbIsShowImportFlag.Visible=true;
			LiteralMsg.Text="一次最多只能导入"+ImportLimit.ToString()+"条";
			
		}

		private void ButtonImport_Click(object sender, System.EventArgs e)
		{
				
			bool IsImport=false;
			int ImportedCount=0;
			string title="",description="",pubtime="",url="";
			Control con;
			skmRss.RssFeedItem item;
			//foreach (skmRss.RssFeedItem item in RssFeed1.Items)
			for(int ImportCount=0;(ImportCount<RssFeed1.Items.Count)&&(ImportedCount<ImportLimit);ImportCount++)
			{
				item=RssFeed1.Items[ImportCount];
				con=item.Cells[0].FindControl("CheckBox1");
				if(con!=null)
				{
					IsImport=((CheckBox)con).Checked&&((CheckBox)con).Enabled;
					
					
				}
				
				if(IsImport)
				{
					((CheckBox)con).Enabled=false;
					ImportedCount++;
					con=item.Cells[0].FindControl("LinkTitle");
					if(con!=null)
					{
						title=((HyperLink)con).Text;
						url=((HyperLink)con).NavigateUrl;
						//Response.Write(((HyperLink)con).Text.ToString());
					}
					
					con=item.Cells[0].FindControl("LiteralDate");
					if(con!=null)
					{
						pubtime=((Literal)con).Text;
						//Response.Write(((Literal)con).Text.ToString());
					}
					
					con=item.Cells[0].FindControl("LiteralDes");
					if(con!=null)
					{
						description=((Literal)con).Text;
						//Response.Write(((Literal)con).Text.ToString());
					}
					if(!InsertEntry(title,description,pubtime,url))
					{
						return;
					}
					//Response.Write("<br>");
				}
				
				
			}
			string tmpstr=String.Format("导入成功!共导入{0}条",ImportSuccessCount);
			this.Messages.ShowMessage(tmpstr);
			
		}

		private Control GetControl(TableCell cell,string ControlID)
		{
			Control con=cell.FindControl(ControlID);
			if(con!=null)
			{
				//con=((con.GetType().)con);
			}
			return con;
		}

		private bool InsertEntry(string title,string description,string pubtime,string url)
		{
			int PostID=0;

			if((title==null)||(title==""))
			{
				return false;
			}
			if((description==null)||(description==""))
			{
				return false;
			}
			if((pubtime==null)||(pubtime==""))
			{
				return false;
			}
			if((url==null)||(url==""))
			{
				return false;
			}
			

			if(url.IndexOf(Config.CurrentBlog().Host)>-1)
			{
				this.Messages.ShowMessage("不能从同一网站导入!");
				return false;
			}
			string lnkstr=String.Format("<br>文章来源:<a href='{0}'>{1}</a>",url,url);
			try
			{
				Entry entry = new Entry(EntryPostType);
				if(ckbIsShowImportFlag.Checked)
				{
					entry.Title = "[导入]"+title;
					entry.Body = description+lnkstr;
				}
				else
				{
					entry.Title = title;
					entry.Body=description;
				}
			
				if(ckbIsOriginalTime.Checked)
				{
					DateTime dt=DateTime.Parse(pubtime);
					//TimeSpan diff=dt.Subtract(DateTime.Now);
					//if(diff.TotalSeconds>1)
					//{
					//	dt=DateTime.Now;
					//}
					if(DateTime.Now.CompareTo(dt)<0)
					{
						dt=DateTime.Now;
					}
					entry.DateCreated=dt;
				}
				else
				{
					entry.DateCreated = BlogTime.CurrentBloggerTime;//DateTime.Parse(pubtime);
				}

				entry.IsActive = false;
				//entry.SourceName = txbSourceName.Text;
				entry.Author = Config.CurrentBlog().Author;
				entry.Email = Config.CurrentBlog().Email;
				entry.SourceUrl = url;//txbSourceUrl.Text;
				//entry.Description = txbExcerpt.Text;
				//entry.TitleUrl = txbTitleUrl.Text;

				entry.AllowComments = true;
				entry.DisplayOnHomePage = true;
				entry.IncludeInMainSyndication =true;
				//entry.SyndicateDescriptionOnly = true;
				entry.IsAggregated = true;
				entry.SyndicateDescriptionOnly=false;
				//entry.EntryName = txbEntryName.Text;
				entry.BlogID = Config.CurrentBlog(Context).BlogID;
				PostID = Entries.Create(entry);
				if (PostID > 0)
				{
					
					//Response.Write("导入成功");
					ImportSuccessCount++;	
					if(entry.PostType==PostType.BlogPost)
					{
						int[] Categories = new int[1];
						Categories[0]=807;
						Entries.SetEntryCategoryList(PostID,Categories);
					}
				}
				else
				{
					this.Messages.ShowMessage("导入失败:'"+title+"'");
					return false;
				}
			}
			catch(Exception ex)
			{
				this.Messages.ShowError(String.Format(Constants.RES_EXCEPTION, 
					Constants.RES_FAILUREEDIT, ex.Message));
				return false;
			}
			return true;
		}
		
		private int RssItemIndex=1;
		private void RssFeed1_ItemCreated(object sender, skmRss.RssFeedItemEventArgs e)
		{
			
		}

		private void RssFeed1_ItemDataBound(object sender, skmRss.RssFeedItemEventArgs e)
		{
			if(e.Item.Visible==true)
			{
				((System.Web.UI.WebControls.Literal)(e.Item.Cells[0].FindControl("sn"))).Text=RssItemIndex.ToString()+".";
				RssItemIndex++;
			}
		}
	}
}
