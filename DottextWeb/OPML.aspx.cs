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
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Dottext.Framework.Data;
using Dottext.Framework.Configuration;

using System.Xml;
using System.Text;
using System.IO;


namespace Dottext.Web
{
	/// <summary>
	/// Summary description for OPML.
	/// </summary>
	public class OPML : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			string sql = "blog_GetAggregatedBloggers";
			string conn = Dottext.Framework.Providers.DbProvider.Instance().ConnectionString;

			DataTable dt = SqlHelper.ExecuteDataset(conn,CommandType.StoredProcedure,sql).Tables[0];
			
			//Response.ContentEncoding = System.Text.Encoding.UTF8;
			//Response.Write(Opml.Write(dt,Request.ApplicationPath));
			Response.ContentType = "text/xml";
			Opml.Write(dt,Request.ApplicationPath,Response.OutputStream);
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

		#region OPML

		private class Opml
		{
			public Opml()
			{
				//
				// TODO: Add constructor logic here
				//
			}

			public static void Write(DataTable dt, string appPath,Stream OutStream)
			{
				if(!appPath.EndsWith("/"))
				{
					appPath += "/";
				}
				try
				{
					//StringWriter sw = new StringWriter();
					
					//XmlTextWriter writer = new XmlTextWriter(sw);
					XmlTextWriter writer = new XmlTextWriter(OutStream,System.Text.Encoding.UTF8);
					writer.Formatting = Formatting.Indented;
					writer.WriteStartDocument();

					//OPML ROOT
					writer.WriteStartElement("opml");

					//Body
					writer.WriteStartElement("body");

					int count = dt.Rows.Count;
					string baseUrl = "http://www.{0}" + appPath + "{1}";
					for(int i = 0; i< count; i++)
					{
						DataRow dr = dt.Rows[i];
						writer.WriteStartElement("outline");

						string title = (string)dr["Title"];
						string htmlUrl = string.Format(baseUrl,(string)dr["Host"],(string)dr["Application"]);
						string xmlUrl= htmlUrl + "/rss.aspx";

						writer.WriteAttributeString("title",title);
						writer.WriteAttributeString("htmlUrl",htmlUrl);
						writer.WriteAttributeString("xmlUrl",xmlUrl);

						writer.WriteEndElement();									
					}
					writer.WriteEndElement();
					writer.WriteEndElement();
					writer.Flush();
					writer.Close();
					//sw.Close();
					//return sw.ToString();

				}
				catch(Exception e)
				{
					throw e;
				}


			}
		}

		#endregion
	}
}

