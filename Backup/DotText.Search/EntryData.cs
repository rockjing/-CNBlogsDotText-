#region Disclaimer/Info
///////////////////////////////////////////////////////////////////////////////////////////////////
// .Text WebLog
// Blog:		http://ScottWater.com/blog 
// RSS:			http://scottwater.com/blog/rss.aspx
// License:		http://scottwater.com/License
// Email:		Scott@TripleASP.NET
///////////////////////////////////////////////////////////////////////////////////////////////////
#endregion
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.IO;

using Dottext.Framework.Components;
using Dottext.Framework.Data;
using Dottext.Framework.Configuration;
using Dottext.Framework.Providers;

using Lucene.Net.Documents;

namespace Dottext.Search
{
	//Need to add method for updating/adding single items. 

	/// <summary>
	/// EntryData is responsible for querying the .Text datastore for available entries. At the moment, it only supports SQL Server. 
	/// In addition, it only supports a complete rebuid.
	/// </summary>
	public class EntryData
	{
		private Weighter weighter = null;

		public  EntryData()	{
			weighter = new Weighter();

		}

		

		/*public ArrayList IndexDocuments(string hosts)
		{
			
			string sql = "blog_aggregate_Search";
			SqlParameter[] p = {SqlHelper.MakeInParam("@Hosts",SqlDbType.VarChar,400,hosts)};
			IDataReader reader = SqlHelper.ExecuteReader(Config.Settings.BlogProviders.DbProvider.ConnectionString,CommandType.StoredProcedure,sql,p);
			return BuildItems(reader);
		}*/

		/// <summary>
		/// Converts a DataReader to an ArrayList of IndexItems
		/// </summary>
		/// <param name="reader">A datareader of posts/articles from a .Text datastore</param>
		/// <returns>an Arraylist of ItemIndexes</returns>
		/*private ArrayList BuildItems(IDataReader reader)
		{
			try
			{
				ArrayList al = new ArrayList();
				while(reader.Read())
				{
					al.Add(CreateDoc(reader));
				}
				reader.Close();
				return al;
			}
			finally
			{
				reader.Close();
			}
		}*/

		public void BuildItems(string hosts,Indexer index)
		{
			string sql = "blog_aggregate_Search";
			string key="BuildIndex";
			DateTime LastCompleted =DTOProvider.Instance().GetLastExecuteScheduledEventDateTime(key,Environment.MachineName);
			//Dottext.Framework.Logger.LogManager.Log(" LastCompleted", LastCompleted.ToString());
			SqlParameter[] p = {SqlHelper.MakeInParam("@StartDate",SqlDbType.DateTime,8,LastCompleted)};
            //IDataReader reader = SqlHelper.ExecuteReader(Config.Settings.BlogProviders.DbProvider.ConnectionString,CommandType.StoredProcedure,sql,p);
			DataTable table= SqlHelper.ExecuteDataset(Config.Settings.BlogProviders.DbProvider.ConnectionString,CommandType.StoredProcedure,sql,p).Tables[0];
			LastCompleted = DateTime.Now;
			DTOProvider.Instance().SetLastExecuteScheduledEventDateTime(key,Environment.MachineName,LastCompleted);
			try
			{
				/*int count=1;
				while(reader.Read())
				{
					index.AddDocument(CreateDoc(reader));
					count++;
				}*/
				for(int i=0;i<table.Rows.Count;i++)
				{
					index.AddDocument(CreateDoc(table.Rows[i]));
				}
				Dottext.Framework.Logger.LogManager.Log("Index Builded",string.Format("Builded {0} Items",table.Rows.Count.ToString()));
				//reader.Close();
				
			}
			catch(Exception e)
			{
				Dottext.Framework.Logger.LogManager.CreateExceptionLog(e,"BuildItems");
			}
			finally
			{
				table.Clear();
				table.Dispose();
				//reader.Close();
			}
		}

		/// <summary>
		/// Creates an individual Lucenen Document (the object which actually gets added to the index)
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		private Document CreateDoc(IDataReader reader)
		{
			//Null values are not allowed in the index
			
			Document doc = new Document();
			try
			{
				doc.Add(Field.Text(SearchConfiguration.Author,(string)reader["Author"]));

				doc.Add(Field.Text(SearchConfiguration.Title,(string)reader["Title"]));

				string body = (string)reader["Text"];
				doc.Add(Field.UnIndexed(SearchConfiguration.Body,body));
				doc.Add(Field.Text(SearchConfiguration.Link,string.Join(" ",GetLinks(body))));
				doc.Add(Field.Text(SearchConfiguration.RawPost,regexStripHTML.Replace(body,string.Empty)));

				DateTime dateCreated = (DateTime)reader["DateAdded"];
				doc.Add(Field.UnIndexed(SearchConfiguration.DateCreated,dateCreated.ToLongDateString()));

				string app = (string)reader["Application"];
				doc.Add(Field.Text(SearchConfiguration.Blog,app));

				//Do we really need this?
				//doc.Add(Field.Text(SearchConfiguration.Description,reader["Description"].ToString()));

				string host = (string)reader["Host"];
				doc.Add(Field.Text(SearchConfiguration.Domain,host));


				int posttype = (int)reader["PostType"];		
				doc.Add(Field.UnIndexed(SearchConfiguration.PostType,posttype.ToString()));

				string permaLink  = null;
				if((PostType)posttype == PostType.BlogPost)
				{
					permaLink = string.Format(SearchConfiguration.Instance().UrlFormat,host,app, "archive/" + dateCreated.ToString("yyyy'/'MM'/'dd"),reader["EntryID"]);
				}
				else if((PostType)posttype == PostType.Comment)
				{
					permaLink =	reader["SourceUrl"].ToString()+"#"+reader["EntryID"].ToString();
				}
				else
				{
					permaLink = string.Format(SearchConfiguration.Instance().UrlFormat,host,app, "articles",reader["EntryID"]);
				}

				int feedbackCount = (int)reader["FeedbackCount"];
				int webviewCount = (int)reader["WebViewCount"];

				int boost = weighter.Calculate(body.Length,feedbackCount,webviewCount,dateCreated,(PostType)posttype);
				doc.SetBoost(boost);

				doc.Add(Field.UnIndexed(SearchConfiguration.BoostFactor,boost.ToString()));

				doc.Add(Field.UnIndexed(SearchConfiguration.PermaLink,permaLink));
			}
			catch(Exception e)
			{
				Dottext.Framework.Logger.LogManager.Log("CreateDoc Fail","EntryID is "+reader["EntryID"]);
			}
			
			return doc;
		}

		private Document CreateDoc(DataRow reader)
		{
			//Null values are not allowed in the index
			
			Document doc = new Document();
			try
			{
				doc.Add(Field.Text(SearchConfiguration.Author,(string)reader["Author"]));

				doc.Add(Field.Text(SearchConfiguration.Title,(string)reader["Title"]));

				string body = (string)reader["Text"];
				doc.Add(Field.UnIndexed(SearchConfiguration.Body,body));
				doc.Add(Field.Text(SearchConfiguration.Link,string.Join(" ",GetLinks(body))));
				doc.Add(Field.Text(SearchConfiguration.RawPost,regexStripHTML.Replace(body,string.Empty)));

				DateTime dateCreated = (DateTime)reader["DateAdded"];
				doc.Add(Field.UnIndexed(SearchConfiguration.DateCreated,dateCreated.ToLongDateString()));

				string app = (string)reader["Application"];
				doc.Add(Field.Text(SearchConfiguration.Blog,app));

				//Do we really need this?
				//doc.Add(Field.Text(SearchConfiguration.Description,reader["Description"].ToString()));

				string host = (string)reader["Host"];
				doc.Add(Field.Text(SearchConfiguration.Domain,host));


				int posttype = (int)reader["PostType"];		
				doc.Add(Field.UnIndexed(SearchConfiguration.PostType,posttype.ToString()));

				string permaLink  = null;
				if((PostType)posttype == PostType.BlogPost)
				{
					permaLink = string.Format(SearchConfiguration.Instance().UrlFormat,host,app, "archive/" + dateCreated.ToString("yyyy'/'MM'/'dd"),reader["EntryID"]);
				}
				else if((PostType)posttype == PostType.Comment)
				{
					permaLink =	reader["SourceUrl"].ToString()+"#"+reader["EntryID"].ToString();
				}
				else
				{
					permaLink = string.Format(SearchConfiguration.Instance().UrlFormat,host,app, "articles",reader["EntryID"]);
				}

				int feedbackCount = (int)reader["FeedbackCount"];
				int webviewCount = (int)reader["WebViewCount"];

				int boost = weighter.Calculate(body.Length,feedbackCount,webviewCount,dateCreated,(PostType)posttype);
				doc.SetBoost(boost);

				doc.Add(Field.UnIndexed(SearchConfiguration.BoostFactor,boost.ToString()));

				doc.Add(Field.UnIndexed(SearchConfiguration.PermaLink,permaLink));
			}
			catch(Exception e)
			{
				Dottext.Framework.Logger.LogManager.Log("CreateDoc Fail","EntryID is "+reader["EntryID"]);
			}
			
			return doc;
		}

		/// <summary>
		/// Takes a post and extracts all of the links. This needs to be tweaked to skip images/etc. There is no check for duplicate links and http:// and http://www. are strip off.
		/// </summary>
		/// <param name="text">The full body of a post/article</param>
		/// <returns>An array of links from the current post.</returns>
		private  string[] GetLinks(string text)
		{			
			ArrayList links = new ArrayList();

			Match m;
			for (m = regexLinks.Match(text); m.Success; m = m.NextMatch()) 
			{
				if(m.Groups.ToString().Length > 0 )
				{
					links.Add(regexClean.Replace(m.Groups[1].ToString(),string.Empty));	
				}
			}
			
			return (string[])links.ToArray(typeof(string));	
		}

		private DateTime GetNewestFileTime()
		{
			string path = SearchConfiguration.Instance().PhysicalPath;
			DateTime max=System.DateTime.Now.AddYears(-100);
			
			try
			{
				//string tempIndex = System.IO.Path.Combine(path,SearchConfiguration.TempIndex);
				
				DirectoryInfo di = new DirectoryInfo(path);
				FileInfo[] files = di.GetFiles();
				foreach(FileInfo file in files)
				{
					if(file.CreationTime.CompareTo(max)>0&&file.Name!="segments")
					{
						max=file.CreationTime;
						//Dottext.Framework.Logger.LogManager.Log(file.Name,file.CreationTime.ToString());
					}
				}
			}
			catch(Exception e)
			{
				Dottext.Framework.Logger.LogManager.CreateExceptionLog(e,"GetNewestFileTime Fail");
			}
			return max;
		}

		#region Regex

		private const string linkPattern = @"(?:[hH][rR][eE][fF]\s*=)" +
			@"(?:[\s""']*)(?!#|[Mm]ailto|[lL]ocation.|[jJ]avascript|.*css|.*this\.)" +
			@"(.*?)(?:[\s>""'])";

		//used to find/extract links
		private Regex regexLinks = new Regex(linkPattern,RegexOptions.IgnoreCase|RegexOptions.Compiled);

		private Regex regexStripHTML = new Regex("<[^>]+>",RegexOptions.IgnoreCase|RegexOptions.Compiled);

		//used to remove http:// and http://www. from a link
		private Regex regexClean = new Regex(@"^http://(www\.)?");

		#endregion
	}
}
