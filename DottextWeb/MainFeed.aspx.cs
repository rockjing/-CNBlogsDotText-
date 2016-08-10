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
using System.Web.Caching;
using System.IO;
using System.Xml;
using Dottext.Framework;
using Dottext.Framework.Configuration;
using Dottext.Framework.Util;


namespace Dottext.Web
{
	/// <summary>
	/// Summary description for OPML.
	/// </summary>
	public class RSSPage : System.Web.UI.Page
	{

		private string RSSTitle=UI.UIText.SiteTitle;
		private void Page_Load(object sender, System.EventArgs e)
		{
           	// int GroupID = 1;
			#region sp
			/*int ItemCount = 30;

			if(Request.QueryString["items"] !=null)
			{
				try
				{
					ItemCount = Int32.Parse(Request.QueryString["items"]);
				}
				catch{}
				
			}	
			string sql = "blog_GetAggregatedTechPosts";
			if(Request.QueryString["cate"]=="1")
			{
				sql = "blog_GetAggregatedTechPosts";
				RSSTitle+="技术区";
			}
			else if(Request.QueryString["cate"]=="2")
			{
				sql = "blog_GetAggregatedNoTechPosts";
				RSSTitle+="非技术区";
			}
			else if(Request.QueryString["cate"]=="3")
			{
				sql = "blog_GetAggregatedPosts";
				RSSTitle+="综合区";
			}
			else if(Request.QueryString["cate"]=="4")
			{
				sql = "blog_GetAggregatedPickedPosts ";
				RSSTitle+="精华区";
			}
			else if(Request.QueryString["cate"]=="5")
			{
				sql = "blog_GetAggregatedFAQPosts";
				RSSTitle+="提问区";

			}
			else if(Request.QueryString["cate"]=="6")
			{
				sql = "blog_GetAggregatedVIPPosts";
				RSSTitle+="专家区";
			}
			else if(Request.QueryString["cate"]=="7")
			{
				sql = "blog_GetAggregatedQuotePosts";
				RSSTitle+="转载区";
			}
			else if(Request.QueryString["cate"]=="8")
			{
				sql = "blog_GetAggregatedBookPosts";
				RSSTitle+="读书心得区";
			}
			else if(Request.QueryString["cate"]=="9")
			{
				sql = "blog_GetAggregatedProjectPosts";
				RSSTitle+="开源项目区";
			}
			else
			{
				sql = "blog_GetAggregatedTechPosts";
				RSSTitle+="首页技术区";
			}
			//sql = "DNW_GetRssPosts";
		

			SqlParameter[] p = 
				{
					SqlHelper.MakeInParam("@Host",SqlDbType.NVarChar,100,ConfigurationSettings.AppSettings["AggregateHost"] as string),
					SqlHelper.MakeInParam("@GroupID",SqlDbType.Int,4,GroupID),
					SqlHelper.MakeInParam("@ServerTimeZone",SqlDbType.Int,4,Config.Settings.ServerTimeZone)
				};
			SqlParameter[] p = 
				{
					SqlHelper.MakeInParam("@Host",SqlDbType.NVarChar,100,ConfigurationSettings.AppSettings["AggregateHost"] as string),
					SqlHelper.MakeInParam("@RowsCount",SqlDbType.Int,4,10)
				};*/
			#endregion

			string querystr="";
			//DataSet myds=new DataSet();
			//myds.ReadXml(UI.UIData.SiteCatalogXmlFile);
			//string url=Request.RawUrl.ToLower().Replace(Request.ApplicationPath.ToLower()+"/",string.Empty).ToLower();
			if(Request.QueryString["cate"]!=null)
			{
				querystr="cate='"+Request.QueryString["cate"]+"'";
			}
			else
			{
				querystr="default=1";
			}
			DataRow[] row=UI.UIData.SiteCatalogData.Tables[0].Select(querystr);
			if(row.Length>0)
			{
				Response.Redirect("~/rss.aspx?id="+row[0]["id"].ToString());
				//sql=row[0]["sp"].ToString();
				//RSSTitle+=row[0]["title"];

			}

			/*SqlParameter[] p = 
				{
					SqlHelper.MakeInParam("@Host",SqlDbType.NVarChar,100,ConfigurationSettings.AppSettings["AggregateHost"] as string),
					SqlHelper.MakeInParam("@GroupID",SqlDbType.Int,4,GroupID),
					SqlHelper.MakeInParam("@ServerTimeZone",SqlDbType.Int,4,Config.Settings.ServerTimeZone)
				};

			string conn = Dottext.Framework.Providers.DbProvider.Instance().ConnectionString;
			DataTable feedData = SqlHelper.ExecuteDataTable(conn,CommandType.StoredProcedure,sql,p);

			
			if(feedData != null && feedData.Rows.Count > 0)
			{
				//Response.ContentEncoding =System.Text.Encoding.GetEncoding("gb2312");
				Response.ContentType = "text/xml";
				//System.IO.File.
				//GetRSS(feedData,Request.ApplicationPath,stream);
				
				//sw.Close();
				GetRSS(feedData,Request.ApplicationPath,Response.OutputStream);
				//Response.
				//string rssXml =GetRSS(feedData,Request.ApplicationPath);
				//Response.ContentEncoding =System.Text.Encoding.UTF8;
				//Response.ContentType = "text/xml";
				//Response.Write(rssXml);
			}*/

		}

			private void GetRSS(DataTable dt, string appPath,Stream OutStream)
			{
				string baselink="",link="";
				//if(!appPath.EndsWith("/"))
				//{
				//	appPath += "/";
				//}
				try
				{
					//StringWriter sw = new StringWriter();
					//System.IO.MemoryStream ms=new MemoryStream();
					
					XmlTextWriter writer = new XmlTextWriter(OutStream,System.Text.Encoding.UTF8);//.GetEncoding("gb2312"));
					//XmlTextWriter writer = new XmlTextWriter(sw);
					writer.Formatting=Formatting.Indented;
					writer.WriteStartDocument();
					
					//writer.WriteStartDocument(true);
					//writer.WriteAttributeString("encoding","gb2312");
					//RSS ROOT
					writer.WriteStartElement("rss");
					writer.WriteAttributeString("version","2.0");
					
					writer.WriteAttributeString("xmlns:dc","http://purl.org/dc/elements/1.1/");
					writer.WriteAttributeString("xmlns:trackback","http://madskills.com/public/xml/rss/module/trackback/");
					writer.WriteAttributeString("xmlns:wfw","http://wellformedweb.org/CommentAPI/");
					writer.WriteAttributeString("xmlns:slash","http://purl.org/rss/1.0/modules/slash/");

					//Channel
					writer.WriteStartElement("channel");
					//Channel Description
					writer.WriteElementString("title",RSSTitle);
					writer.WriteElementString("link",Context.Request.Url.ToString().Replace("MainFeed","default"));
					writer.WriteElementString("description",ConfigurationSettings.AppSettings["AggregateDescription"] as string);
					writer.WriteElementString("generator",Dottext.Framework.VersionInfo.Version);

					int count = dt.Rows.Count;
					int servertz = Config.Settings.ServerTimeZone;
					//string baseUrl = "http://{0}" + appPath + "{1}/";

					bool useAggBugs = Config.Settings.Tracking.EnableAggBugs;

					for(int i = 0; i< count; i++)
					{
						DataRow dr = dt.Rows[i];

						writer.WriteStartElement("item");
						writer.WriteElementString("title",(string)dr["Title"]);
						
						baselink = Globals.GetFullUrl((string)dr["Host"],appPath,(string)dr["Application"]);//string.Format(baseUrl,(string)dr["Host"],(string)dr["Application"]);
						link = string.Format(baselink + "archive/{0}/{1}.aspx",((DateTime)dr["DateAdded"]).ToString("yyyy'/'MM'/'dd"),dr["EntryName"]);
						writer.WriteElementString("link",link);

						DateTime time = (DateTime)dr["DateAdded"];
						int tz = (int)dr["TimeZone"];
						int offset = (servertz - tz);
						
						
						writer.WriteElementString("pubDate",(time.AddHours(offset)).ToUniversalTime().ToString("r"));
						//writer.WriteElementString("guid",link);
						writer.WriteStartElement("guid");
						writer.WriteAttributeString("isPermaLink","true");
						writer.WriteString(link);
						writer.WriteEndElement();
						
						writer.WriteElementString("wfw:comment",string.Format(baselink + "comments/{0}.aspx",dr["ID"]));
						writer.WriteElementString("wfw:commentRss", string.Format(baselink + "comments/commentRss/{0}.aspx",dr["ID"]));
						writer.WriteElementString("comments",link + "#comment");
						if(dr["FeedBackCount"]!=DBNull.Value)
						{
							writer.WriteElementString("slash:comments",dr["FeedBackCount"].ToString());
						}
						writer.WriteElementString("trackback:ping",string.Format(baselink + "services/trackbacks/{0}.aspx",dr["ID"]));


						writer.WriteStartElement("source");
						writer.WriteAttributeString("url",baselink + "rss.aspx");
						writer.WriteString((string)dr["BlogTitle"]);
						writer.WriteEndElement();

						string desc = (string)dr["Description"];

						string aggText = useAggBugs ? Dottext.Framework.Tracking.TrackingUrls.AggBugImage(string.Format(baselink + "aggbug/{0}.aspx",dr["ID"])) : string.Empty;
	
						writer.WriteElementString("description",string.Format("{0}{1}",desc,aggText));
				
						if(dr["IsXHTML"] != DBNull.Value && (bool)dr["IsXHTML"])
						{

							writer.WriteStartElement("body");
							writer.WriteAttributeString("xmlns","http://www.w3.org/1999/xhtml");
							writer.WriteRaw((string)dr["Text"]);
							writer.WriteEndElement();

						}
						writer.WriteElementString("dc:creator",(string)dr["Author"]);	
						writer.WriteEndElement();
					
					}
					writer.WriteEndElement();
					
					writer.WriteEndElement();
					writer.Flush();
					writer.Close();
					

				}
				catch(Exception e)
				{
					throw e;
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

