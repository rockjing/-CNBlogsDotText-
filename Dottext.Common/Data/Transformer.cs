using System;

using Dottext.Framework;
using Dottext.Framework.Format;
using Dottext.Framework.Configuration;
using Dottext.Framework.Components;

namespace Dottext.Common.Data
{
	/// <summary>
	/// Common .Text object transformations
	/// </summary>
	public class Transformer
	{
		private Transformer(){}


		/// <summary>
		/// Converts a LinkCategoryCollection into a single LinkCategory with its own LinkCollection.
		/// </summary>
		/// <param name="Title">Title for the LinkCategory</param>
		/// <param name="catType">Type of Categories to transform</param>
		/// <param name="formats">Determines how the Urls are formated</param>
		/// <returns></returns>
		public static LinkCategory BuildLinks(string Title, CategoryType catType, UrlFormats formats)
		{
			string CountStr="&nbsp;({0})";
			LinkCategoryCollection lcc = Links.GetCategoriesByType(catType,true);
			LinkCategory lc = null;
			if(lcc != null && lcc.Count > 0)
			{
				lc = new LinkCategory();
				int count = lcc.Count;
				lc.Title = Title;
				lc.Links = new LinkCollection();
				Link link = null;
				for(int i = 0; i<count; i++)
				{
					link = new Link();
					
					link.Title = lcc[i].Title;
					link.CategoryID=lcc[i].CategoryID;
					switch(catType)
					{
						case CategoryType.StoryCollection:
							link.Title+=string.Format(CountStr,GetCategoryEntryCount(link.CategoryID).ToString());
							link.Url =  formats.ArticleCategoryUrl(link.Title,lcc[i].CategoryID);
							link.Rss = link.Url + "/rss";
							break;
						case CategoryType.PostCollection:
							link.Title+=string.Format(CountStr,GetCategoryEntryCount(link.CategoryID).ToString());
							link.Url = formats.PostCategoryUrl(link.Title,lcc[i].CategoryID);
							link.Rss = link.Url + "/rss";
							break;
						case CategoryType.ImageCollection:
							link.Title+=string.Format(CountStr,GetImageCount(link.CategoryID).ToString());
							link.Url = formats.GalleryUrl(link.Title,lcc[i].CategoryID);
							break;
						case CategoryType.FavoriteCollention:
							link.Title+=string.Format(CountStr,GetCategoryLinkCount(link.CategoryID).ToString());
							link.Url = formats.FavoriteCategoryUrl(link.Title,lcc[i].CategoryID);
							link.Rss = link.Url + "/rss";
							break;

					}
					link.NewWindow = false;
					lc.Links.Add(link);
				}
			}				
			return lc;
		}

		/// <summary>
		/// Will convert ArchiveCountCollection method from Archives.GetPostsByMonthArchive()
		/// into a LinkCategory. LinkCategory is a common item to databind to a web control.
		/// </summary>
		/// <param name="Title">Title for the Category</param>
		/// <param name="formats">Determines how the Urls are formated</param>
		/// <returns>A LinkCategory object with a Link (via LinkCollection) for each month in ArchiveCountCollection</returns>
		public static LinkCategory BuildMonthLinks(string Title,UrlFormats formats,PostType postType)
		{
			string path="archive";
			ArchiveCountCollection acc = Archives.GetPostsByMonthArchive(postType);
			
			LinkCategory lc = new LinkCategory();
			if(postType==PostType.BlogPost)
			{
				Title="Ëæ±Ê"+Title;

			}
			if(postType==PostType.Article)
			{
				Title="ÎÄÕÂ"+Title;
				path="archives";
			}
			lc.Title = Title;
			lc.Links = new LinkCollection();
			foreach(ArchiveCount ac in acc)
			{
				Link link = new Link();
				link.NewWindow = false;
				link.Title = ac.Date.ToString("y") + " (" + ac.Count.ToString() + ")";
				link.Url = formats.MonthUrl(ac.Date,path);
				link.NewWindow = false;
				link.IsActive = true;

				lc.Links.Add(link);
			}
			return lc;
		}

		public static int GetCategoryEntryCount(int categoryID)
		{
			EntryQuery eq=new EntryQuery();
			eq.PostType =PostType.Article|PostType.BlogPost;
			eq.PostConfig = PostConfig.IsActive;
			eq.CategoryID=categoryID;
			CategoryEntryCollection cec=Entries.GetCategoryEntryCollection(eq);
			return cec.Count;
		}

		public static int GetCategoryLinkCount(int categoryID)
		{
			LinkCollection lc=Links.GetLinksByCategoryID(categoryID,true);
			return lc.Count;
		}

		public static int GetImageCount(int categoryID)
		{
			ImageCollection ic=Images.GetImagesByCategoryID(categoryID,true);
			return ic.Count;
		}
	}
}
