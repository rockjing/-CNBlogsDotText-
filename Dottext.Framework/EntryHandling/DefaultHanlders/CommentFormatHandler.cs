using System;
using Dottext.Framework.Configuration;
using Dottext.Framework.Components;
using Dottext.Framework.Util;

namespace Dottext.Framework.EntryHandling
{
	/// <summary>
	/// Responsible for valiating and formatting the Comment before it is save to the database.
	/// This Factory should happen Synchronously
	/// </summary>
	public class CommentFormatHandler : IEntryFactoryHandler
	{
		public CommentFormatHandler()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region IEntryFactoryHandler Members

		/// <summary>
		/// Responsible for valiating and formatting the Comment before it is save to the database.
		/// This Factory should happen Synchronously
		/// </summary>
		/// <param name="entry"></param>
		public void Process(Dottext.Framework.Components.Entry entry)
		{
			entry.Author = Globals.SafeFormat(entry.Author);
			entry.TitleUrl =  Globals.SafeFormat(entry.TitleUrl);
			if(Security.IsAuthenticated())//modify by dudu
			{
				if(entry.Body.IndexOf("<script>")>-1||entry.Body.IndexOf("</script>")>-1)
				{
					string body=entry.Body;
					entry.Body = Globals.FilterScript(body);
					
				}
									
			}
			else
			{
				entry.Body = Globals.SafeFormatWithUrl(entry.Body).Replace(" ","&nbsp;");
				if(entry.Body.Length>5000)
				{
					throw new BlogFailedPostException("ÄÚÈÝÌ«³¤");
				}
			}
			//entry.Body = Globals.SafeFormatWithUrl(entry.Body);
			entry.Title = Globals.SafeFormat(entry.Title);
			//entry.SourceUrl = Globals.PostsUrl(entry.ParentID);
			entry.IsXHMTL = false;
			entry.IsActive = true;
			entry.DateCreated = entry.DateUpdated = DateTime.Now;//BlogTime.CurrentBloggerTime;
		

			if (null == entry.SourceName || String.Empty == entry.SourceName)
				entry.SourceName = "N/A";

		}

		public void Configure(){}

		#endregion
	}
}
