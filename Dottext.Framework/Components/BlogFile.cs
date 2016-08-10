using System;
using System.IO;


namespace Dottext.Framework.Components
{
	/// <summary>
	/// File 的摘要说明。
	/// </summary>
	public class BlogFile
	{
		public BlogFile()
		{
					
		}

		private string _localFolder;
		public string LocalFolder
		{
			set
			{
				if(!value.EndsWith("\\"))
				{
					value+="\\";
				}
				_localFolder=value;
			}
		}
		public  virtual string LocalPath
		{
			get
			{
				return _localFolder+_name;
			}
			
		}

		private string _webPath;
		public string WebPath
		{
			set
			{
				_webPath= value;
			}
		}
		public string WebURL
		{
			get
			{
				return _webPath+_name;
			}
		}
		
		private long _size;
		public long Size
		{
			get
			{
				return _size;
			}
			set
			{
				_size=value;
			}
			
		}

		public long SizeKB
		{
			get
			{
				return _size/1024;
			}
			
		}

		public long SizeMB
		{
			get
			{
				return _size/(1024*1024);
			}
			
		}

		public string _name;
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name=value;
			}
		}



	}
}
