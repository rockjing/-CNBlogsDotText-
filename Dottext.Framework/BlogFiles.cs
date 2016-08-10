using System;
using System.IO;
using Dottext.Framework.Components;

namespace Dottext.Framework
{
	/// <summary>
	/// Files 的摘要说明。
	/// </summary>
	public class BlogFiles
	{
		public BlogFiles()
		{
			
		}

		public static BlogFileCollection GetBlogFileCollection(string localFolder,string webPath)
		{
			
			BlogFileCollection bfc=new BlogFileCollection();
			DirectoryInfo dirInfo=new DirectoryInfo(localFolder);
			FileInfo[] fileInfos=dirInfo.GetFiles();
			foreach(FileInfo fileInfo in fileInfos)
			{
				BlogFile blogfile=new BlogFile();
				blogfile.Name=fileInfo.Name;
				blogfile.LocalFolder=localFolder;
				blogfile.WebPath=webPath;
				blogfile.Size=fileInfo.Length;
				bfc.Add(blogfile);
		
			}
			return bfc;
			
		}
	}
}
