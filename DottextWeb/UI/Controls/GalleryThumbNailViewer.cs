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

namespace Dottext.Web.UI.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Dottext.Framework;
	using Dottext.Framework.Util;
	using Dottext.Framework.Components;

	/// <summary>
	///		Summary description for GalleryThumbNailViewer.
	/// </summary>
	public class GalleryThumbNailViewer : Dottext.Web.UI.Controls.BaseControl
	{
		protected System.Web.UI.WebControls.Literal GalleryTitle;
		protected System.Web.UI.WebControls.DataList ThumbNails;
		protected System.Web.UI.WebControls.Literal Description;

		private string _baseImagePath = null;

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			// Put user code to initialize the page here
			if(Context != null)
			{
				int catID = Globals.GetPostIDFromUrl(Request.Path);
				_baseImagePath = Images.HttpGalleryFilePath(Context,catID);

				ImageCollection ic = Images.GetImagesByCategoryID(catID,true);
				if(ic != null)
				{
					GalleryTitle.Text = ic.Category.Title;
					if(ic.Category.HasDescription)
					{
						Description.Text = string.Format("<p>{0}</p>",ic.Category.Description);
					}
					ThumbNails.DataSource = ic;
					ThumbNails.DataBind();
				}
			}
		}

		protected void ImageCreated(object sender,  DataListItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Dottext.Framework.Components.Image _image = (Dottext.Framework.Components.Image)e.Item.DataItem;
				if(_image != null)
				{
					HyperLink ThumbNailImage = (HyperLink)e.Item.FindControl("ThumbNailImage");
					if(ThumbNailImage != null)
					{
						
						ThumbNailImage.ImageUrl = _baseImagePath + _image.ThumbNailFile;
						ThumbNailImage.NavigateUrl = Dottext.Framework.Configuration.Config.CurrentBlog().UrlFormats.ImageUrl(null,_image.ImageID);
						ThumbNailImage.ToolTip = _image.Title;

					}
				}
			}
		}
	}
}

