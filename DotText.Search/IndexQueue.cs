using System;
using Dottext.Framework.Logger;

namespace Dottext.Search
{
	/// <summary>
	/// IndexQueue 的摘要说明。
	/// </summary>
	public class IndexQueue
	{
		public IndexQueue()
		{
			
		}

		public void Run(object state)
		{
			string path = SearchConfiguration.Instance().PhysicalPath;
			string tempIndex = System.IO.Path.Combine(path,SearchConfiguration.TempIndex);
			if(System.IO.File.Exists(tempIndex+"\\segments"))
			{
				LogManager.Log("IndexQueue Abort","Another RebuildSafeIndex is Runing");
				return;
			}
			LogManager.Log("IndexQueue","IndexQueue is Running");
			Log log = new Log();
			log.Title = "Search Index";
			log.Message = string.Format("Manual ReBuildAll");
			IndexManager.RebuildSafeIndex();
			log.EndDate = DateTime.Now;
			LogManager.Create(log);
			
		}

		

		
	}
}
