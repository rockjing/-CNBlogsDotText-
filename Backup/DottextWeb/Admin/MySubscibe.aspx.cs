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

namespace Dottext.Web.Admin.Pages
{
	/// <summary>
	/// EditSubscibe 的摘要说明。
	/// </summary>
	public class MySubscribe : AdminPage
	{
		protected Dottext.Web.Admin.WebUI.Page PageContainer;
		protected Dottext.Web.Admin.WebUI.MessagePanel Messages;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Results;
		protected Dottext.Web.Admin.WebUI.Pager ResultsPager;
		protected System.Web.UI.WebControls.Repeater rprSelectionList;
		private int _resultsPageNumber = 1;
	    private bool _isListHidden = false;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Request.QueryString[Keys.QRYSTR_PAGEINDEX] != null)
					_resultsPageNumber = Convert.ToInt32(Request.QueryString[Keys.QRYSTR_PAGEINDEX]);

				ResultsPager.PageSize = Preferences.ListingItemCount;
				ResultsPager.PageIndex = _resultsPageNumber;
				Results.Collapsible = false;
				BindList();
				
			}		
		}

		private void BindList()
		{
			PagedEntryQuery eq=new PagedEntryQuery();
			eq.PostConfig=PostConfig.IsActive;
			eq.BlogGroupID=2000;
			eq.PostType=PostType.BlogPost|PostType.Article;
			eq.PageIndex = _resultsPageNumber;
			eq.PageSize = ResultsPager.PageSize;
			PagedEntryCollection selectionList = Entries.GetPagedEntryCollection(eq);
			//Response.Write(selectionList.Count);
			if (selectionList.Count > 0)
			{
				ResultsPager.ItemCount = selectionList.MaxItems;
				rprSelectionList.DataSource = selectionList;
				rprSelectionList.DataBind();
			}
			else
			{
				// TODO: no existing items handling. add label and indicate no existing items. pop open edit.
			}
		}

		public string CheckHiddenStyle()
		{
			if (_isListHidden)
				return Constants.CSSSTYLE_HIDDEN;
			else
				return String.Empty;
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
			this.rprSelectionList.ItemCommand += new System.Web.UI.WebControls.RepeaterCommandEventHandler(this.rprSelectionList_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void rprSelectionList_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{
			
			switch (e.CommandName.ToLower()) 
			{
				case "delete" :
					CancelSubscibe(Convert.ToInt32(e.CommandArgument));
					break;
				default:
					break;
			}		
			
		}

		private void CancelSubscibe(int entryID)
		{
			Entries.DeleteMailNotify(entryID,Dottext.Framework.Configuration.Config.CurrentBlog().BlogID);
			Messages.ShowMessage("取消订阅成功!");
			Response.Redirect(Request.RawUrl);
		}
	}
}
