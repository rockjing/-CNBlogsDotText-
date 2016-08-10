namespace Dottext.Web.AggSite
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	using Dottext.Search;
	using Dottext.Framework.Configuration;
	using Dottext.Framework.Logger;
	using MetaBuilders.WebControls;

	/// <summary>
	///		Summary description for Search.
	/// </summary>
	public class SiteAllSearch : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Literal ExecutionTime;
		protected System.Web.UI.WebControls.Literal TotalResults;
		protected System.Web.UI.WebControls.Repeater Results;
		protected Dottext.Web.UI.WebControls.Pager ResultsPager;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl ResultText;
		protected MetaBuilders.WebControls.DefaultButtons DefaultButtons1;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.HyperLink TitleLink;

		private bool _filterByBlog = true;
		
		/// <summary>
		/// Property FilterByBlog (bool)
		/// </summary>
		public bool FilterByBlog
		{
			get {return this._filterByBlog;}
			set {this._filterByBlog = value;}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			TitleLink.NavigateUrl=Config.Settings.AggregateUrl;
			ResultsPager.Visible = false;
			//Button1.Attributes.Add("onKeyDown","EnterPost()");
			if(!IsPostBack)
			{

				int pageIndex = 1;
				if(Request.QueryString["p"] != null)
				{
					pageIndex = Int32.Parse(Request.QueryString["p"]);
				}

				string searchText = Request.QueryString["q"];
				if(searchText != null && searchText.Trim().Length > 0)
				{
					//tbSearch.Text = searchText;
					Bind(searchText,pageIndex);

				}
				else
				{
					ResultText.Visible = false;
				}
			}
		}

		private void Bind(string searchText,int pageIndex)
		{			
			ResultSet searchResults =null;
			if(FilterByBlog)
			{
				searchResults = QueryIndex.SafeSearch(Config.CurrentBlog(Context).Application,SearchConfiguration.Blog,searchText,pageIndex,100);
			}
			else
			{
				//Group 1 will almost always be the entire community. If the group is > 1, filter by the current domain.
				if(Request.QueryString["GroupID"] != null && Int32.Parse(Request.QueryString["GroupID"]) > 1)
				{
					searchResults = QueryIndex.SafeSearch(Request.Url.Host.Replace("www.",string.Empty),SearchConfiguration.Domain,searchText,pageIndex,100);
				}
				else
				{
					searchResults = QueryIndex.SafeSearch(searchText,pageIndex,100);
					
				}
			}
			if(searchResults==null)
			{
				return;
			}
			
			Results.DataSource = searchResults.Results;
			Results.DataBind();
			TotalResults.Text = searchResults.Count > 0 ? searchResults.Count.ToString("#,#") : "0";
			ExecutionTime.Text = (searchResults.ExecutionTime/(float)10).ToString();
			ResultsPager.PageIndex = pageIndex;
			ResultsPager.PageSize = SearchConfiguration.Instance().PageSize;
			ResultsPager.UrlFormat = string.Format("{0}?q={1}&p={{0}}",Request.Path,Server.UrlEncode(searchText));
			ResultsPager.ItemCount = searchResults.Count;
			ResultText.Visible = true;
			if(searchResults.Count > 0)
			{
				ResultsPager.Visible = true;
				
			}
		}

		protected void ResultCreated(object sender,  RepeaterItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Result result = (Result)e.Item.DataItem;
				

				if(result != null)
				{
					ExpandingPanel panel = (ExpandingPanel)e.Item.FindControl("Expanel");
					panel.ExpansionControl = "ExpandButton";
					panel.ContractionControl = "ContractButton";
					panel.Expanded = false;

					panel.CssClass = "post";
					panel.ExpandedTemplate = new ExpandedTemplate(result);
					panel.ContractedTemplate = new CollapsedTemplate(result);
					
				}
			}
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/*private void Button1_Click(object sender, System.EventArgs e)
		{
			string searchText = tbSearch.Text;
			if(searchText.Trim().Length > 0)
			{
				if(DropDownList1.SelectedIndex>0)
				{
					searchText=DropDownList1.SelectedValue+":"+searchText;
				}
				LogManager.Log("Search Terms",tbSearch.Text);
				Response.Redirect(string.Format("{0}?q={1}",Request.Path,Server.UrlEncode(searchText)));
				Response.End();
			}
		}*/

		

		#region ITEMPLATES
		private class ExpandedTemplate : ITemplate
		{
			const string details = "<p class = \"details\"><a href=\"{0}\">{0}</a><br>Score {1} posted {2}</p>";
			Result _result = null;
			public ExpandedTemplate(Result result)
			{
				_result = result;
			}

			#region ITemplate Members

			public void InstantiateIn(Control container)
			{
				container.Controls.Add(new LiteralControl("<h5>"));

				LinkButton ContractButton = new LinkButton();
				ContractButton.ToolTip = "click to hide the post";
				ContractButton.ID = "ContractButton";
				ContractButton.CommandName = "Contract";
				ContractButton.Text = _result.Title;
				container.Controls.Add(ContractButton);

				

				container.Controls.Add(new LiteralControl("</h5>"));

				container.Controls.Add(new LiteralControl(_result.Body));

				container.Controls.Add(new LiteralControl(string.Format(details,_result.PermaLink, _result.Score.ToString("0.0000"),_result.DateCreatedString)));

			}

			#endregion

		}

		private class CollapsedTemplate : ITemplate
		{
			const string details = "<p class = \"details\"><a href=\"{0}\">{0}</a><br>Score {1} posted {2}</p>";
			Result _result = null;
			public CollapsedTemplate(Result result)
			{
				_result = result;
			}

			#region ITemplate Members

			public void InstantiateIn(Control container)
			{
				container.Controls.Add(new LiteralControl("<h5>"));

				LinkButton ExpandButton = new LinkButton();
				ExpandButton.ToolTip = "click to view the full post";
				ExpandButton.ID = "ExpandButton";
				ExpandButton.CommandName = "Expand";
				ExpandButton.Text = _result.Title;
				container.Controls.Add(ExpandButton);

				

				container.Controls.Add(new LiteralControl("</h5>"));

				string rawPost = _result.RawPost;
				if(rawPost.Length <= 100)
				{
					container.Controls.Add(new LiteralControl(_result.RawPost));
				}
				else
				{
					int i = 100;
					int len = rawPost.Length-1;
					while(!Char.IsWhiteSpace(rawPost[i]) && i < len)
					{
						i++;
					}
					container.Controls.Add(new LiteralControl(string.Format("{0} ...",_result.RawPost.Substring(0,i))));
				}

				container.Controls.Add(new LiteralControl(string.Format(details,_result.PermaLink, _result.Score.ToString("0.0000"),_result.DateCreatedString)));

			}

			#endregion

		}
		#endregion
	}
}
