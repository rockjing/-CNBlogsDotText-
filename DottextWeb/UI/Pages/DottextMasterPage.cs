using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Dottext.Web.UI;
using Dottext.Framework.Configuration;
using Dottext.Web.UI.Controls;
using Dottext.Web.AggSite;
using System.Text.RegularExpressions;


namespace Dottext.Web.UI.Pages
{
	/// <summary>
	/// Summary description for DottextMasterPage.
	/// </summary>
	public class DottextMasterPage : System.Web.UI.Page//DottextViewStatelessPage
	{

		public DottextMasterPage()
		{
		}

		protected System.Web.UI.WebControls.Literal pageTitle;
		protected System.Web.UI.HtmlControls.HtmlGenericControl MainStyle;
		protected System.Web.UI.HtmlControls.HtmlGenericControl SecondaryCss;
		protected System.Web.UI.HtmlControls.HtmlGenericControl RSSLink;
		protected System.Web.UI.WebControls.PlaceHolder CenterBodyControl;
		
		protected BlogConfig CurrentBlog;
		//protected const string TemplateLocation = "~/Skins/{0}/{1}";
		protected  string ControlLocation ;//= "~/Skins/{0}/Controls/{1}";
		protected const string ControlPath1 = "~/Skins/{0}/Controls/";
		protected const string ControlPath2 = "~/UI/Controls/";
		private void InitializeBlogPage()
		{
			CurrentBlog = Config.CurrentBlog(Context);
			string skin = CurrentBlog.Skin.SkinName;//Globals.Skin(Context);
			string[] controls = Dottext.Common.UrlManager.HandlerConfiguration.GetControls(Context);
			if(controls != null)
			{
				foreach(string control in controls)
				{
					//ControlLocation=string.Format(ControlLocation,skin,control);
					//modify by dudu
					string ControlPath_1=string.Format(ControlPath1,skin);
					if(System.IO.File.Exists(MapPath(ControlPath_1)+control))
					{
						ControlLocation=ControlPath_1+control;
					}
					else if(System.IO.File.Exists(MapPath(ControlPath2)+control))
					{
						ControlLocation=ControlPath2+control;
					}
					else if(System.IO.File.Exists(MapPath(CurrentBlog.Skin.ControlPath)+control))
					{
						ControlLocation=CurrentBlog.Skin.ControlPath+control;
					}
					else
					{
						throw new ApplicationException("Can not Find the "+control);
					}
				
					Control c = LoadControl(ControlLocation);//string.Format(ControlLocation,skin,control));
					c.ID = Regex.Replace(control,"(.ascx)$",string.Empty,RegexOptions.IgnoreCase)+"1";
					CenterBodyControl.Controls.Add(c);
				}
			}
			
			
			string path = CurrentBlog.Skin.SkinFullPath;//(Context.Request.ApplicationPath + "/skins/" + skin + "/").Replace("//","/");
			path=path.Replace("~",Context.Request.ApplicationPath);
			path=path.Replace("//","/");
			MainStyle.Attributes.Add("href",path+"style.css");
						
			if(CurrentBlog.Skin.HasSecondaryFile)
			{
				SecondaryCss.Attributes.Add("href",path + CurrentBlog.Skin.SkinCssFile);
			}
			else if(CurrentBlog.Skin.HasSecondaryText)
			{
				SecondaryCss.Attributes.Add("href",CurrentBlog.FullyQualifiedUrl  + "customcss.aspx");
			}
			else
			{
				//MAC IE does not like the empy CSS file..plus its a waste :)
				SecondaryCss.Visible = false;

			}
			
			RSSLink.Attributes.Add("href",CurrentBlog.FullyQualifiedUrl+"rss.aspx");
			
		}


		protected override void OnPreRender(EventArgs e)
		{
			this.EnableViewState = false;
			pageTitle.Text = Globals.CurrentTitle(Context);
			base.OnPreRender (e);
		}

		override protected void OnInit(EventArgs e)
		{
			InitializeBlogPage();
			base.OnInit(e);
		}

	}
}
