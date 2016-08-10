using System;
using System.Data;
using Dottext.Framework.Components;
using Dottext.Framework.Providers;
using Dottext.Framework.Data;

namespace Dottext.Framework
{
	/// <summary>
	/// Summary description for Archives.
	/// </summary>
	public class Archives
	{
		private Archives()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static ArchiveCountCollection GetPostsByMonthArchive(PostType postType)
		{
			return DTOProvider.Instance().GetPostsByMonthArchive(postType);
		}

		public static ArchiveCountCollection GetPostsByYearArchive(PostType postType)
		{
			return DTOProvider.Instance().GetPostsByYearArchive(postType);
		}
	}
}
