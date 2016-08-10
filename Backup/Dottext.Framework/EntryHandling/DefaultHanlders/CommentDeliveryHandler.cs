using System;
using Dottext.Framework.Configuration;
using Dottext.Framework.Providers;
using Dottext.Framework.Email;
using Dottext.Framework.Components;
using Dottext.Framework.Util;

namespace Dottext.Framework.EntryHandling
{
	/// <summary>
	/// IEntryFactoryHandler for sending comments
	/// </summary>
	public class CommentDeliveryHandler : IEntryFactoryHandler
	{
		public CommentDeliveryHandler()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region IEntryFactoryHandler Members

		/// <summary>
		/// Sends a comment aynchronously, if the commenter is not the blog administrator
		/// </summary>
		/// <param name="e"></param>
		public void Process(Dottext.Framework.Components.Entry e)
		{
			if((!isAdmin)&&isEnableMailNotify)
			{
				try
				{
					// create and format an email to the site admin with comment details
					IMailProvider im = EmailProvider.Instance();
					
					string To = to;
					string From = Config.Settings.BlogProviders.EmailProvider.AdminEmail;
					string Subject = String.Format("[博客园回复通知]{0}[{1}]", e.Title, blogTitle);
					string Body = String.Format("{0}\r\n=====================================\r\n\r\n{1}\r\n\r\n=====================================\r\n作者: {2}\r\nUrl: {3}\r\nSource: {4}#{5}\r\nIP: {6}\r\n\r\n该邮件是系统自动生成,请不要回复该邮件", 
						//blogTitle,
						//e.SourceName,
						e.Title,					
						// we're sending plain text email by default, but body includes <br>s for crlf
						Globals.RemoveHtml(e.Body.Replace("<br>", "\n").Replace("&nbsp;"," ")), 
						e.Author,
						e.TitleUrl,
						e.SourceUrl,
						e.EntryID,e.SourceName);			
					
					im.Send(To,From,Subject,Body);
				}
				catch{}
			}
		}

		/// <summary>
		/// Grab items we might not have access to later
		/// </summary>
		public void Configure()
		{
			BlogConfig config = Config.CurrentBlog();
			blogTitle = config.Title;
			to = config.NotifyMail;
			isAdmin = Security.IsAdmin;
			isEnableMailNotify=config.IsMailNotify;
		}

		string blogTitle = null;
		string to = null;
		bool isAdmin;
		bool isEnableMailNotify;

		#endregion
	}
}
