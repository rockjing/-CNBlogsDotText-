using System;
using Dottext.Framework;
using Dottext.Framework.Format;
using Dottext.Framework.Components;
using Dottext.Common.Data;
using System.Data;
using System.Web;
using System.Text.RegularExpressions;

namespace Dottext.Web.UI
{
	/// <summary>
	/// Summary description for UIData.
	/// </summary>
	public class UIData
	{
		public UIData()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static LinkCategory Links(CategoryType catType, UrlFormats formats)
		{
			switch(catType)
			{
				case CategoryType.PostCollection:
					return Transformer.BuildLinks(UIText.PostCollection,CategoryType.PostCollection,formats);
				case CategoryType.ImageCollection:
					return Transformer.BuildLinks(UIText.ImageCollection,CategoryType.ImageCollection,formats);
				case CategoryType.StoryCollection:
					return Transformer.BuildLinks(UIText.ArticleCollection,CategoryType.StoryCollection,formats);
				case CategoryType.FavoriteCollention:
					return Transformer.BuildLinks(UIText.FavoriteCollention,CategoryType.FavoriteCollention,formats);
				default:
					throw new ApplicationException(string.Format("Invalid CategoryType: {0} via Dottext.Web.UI.UIData.Links",catType));
			}
		}

		public static LinkCategory ArchiveMonth(UrlFormats formats,PostType postType)
		{
			return Transformer.BuildMonthLinks(UIText.Archives,formats,postType);
		}

		public static string FavoriteLink
		{
			get
			{
					return @"&nbsp;<a href=""{0}AddToFavorite.aspx?id={1}""> ’≤ÿ</a>";
			}
		}

		public static string EditPostsLink
		{
			get
			{
				return @"&nbsp;<a href=""{0}admin/EditPosts.aspx?postid={1}"">±‡º≠</a>";
			}
		}

		public static string EditArticleLink
		{
			get
			{
				return @"&nbsp;<a href=""{0}admin/EditArticles.aspx?postid={1}"">±‡º≠</a>";
			}
		}

		public static string SiteCatalogXmlFile
		{
			get
			{
				return System.Web.HttpContext.Current.Server.MapPath("~/SiteCatalog.config");
			}
		}

		public static DataSet SiteCatalogData
		{
			get
			{
				string key="CnBlogsSiteCatalog";
				DataSet ds=(DataSet)System.Web.HttpContext.Current.Cache[key];
				if(ds==null)
				{
					ds=new DataSet();
					ds.ReadXml(UI.UIData.SiteCatalogXmlFile);
					System.Web.HttpContext.Current.Cache.Insert(key,ds);
				}
				return ds;
			}
		}

		public static string GetSiteCatalogData(string querystr,string field)
		{
			DataRow[] row=UI.UIData.SiteCatalogData.Tables[0].Select(querystr);
			if(row!=null&&row.Length>0)
			{
				if(row[0][field]!=DBNull.Value)
				{
					return row[0][field].ToString();
				}
			}
			return string.Empty;
		}

		public static string GetSiteCatalogData(HttpRequest request,string field)
		{
			string queryUrl;
			if(request.RawUrl.ToLower().IndexOf(".aspx")==-1)
			{
				queryUrl="default='1'";
			}
			else if(request.QueryString["cate"]!=null)
			{
				queryUrl=string.Format("cate='{0}'",request.QueryString["cate"]);
			}
			else
			{
				return string.Empty;
			}
			/*if(request.RawUrl=="")
			{
				queryUrl="default.aspx";
			}*/
			//queryUrl=request.RawUrl.Substring(request.RawUrl.LastIndexOf("/")+1);
			return GetSiteCatalogData(queryUrl,field);
		}

		public static LinkCategory GetSiteCategory(HttpRequest request)
		{
			int cateid;
			if(request.RawUrl.ToLower().IndexOf(".aspx")==-1)
			{
				cateid=int.Parse(UIText.GetSafeConfig("AggregateDefaultCategory","0"));
			}
			else if(request.QueryString["cateid"]!=null)
			{
				cateid=int.Parse(request.QueryString["cateid"]);
			}
			else
			{
				cateid=-1;
			}
			LinkCategory lc=Dottext.Framework.Links.GetLinkCategory(cateid,true);
			if(lc!=null)
			{
				lc.Title=Regex.Replace(lc.Title,@"^\d",string.Empty);
			}
			return lc;
		}

		
		/*
		public static int GetEntryViewCount(int EntryID)
		{
			EntryStatsView esv=Entries.GetEntryStatView(EntryID);
			if(esv!=null)
			{
				return esv.ViewCount;
			}
			return 0;
		}*/

		public static int PostContentLength
		{
			get
			{
				return int.Parse(UIText.GetSafeConfig("PostContentLength","5000"));
			}
		}

		public static string[] HtmlFilter
		{
			get
			{
				return UIText.GetSafeConfig("HtmlFilter","").Split(',');
			}
		}



	}
}
