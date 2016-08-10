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
using System.Web;
using System.Web.Caching;
using Dottext.Framework;
using Dottext.Framework.Util;
using Dottext.Framework.Components;
using Dottext.Framework.Configuration;
using Dottext.Framework.Syndication;
using DTCF = Dottext.Framework.Configuration;

using Dottext.Common.Data;
using System.IO;

namespace Dottext.Common.Syndication
{
	/// <summary>
	/// </summary>
	public abstract class EntryCollectionHandler : Dottext.Framework.Syndication.BaseSyndicationHandler
	{
		public EntryCollectionHandler()
		{
			//
			// TODO: Add constructor logic here
			//
		}	
	
		protected abstract EntryCollection GetFeedEntries();

		protected override bool IsLocalCacheOK()
		{
			string dt = LastModifiedHeader;
		
			if(dt != null)
			{
				EntryCollection ec = GetFeedEntries();

				if(ec != null && ec.Count > 0)
				{
					return DateTime.Compare(DateTime.Parse(dt),this.ConvertLastUpdatedDate(ec[0].DateCreated)) == 0;
				}
			}
			return false;			
		}

		protected override string CacheKey()
		{
			return null;
		}


		protected override void Cache(CachedFeed feed)
		{

		}


		//By default, we will assume the cached data objects will be used else where
		protected override bool IsHttpCacheOK()
		{
			return false;
		}

	



	}
}

