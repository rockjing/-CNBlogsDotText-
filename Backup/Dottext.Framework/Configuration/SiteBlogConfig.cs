using System;
using Dottext.Framework.Components;

namespace Dottext.Framework.Configuration
{
	/// <summary>
	/// SiteBlogConfig 的摘要说明。
	/// </summary>
	[Serializable]
	public class SiteBlogConfig : BlogConfig
	{
		public SiteBlogConfig()
		{
			this.EnableComments=true;
			this.IsActive=true;
			this.FullyQualifiedUrl=Util.Globals.GetSiteQualifiedUrl();
		}

		private int _categoryID;
		public int CategoryID
		{
			get
			{
				return this._categoryID;
			}
			set
			{
				this._categoryID=value;
			}
		}

		private bool _inOpml=true;
		public bool InOpml
		{
			get
			{
				return this._inOpml;
			}
			set
			{
				this._inOpml=value;
			}
		}
		
		private PostType _postType=PostType.BlogPost;
		public PostType PostType
		{
			get
			{
				return this._postType;
			}
			set
			{
				this._postType=value;
			}
		}

		private bool _isDefault=false;
		public bool IsDefault
		{
			get
			{
				return this._isDefault;
			}
			set
			{
				this._isDefault=value;
			}
		}

		public override string Title
		{
			get
			{
				if(base.Title==null||base.Title=="")
				{
					base.Title=Util.Globals.GetWebConfig("AggregateTitle","CNDotText");
				}

				return base.Title;
			}
			set
			{
				base.Title = value;
			}
		}


			
	}
}
