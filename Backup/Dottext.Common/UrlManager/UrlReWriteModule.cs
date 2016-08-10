using System;
using System.Web;
using System.Text.RegularExpressions;

using Dottext.Framework.Providers;
using df = Dottext.Framework.Configuration;

namespace Dottext.Common.UrlManager
{
	/// <summary>
	/// Summary description for UrlReWriteModule.
	/// </summary>
	public class UrlReWriteModule : System.Web.IHttpModule
	{
		static Regex regexPath = null;
		static Regex regexApplication = null;
		

		static UrlReWriteModule()
		{
			regexPath = new Regex(@"^/?(\w|-|_)+\.aspx$",RegexOptions.IgnoreCase|RegexOptions.Compiled);
			regexApplication = new Regex(HttpContext.Current.Request.ApplicationPath,RegexOptions.IgnoreCase|RegexOptions.Compiled);
		}

		public UrlReWriteModule()
		{
			
		}
		#region IHttpModule Members

		public void Init(HttpApplication context)
		{
			context.BeginRequest +=new EventHandler(context_BeginRequest); 
		}

		public void Dispose()
		{
			// TODO:  Add UrlReWriteModule.Dispose implementation
		}

		#endregion

		private bool AlllowService(HttpContext context)
		{
			return	( 
				
				df.Config.Settings.AllowServiceAccess &&
				(context.Request.RequestType.ToUpper() == "POST" || df.Config.CurrentBlog(context).AllowServiceAccess)
				);

		}

		private void context_BeginRequest(object sender, EventArgs e)
		{
			if(ConfigProvider.Instance().IsAggregateSite)
			{
				HttpContext context  = ((HttpApplication)sender).Context;

				string path = context.Request.Path.ToLower();
				int iExtraStuff = path.IndexOf(".aspx");
				if(iExtraStuff > -1 || path.IndexOf(".") == -1)
				{
					if(iExtraStuff > -1)
					{
						path = path.Remove(iExtraStuff+5,path.Length - (iExtraStuff+5));
					}

					path = regexApplication.Replace(path,string.Empty,1,0);

					if(path == "" || path == "/"  || regexPath.IsMatch(path))
					{
						UrlHelper.SetEnableUrlReWriting(context,false);
					}
					
				}
				else if(context.Request.Path.ToLower().IndexOf("services") > 0 && context.Request.Path.ToLower().IndexOf(".asmx") > 0 )
				{
					if(AlllowService(context))
					{
						if(context.Request.RequestType!="POST")
						{
							string regexstr=@"/\w+/services/";
							string url=Regex.Replace(context.Request.RawUrl,regexstr,"/services/",RegexOptions.IgnoreCase);
							context.RewritePath(url);
						}
						//string fileName =context.Request; //System.IO.Path.GetFileName(context.Request.Path);
						//context.RewritePath("~/Services/" + fileName);
					}
					else
					{
						context.Response.Clear();
						context.Response.End();
					}
				}
			
			}
		}
	}
}
