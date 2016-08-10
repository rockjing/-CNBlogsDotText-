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
using System.IO;
using System.Text;
using System.Xml;
using Dottext.Framework.Components;
using Dottext.Framework.Configuration;
using Dottext.Framework.Util;
using System.Web;

using Dottext.Common.Data;

namespace Dottext.Common.Syndication
{
	//Same code as RssWriter. Need to refactor these two to use 1  generic base.

	/// <summary>
	/// Generates CommentRssWriter 
	/// </summary>
	public class CommentRssWriter : Dottext.Framework.Syndication.BaseRssWriter
	{

		private Entry CommentEntry = null;

		
		public CommentRssWriter(EntryCollection ec, Entry ce):base()
		{
			this.Entries = ec;
			this.CommentEntry = ce;
			this.UseAggBugs = false;
			this.AllowComments = false;
		}

		protected override void WriteChannel()
		{
			this.BuildChannel(CommentEntry.Title,CommentEntry.Link,CommentEntry.Author,CommentEntry.HasDescription ? CommentEntry.Description : CommentEntry.Body,config.Language);
		}

	}
}

