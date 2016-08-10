using System;
using Dottext.Framework.Components;

namespace Dottext.Framework.EntryHandling
{
	/// <summary>
	/// WebServicePost 的摘要说明。
	/// </summary>
	public class WebServicePostHandler : IEntryFactoryHandler
	{
		public WebServicePostHandler()
		{
			
		}

		#region IEntryFactoryHandler Members

		public void Configure(){}

		public void Process(Dottext.Framework.Components.Entry e)
		{
			localhost.SBSSimpleBlogService wsclient=new Dottext.Framework.localhost.SBSSimpleBlogService("http://localhost/Services/SimpleBlogService.asmx");
			
			wsclient.InsertPost("dudu","Phpc#1305",e.DateCreated,e.Title,e.Body,e.TitleUrl);
		}

		#endregion
	
	}
}
