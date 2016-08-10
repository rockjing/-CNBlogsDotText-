#region Disclaimer/Info
///////////////////////////////////////////////////////////////////////////////////////////////////
// .Text WebLog
// Blog:		http://ScottWater.com/blog 
// RSS:			http://scottwater.com/blog/rss.aspx
// License:		http://scottwater.com/License
// Email:		Scott@TripleASP.NET
///////////////////////////////////////////////////////////////////////////////////////////////////
#endregion

namespace Dottext.Web.UI.Controls
{
	using System;
	using System.Data;
	using System.Data.SqlClient;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Dottext.Framework;
	using Dottext.Framework.Components;
	using Dottext.Framework.Configuration;
	using Dottext.Framework.Data;

	[PartialCaching(60,null,null,"Blogger",false)]
	public  class HomePage : BaseControl
	{

		protected Dottext.Web.UI.Controls.DayCollection HomePageDays;

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			
			//HomePageDays.Days = Entries.GetHomePageEntries(Config.CurrentBlog(Context).ItemCount);
			EntryQuery query = new EntryQuery();
			query.PostConfig = PostConfig.DisplayOnHomePage|PostConfig.IsActive;
			query.ItemCount = CurrentBlog.ItemCount;
			query.PostType = PostType.BlogPost;
			if(Request.QueryString["opt"]=="msg")
			{
				query.PostConfig=PostConfig.IsActive|PostConfig.DisplayOnHomePage;
				query.PostType=PostType.Message;
			}

			HomePageDays.Days = Entries.GetEntryDayCollection(query);

		}
	}
}

