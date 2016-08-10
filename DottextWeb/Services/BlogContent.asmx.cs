#region Disclaimer/Info
///////////////////////////////////////////////////////////////////////////////////////////////////
// .Text WebLog
// Blog:		http://ScottWater.com/blog 
// RSS:			http://scottwater.com/blog/rss.aspx
// License:		http://scottwater.com/License
// Email:		Scott@TripleASP.NET
///////////////////////////////////////////////////////////////////////////////////////////////////
#endregion
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using Dottext.Framework.Components;
using Dottext.Framework;
using Dottext.Framework.Util;

namespace Dottext.Web.Services
{
	/// <summary>
	/// Summary description for BlogContent.
	/// </summary>
	[ WebService(Name=".Text Content",Description=".Text content provider service",Namespace="http://ScottWater.com/DotText/services/blogcontent/")]
	public class BlogContent : System.Web.Services.WebService
	{
		public BlogContent()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		[WebMethod(MessageName="GetEntries",Description="Requests the last X number of Blog Entries. The number is limited by the settings in the blog.config file. The return type, is an an Array of Entries",EnableSession=false)]
		public EntryCollection GetEntries(int ItemCount)
		{
			EntryQuery query = new EntryQuery(PostConfig.IsActive,PostType.BlogPost,Globals.AllowedItemCount(ItemCount));
			return Entries.GetEntryCollection(query);
			//return Entries.GetRecentPosts(Globals.AllowedItemCount(ItemCount),PostType.BlogPost,true);
		}

		[WebMethod(MessageName="GetEntriesByCategoryID",Description="Requests the last X number of Blog Entries By a specific category. The number is limited by the settings in the blog.config file. The return type, is an an Array of Entries",EnableSession=false)]
		public EntryCollection GetEntries(int ItemCount, int CategoryID)
		{
			EntryQuery query = new EntryQuery();
			query.PostType =PostType.BlogPost;
			query.PostConfig =  PostConfig.IsActive;
			query.ItemCount = Globals.AllowedItemCount(ItemCount);
			query.CategoryID = CategoryID;
			return Entries.GetEntryCollection(query);
		}

	}
}

