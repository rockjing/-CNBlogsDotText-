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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Dottext.Framework.Configuration;
using Dottext.Framework;
using Dottext.Web.UI.Pages;

namespace Dottext.Web.Pages
{
	public class Error : Page
	{		
		protected System.Web.UI.WebControls.Label ErrorMessageLabel;
		protected System.Web.UI.WebControls.Label ErrorTitle;
		protected System.Web.UI.WebControls.HyperLink HomeLink;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{				
				try
				{				
					if (null != Config.CurrentBlog(Context))
						HomeLink.NavigateUrl = Config.CurrentBlog(Context).FullyQualifiedUrl;
				}
				catch
				{
					HomeLink.Visible = false;
				}

				string noExceptionFound = "No error message available.";
				StringBuilder exceptionMsgs = new StringBuilder();
				
				Exception ex = Server.GetLastError().GetBaseException();//.GetBaseException();
				while(null != ex) // this is obsolete since we're grabbing base...
				{
					if (ex is System.IO.FileNotFoundException)
					{
						exceptionMsgs.Append("<p>The resource you requested could not be found.</p>");
					}
					else
					{
						exceptionMsgs.AppendFormat("<p>{0}</p>", ex.Message);
					}
					
					
					if(!(ex is System.IO.FileNotFoundException) && !(ex is BlogDoesNotExistException) && ! (ex is HttpException))
					{
						Dottext.Framework.Logger.LogManager.CreateExceptionLog(ex,"Exception");
					}

					ex = ex.InnerException;
				}
			
				Server.ClearError();

				if(exceptionMsgs.Length == 0)
				{
					exceptionMsgs.Append(noExceptionFound);
				}

				/*if(exceptionMsgs.ToString().IndexOf("ItemCount")>0)
				{
					Dottext.Framework.Logger.LogManager.Log("ItemCount Exception",exceptionMsgs.ToString());
				}*/
				this.ErrorMessageLabel.Text = exceptionMsgs.ToString();

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
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}

