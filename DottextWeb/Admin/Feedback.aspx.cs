#region Disclaimer/Info
///////////////////////////////////////////////////////////////////////////////////////////////////
// .Text WebLog
// 
// .Text is an open source weblog system started by Scott Watermasysk. 
// Blog: http://ScottWater.com/blog 
// RSS: http://scottwater.com/blog/rss.aspx
// Email: Dottext@ScottWater.com
//
// For updated news and information please visit http://scottwater.com/dottext and subscribe to 
// the Rss feed @ http://scottwater.com/dottext/rss.aspx
//
// On its release (on or about August 1, 2003) this application is licensed under the BSD. However, I reserve the 
// right to change or modify this at any time. The most recent and up to date license can always be fount at:
// http://ScottWater.com/License.txt
// 
// Please direct all code related questions to:
// GotDotNet Workspace: http://www.gotdotnet.com/Community/Workspaces/workspace.aspx?id=e99fccb3-1a8c-42b5-90ee-348f6b77c407
// Yahoo Group http://groups.yahoo.com/group/DotText/
// 
///////////////////////////////////////////////////////////////////////////////////////////////////
#endregion

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
	public class Feedback : AdminPage
	{
		private int _resultsPageNumber = 1;
		private bool _isListHidden = false;
		protected System.Web.UI.WebControls.Repeater rprSelectionList;
		protected Dottext.Web.Admin.WebUI.Pager ResultsPager;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Results;
		protected Dottext.Web.Admin.WebUI.MessagePanel Messages;
		protected Dottext.Web.Admin.WebUI.Page PageContainer;
	
		#region Accessors
//		private int CategoryID
//		{
//			get
//			{
//				if(ViewState["CategoryID"] != null)
//					return (int)ViewState["CategoryID"];
//				else
//					// REFACTOR: const
//					return -1;
//			}
//			set { ViewState["CategoryID"] = value; }
//		}
//
//		public CategoryType CategoryType
//		{
//			get
//			{
//				if(ViewState["CategoryType"] != null)
//					return (CategoryType)ViewState["CategoryType"];
//				else
//					throw new Exception("CategoryType was not set");
//			}
//			set { ViewState["CategoryType"] = value; }
//		}
		
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			string strNavUrl="Feedback.aspx?id=1";
			HyperLink hlNav = Utilities.CreateHyperLink("查看我发表过的评论",strNavUrl);
			PageContainer.AddToActions(hlNav);

			strNavUrl="Feedback.aspx?id=2";
			hlNav = Utilities.CreateHyperLink("查看TrackBack",strNavUrl);
			PageContainer.AddToActions(hlNav);

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

		//Bug: http://www.gotdotnet.com/Community/Workspaces/BugDetails.aspx?bugid=3418
		//Fixed. - Scott
		protected string GetBody(object dataItem)
		{
			Entry entry = (Entry)dataItem;
			if(entry.PostType == PostType.Comment)
			{
				return entry.Body;
			}
			return string.Format("{0}<br /><a target=\"_blank\" title=\"view: {1}\"  href=\"{2}\">Pingback/TrackBack</a>",entry.Body,entry.Title,entry.TitleUrl);
		}

		private void BindList()
		{
			//PagedEntryCollection selectionList = Entries.GetPagedFeedback(_resultsPageNumber, ResultsPager.PageSize,true);		

			PagedEntryQuery query = new	PagedEntryQuery();
			query.PostType = PostType.Comment|PostType.PingTrack;
			query.PageIndex = _resultsPageNumber;
			query.PageSize = ResultsPager.PageSize;
			if(Request.QueryString["id"]=="1")
			{
				query.PostType=PostType.Comment;
				query.BlogGroupID=1000;
				Results.HeaderText="发表过的评论";
				ResultsPager.UrlFormat="Feedback.aspx?id=1&pg={0}";
			}
			if(Request.QueryString["id"]=="2")
			{
				query.PostType=PostType.PingTrack;
				Results.HeaderText="TrackBack";
				ResultsPager.UrlFormat="Feedback.aspx?id=2&pg={0}";
			}
			
			PagedEntryCollection selectionList = Entries.GetPagedEntryCollection(query);

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

		private void rprSelectionList_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{				
			switch (e.CommandName.ToLower()) 
			{
				case "delete" :
					ConfirmDeleteComment(Convert.ToInt32(e.CommandArgument));
					break;
				default:
					break;
			}			
		}

		private void ConfirmDeleteComment(int feedbackID)
		{
			this.Command = new DeleteCommentCommand(feedbackID);
			this.Command.RedirectUrl = Request.Url.ToString();
			this.Command.TabSectionID=this.PageContainer.TabSectionID;
			Server.Transfer(Constants.URL_CONFIRM);
		}
		
		

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.rprSelectionList.ItemCommand += new System.Web.UI.WebControls.RepeaterCommandEventHandler(this.rprSelectionList_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}

