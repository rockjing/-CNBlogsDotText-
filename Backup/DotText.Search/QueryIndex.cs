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
using System.Globalization;
using System.Text.RegularExpressions;

using Lucene.Net.Documents;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Search.Highlight;


using Dottext.Framework.Components;
using Dottext.Framework.Util;

namespace Dottext.Search
{
	/// <summary>
	/// Wrapper for querying the Index
	/// </summary>
	public class QueryIndex : IDisposable
	{
		IndexReader reader = null;
		Searcher searcher = null;
		QueryParser queryParser = null;
		int pageSize = 20;

		/// <summary>
		/// SafeSearch aquires a Readerlock (SearchLock.AquireReader) for the search. 
		/// </summary>
		/// <param name="blog">The blog to filter the search by</param>
		/// <param name="text">the text/query</param>
		/// <param name="pageIndex">Which page of results was requested.</param>
		/// <returns></returns>
		public static ResultSet SafeSearch(string filterSearchText, string filterField, string searchText, int pageIndex, int fragmentSize)
		{
			SearchLock.AquireReader(30);
			QueryIndex qi = null;
			try
			{
				qi = new QueryIndex();
				qi.FragementSize = fragmentSize;
				return qi.Search(filterSearchText,filterField,searchText,pageIndex);
			}
			finally
			{
				if(qi != null)
				{
					qi.Close();
				}
				SearchLock.ReleaseReader();
			}
		}

		/// <summary>
		/// SafeSearch aquires a Readerlock (SearchLock.AquireReader) for the search. 
		/// </summary>
		/// <param name="text">the text/query</param>
		/// <param name="pageIndex">Which page of results was requested.</param>
		/// <returns></returns>
		public static ResultSet SafeSearch(string text, int pageIndex, int fragmentSize)
		{
			SearchLock.AquireReader(30);
			QueryIndex qi = null;
			try
			{
				
				qi = new QueryIndex();
				qi.FragementSize = fragmentSize;
				return qi.Search(text,pageIndex);
			}
			catch(Exception e)
			{
				System.Web.HttpContext.Current.Response.Write("正在建立索引,请稍候再试!");
				Dottext.Framework.Logger.LogManager.CreateExceptionLog(e,"Search Fail");
				return null;
			}
			finally
			{
				if(qi != null)
				{
					qi.Close();
				}
				SearchLock.ReleaseReader();
			}
			
		}


		public QueryIndex()
		{
			//Initialize the Lucene objects
			string physicalPath = SearchConfiguration.Instance().PhysicalPath;
			/*if(!System.IO.File.Exists(physicalPath+"segments"))
			{
				IndexQueue que=new IndexQueue();
				Dottext.Framework.Util.ManagedThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(que.Run));

			}*/
			reader = IndexReader.Open(physicalPath);
			searcher = new IndexSearcher(reader);
			queryParser = new QueryParser(SearchConfiguration.RawPost,ConfigAnalyzer.GetAnalyzer()); 
			pageSize = SearchConfiguration.Instance().PageSize;
		}

		private int _fragementSize;
		
		/// <summary>
		/// Property FragementSize (int)
		/// </summary>
		public int FragementSize
		{
			get {return this._fragementSize;}
			set {this._fragementSize = value;}
		}

		/// <summary>
		/// Returns a ResultSet of the supplied search text. The results are also filtered for a specifc blog (blog:BLOGNAME)
		/// </summary>
		/// <param name="filter">Query to filter by</param>
		/// <param name="text">Search query/text</param>
		/// <param name="pageIndex">current pagenumber</param>
		/// <returns></returns>
		public ResultSet Search(string filterSearchText, string filterField, string searchText, int pageIndex)
		{	
			//Filter for a specific blog
			
			QueryFilter qf = new QueryFilter(QueryParser.Parse(filterSearchText,filterField,ConfigAnalyzer.GetAnalyzer()));
			
			//How long does the search take
			StopWatch sw = new StopWatch();
			Query query = queryParser.Parse(FormatSearch(searchText));
			Hits hits = searcher.Search(query,qf);
			long executionTime = sw.Peek();

			ResultSet results = GetResults(hits,pageIndex,query);
			results.ExecutionTime = executionTime;

			
			return results;
		}	

		/// <summary>
		/// Returns a ResultSet of the supplied search text.
		/// </summary>
		/// <param name="text">Search query/text</param>
		/// <param name="pageIndex">current pagenumber</param>
		/// <returns></returns>
		public ResultSet Search(string text, int pageIndex)
		{			
			StopWatch sw = new StopWatch();
			Query query = queryParser.Parse(FormatSearch(text));
			query = query.Rewrite(this.reader);
			//QueryFilter qf = new QueryFilter(query);
			Hits hits = searcher.Search(query);
			long executionTime = sw.Peek();

			ResultSet results = GetResults(hits,pageIndex,query);
			results.ExecutionTime = executionTime;
			
			return results;
		}

		/// <summary>
		/// Replace "and" and "||" to "&&" and "||"
		/// </summary>
		/// <param name="searchText"></param>
		/// <returns></returns>
		private string FormatSearch(string searchText)
		{
			searchText = Regex.Replace(searchText,@"\sand\s"," && ",RegexOptions.IgnoreCase);
			searchText = Regex.Replace(searchText,@"\sor\s"," || ",RegexOptions.IgnoreCase);
			return searchText;
		}

		/// <summary>
		/// Internal method for converting a Hits object into a Results object
		/// </summary>
		/// <param name="hits">results of current search</param>
		/// <param name="pageIndex">The current page</param>
		/// <returns>The results by page for the current search request</returns>
		private ResultSet GetResults(Hits hits, int pageIndex, Query query)
		{
			int startPosition = (pageIndex - 1) * pageSize;
			int endPosition = startPosition + pageSize;

			if(hits.Length() < endPosition)
			{
				endPosition = hits.Length();
			}
			
			return GetResults(hits,startPosition,endPosition,query);

		}

		/// <summary>
		/// Returns all of the Hits (via ResultSet) for a given search
		/// </summary>
		/// <param name="hits">results of a search</param>
		/// <returns>A ResultSet with all of the hits</returns>
		private ResultSet GetResults(Hits hits, Query query)
		{
			//return 0 to length
			return GetResults(hits,0,hits.Length(),query);
		}

		/// <summary>
		/// Builds the ResultSet for a range of hits
		/// </summary>
		/// <param name="hits">results from the current search</param>
		/// <param name="startPosition">Start index positon</param>
		/// <param name="endPosition">End index postion</param>
		/// <returns>Result set representing the current search</returns>
		private ResultSet GetResults(Hits hits, int startPosition, int endPosition, Query query)
		{


			ResultSet results = new ResultSet();
			try
			{
				results.Count = hits.Length();

				QueryHighlightExtractor highlighter = null;
				if(this.FragementSize > 0)
				{
					highlighter = new QueryHighlightExtractor(query,ConfigAnalyzer.GetAnalyzer(),"<font color=\"red\">","</font>");
				}
				ArrayList al = new ArrayList();
				Result result = null;
				Document doc = null;
				for(int i = startPosition; i<endPosition; i++)
				{
					result = new Result();
					doc = hits.Doc(i);
					//result.Body = doc.getField(SearchConfiguration.Body).StringValue();
					result.DateCreatedString = doc.GetField(SearchConfiguration.DateCreated).StringValue();
							
					result.Author = doc.GetField(SearchConfiguration.Author).StringValue();
					//result.Description = doc.GetField(SearchConfiguration.Description).StringValue();
				
				
					result.PermaLink = doc.GetField(SearchConfiguration.PermaLink).StringValue();
				
					result.Title = doc.GetField(SearchConfiguration.Title).StringValue();
			
					if(FragementSize > 0)
					{
						string text = doc.GetField(SearchConfiguration.RawPost).StringValue();
						result.RawPost = highlighter.GetBestFragment(text,FragementSize);
					}
					else
					{
						result.RawPost = doc.GetField(SearchConfiguration.RawPost).StringValue();
					}
     

					//result.RawPost = doc.getField(SearchConfiguration.RawPost).StringValue();
					/*if((result.RawPost!=null)&&(result.RawPost!=""))
					{
						if(result.RawPost.Length>500)
						{
							result.RawPost=result.RawPost.Substring(0,500);
						}
					}*/
				
					result.Score = hits.Score(i);

					result.PostType = (PostType)Enum.Parse(typeof(PostType),doc.GetField(SearchConfiguration.PostType).StringValue(),true);
					result.BoostFactor = Int32.Parse(doc.GetField(SearchConfiguration.BoostFactor).StringValue());
					al.Add(result);
				}
				results.Results = (Result[])al.ToArray(typeof(Result));
			}
			catch(Exception e)
			{
				Dottext.Framework.Logger.LogManager.CreateExceptionLog(e,"GetResult Fail");
			}
			return results;

		}

		/// <summary>
		/// Close the searcher and reader objects (internal)
		/// </summary>
		public void Dispose()
		{
			Close();
		}

		private bool isDisposed = false;

		/// <summary>
		/// Close the searcher and reader objects (internal)
		/// </summary>
		public void Close()
		{
			if(!isDisposed)
			{
				searcher.Close();
				reader.Close();
				isDisposed = true;
			}
		}


	}
}
