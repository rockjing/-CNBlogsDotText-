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
using System.Web.Caching;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
//using Dottext.Web.UI;
using Dottext.Framework;
using Dottext.Framework.Components;
using Dottext.Framework.Configuration;
//using Dottext.Web.UI.Skinning;

using System.Xml;

namespace Dottext.Web.Admin.Pages
{
	public class Configure : AdminPage
	{
		// abstract out at a future point for i18n
		private const string RES_SUCCESS = "Your configuration was successfully updated.";
		private const string RES_FAILURE = "Configuration update failed.";

		protected Dottext.Web.Admin.WebUI.AdvancedPanel Edit;
		protected System.Web.UI.WebControls.LinkButton lkbPost;
		protected System.Web.UI.WebControls.TextBox txbTitle;
		protected System.Web.UI.WebControls.TextBox txbSubtitle;
		protected System.Web.UI.WebControls.TextBox txbAuthor;
		protected System.Web.UI.WebControls.TextBox txbAuthorEmail;
		protected System.Web.UI.WebControls.DropDownList ddlSkin;
		protected System.Web.UI.WebControls.DropDownList ddlItemCount;
		protected System.Web.UI.WebControls.DropDownList ddlTimezone;
		protected System.Web.UI.WebControls.DropDownList ddlLangLocale;
		protected System.Web.UI.WebControls.CheckBox ckbAllowServiceAccess;
		protected System.Web.UI.WebControls.TextBox txbNews;
		protected System.Web.UI.WebControls.TextBox txbUser;
		protected System.Web.UI.WebControls.TextBox txbSecondaryCss;
		protected Dottext.Web.Admin.WebUI.MessagePanel Messages;
		protected System.Web.UI.WebControls.TextBox ReplyNotifyMail;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected Dottext.Web.Admin.WebUI.Page PageContainer;
	
		#region Accessors
		private int CategoryID
		{
			get { return (int)ViewState["CategoryID"]; }
			set { ViewState["CategoryID"] = value; }
		}

		public CategoryType CategoryType
		{
			get { return (CategoryType)ViewState["CategoryType"]; }
			set { ViewState["CategoryType"] = value; }
		}
		
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			#if WANRelease
			this.txbUser.Enabled = false;
			#endif
			
			if (!IsPostBack)
			{
				BindForm();
			}
		}

		private void BindForm()
		{
			BlogConfig config = Config.CurrentBlog(Context);
			txbTitle.Text = config.Title;
			txbSubtitle.Text = config.SubTitle;
			txbAuthor.Text = config.Author;
			txbAuthorEmail.Text = config.Email;
			ReplyNotifyMail.Text=config.NotifyMail;
			txbUser.Text = config.UserName;
			txbNews.Text = config.News;
			ckbAllowServiceAccess.Checked = config.AllowServiceAccess;
			ddlTimezone.Items.FindByValue(config.TimeZone.ToString()).Selected = true;

			try
			{
				ddlLangLocale.Items.FindByValue(config.Language).Selected = true;
			}
			catch{}
			
			
			if(config.Skin.HasSecondaryText)
			{
				txbSecondaryCss.Text = config.Skin.SkinCssText;
			}

			string path = Server.MapPath("~/skins");
			int len = path.Length + 1;
			FileInfo fi = new FileInfo(path);
			


			XmlDocument doc = (XmlDocument)Cache["SkinsDoc"];
			if(doc == null)
			{
				doc = new XmlDocument();
				string filename = Server.MapPath("~/Admin/Skins.config");
				doc.Load(filename);
				CacheDependency dep = new CacheDependency(filename);
				Cache.Insert("SkinsDoc",doc,dep);				
			}

			XmlNodeList nodes = doc.SelectNodes("//SkinTemplates/Skins/SkinTemplate");

			foreach(XmlNode node in nodes)
			{
				string css = node.Attributes["SecondaryCss"] != null ? "-" + node.Attributes["SecondaryCss"].Value : string.Empty;
				string name = node.Attributes["Skin"].Value +  css;
				//string id = node.Attributes["SkinID"].Value;
				ddlSkin.Items.Add(new ListItem(name,name));

			}
			try
			{
					ddlSkin.Items.FindByValue(config.Skin.SkinID).Selected = true;
			}
			catch
			{
				
			}

			int count = Config.Settings.ItemCount;
			for (int i = 1; i <=count; i++)
			{
				ddlItemCount.Items.Add(new ListItem(i.ToString(), i.ToString()));
			}

			if (config.ItemCount <= count)
			{
				ddlItemCount.Items.FindByValue(config.ItemCount.ToString()).Selected = true;
			}

		}

		private void BindPost()
		{
			try
			{
				BlogConfig config = Config.CurrentBlog(Context);
				config.Title = txbTitle.Text;
				config.SubTitle = txbSubtitle.Text;
				config.Author = txbAuthor.Text;
				config.Email = txbAuthorEmail.Text;
				config.NotifyMail=ReplyNotifyMail.Text;

				#if WANRelease
					config.UserName = txbUser.Text;
				#endif

				config.TimeZone = Int32.Parse(ddlTimezone.SelectedItem.Value);
				config.Application = Config.CurrentBlog().Application;
				config.Host = Config.CurrentBlog().Host;
				config.BlogID = Config.CurrentBlog().BlogID;

				config.ItemCount = Int32.Parse(ddlItemCount.SelectedItem.Value);
				config.Language = ddlLangLocale.SelectedItem.Value;
				
				config.AllowServiceAccess = ckbAllowServiceAccess.Checked;

				config.Skin.SkinCssText = txbSecondaryCss.Text.Trim();
			
				
				string news = txbNews.Text.Trim();
				config.News = news.Length == 0 ? null : news;


				string[] skins = ddlSkin.SelectedItem.Text.Split('-');

				//Need to add logic for a skin name that might include "-"
				config.Skin.SkinName = skins[0].Trim();
				

				if(skins.Length > 1)
				{
					config.Skin.SkinCssFile = skins[skins.Length-1].Trim();
				}
				else
				{
					config.Skin.SkinCssFile = null;
				}

				//config.ExtendedProperties = ext;
				
				Config.UpdateConfigData(config);

				this.Messages.ShowMessage(RES_SUCCESS);
			}
			catch(Exception ex)
			{
				this.Messages.ShowError(String.Format(Constants.RES_EXCEPTION, RES_FAILURE, ex.Message));
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);

			ViewState["CategoryID"] = Constants.NULL_CATEGORYID;
			ViewState["CategoryType"] = Constants.DEFAULT_CATEGORYTYPE;
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.txbSecondaryCss.TextChanged += new System.EventHandler(this.txbSecondaryCss_TextChanged);
			this.lkbPost.Click += new System.EventHandler(this.lkbPost_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lkbPost_Click(object sender, System.EventArgs e)
		{
			BindPost();
		}

		private void txbSecondaryCss_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}

