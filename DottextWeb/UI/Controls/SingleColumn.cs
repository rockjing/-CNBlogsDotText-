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

namespace Dottext.Web.UI.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Dottext.Framework;
	using Dottext.Framework.Configuration;
	using Dottext.Framework.Components;

	using Dottext.Common.Data;


	/// <summary>
	///		Summary description for CategoryDisplayByColumn.
	/// </summary>
	public  class SingleColumn : CachedColumnControl
	{
		protected Dottext.Web.UI.Controls.CategoryList Categories;

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			//this.Controls.AddAt(0,this.Page.LoadControl("~/UI/Controls/Calendar.ascx"));
			this.Controls.AddAt(0,this.Page.LoadControl("~/UI/Controls/MyMessages.ascx"));
			Categories.LinkCategories = GetArchiveCategories();
			this.Controls.Add(this.Page.LoadControl("~/UI/Controls/MySearch.ascx"));
			this.Controls.Add(this.Page.LoadControl("~/UI/Controls/RecentComments.ascx"));
			this.Controls.Add(this.Page.LoadControl("~/UI/Controls/TopViewPosts.ascx"));
			this.Controls.Add(this.Page.LoadControl("~/UI/Controls/TopFeedbackPosts.ascx"));
		}

		protected LinkCategoryCollection GetArchiveCategories()
		{
			string key = this.ControlCacheKey;
			LinkCategoryCollection lcc = (LinkCategoryCollection)Cache[key];
			if(lcc == null)
			{
				lcc = new LinkCategoryCollection();

				string fqu = CurrentBlog.FullyQualifiedUrl;

				if(Globals.CheckContorVisible("Post"))
				{
					lcc.Add(UIData.Links(CategoryType.PostCollection,CurrentBlog.UrlFormats));//随笔分类
				}
			
				if(Globals.CheckContorVisible("PostArchive"))
				{
					lcc.Add(UIData.ArchiveMonth(CurrentBlog.UrlFormats,PostType.BlogPost));//随笔档案
				}

				if(Globals.CheckContorVisible("Article"))
				{
					lcc.Add(UIData.Links(CategoryType.StoryCollection,CurrentBlog.UrlFormats));//文章分类			
				}
			
				if(Globals.CheckContorVisible("ArticleArchive"))
				{
					lcc.Add(UIData.ArchiveMonth(CurrentBlog.UrlFormats,PostType.Article));//文章档案
				}

			
				if(Globals.CheckContorVisible("Image"))
				{
					lcc.Add(UIData.Links(CategoryType.ImageCollection,CurrentBlog.UrlFormats));
				}
				if(Globals.CheckContorVisible("Favorite"))
				{
					lcc.Add(UIData.Links(CategoryType.FavoriteCollention,CurrentBlog.UrlFormats));
				}
				if(Globals.CheckContorVisible("Link"))
				{
					lcc.AddRange(Links.GetCategoriesWithLinks(true));
				}
				Cacher.CacherCache(key,Context,lcc,CacheTime.Long);
			}
			
			return lcc;
		}

	}
}

