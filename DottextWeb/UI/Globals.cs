using System;
using System.Web;

using Dottext.Framework;
using Dottext.Framework.Configuration;
using Dottext.Framework.Components;

namespace Dottext.Web.UI
{
	/// <summary>
	/// Summary description for Globals.
	/// </summary>
	public class Globals
	{
		private Globals()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static string Skin()
		{
			return Skin(HttpContext.Current);
		}

		public static string Skin(HttpContext context)
		{
			if(Config.CurrentBlog(context).Skin.SkinName == null)
			{
				Config.CurrentBlog(context).Skin.SkinName = "marvin2";
			}
			return Config.CurrentBlog(context).Skin.SkinName;
		}


		private static readonly string BlogPageTitle = "BlogPageTitle";

		/// <summary>
		/// This method will be called during PreRender. If no title was set via
		/// SetTitle(title, context), then we will default to the blog title
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public static string CurrentTitle(HttpContext context)
		{
			string title = (string)context.Items[BlogPageTitle];
			if(title == null)
			{
				title = Config.CurrentBlog(context).Title;
				if(title==null)
				{
					return UIText.SiteTitle;
				}
			}
			else
			{
				title = Config.CurrentBlog(context).Title+"-"+title;
			}
			title=UIText.SiteTitle+"-"+title;
			return title;
		}

		//Allow the title to be set from anywhere in the request
		public static void SetTitle(string title, HttpContext context)
		{
			context.Items[BlogPageTitle] = title;
		}

		public static string RemoveHtml(string htmstr)
		{
			return Dottext.Framework.Util.Globals.RemoveHtml(htmstr);
		}

		public static bool CheckContorVisible(string ControlName)
		{
			SkinControlCollection scc=SkinControls.GetSkinControlCollection(Config.CurrentBlog().BlogID);
			foreach (SkinControl sc in scc)
			{
				if(sc.Control==ControlName && sc.Visible==false)
				{
					return false;
				}
			}
			return true;
		}

		public static void RegisterMyScript(System.Web.UI.Page page,string fileName)
		{
			if(page==null)
			{
				return;
			}
			System.IO.StreamReader sr=new System.IO.StreamReader(page.MapPath("~/Script")+"\\"+fileName);
			try
			{
				page.RegisterClientScriptBlock(fileName.Substring(0,fileName.IndexOf(".")+1),sr.ReadToEnd());
			}
            finally
			{
				if(sr!=null)
				{
					sr.Close();
				}
			}
		}

		
	}
}
