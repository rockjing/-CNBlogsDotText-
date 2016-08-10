using System;
using Dottext.Framework.Components;
using Dottext.Framework.Providers;

namespace Dottext.Framework
{
	/// <summary>
	/// Rates 的摘要说明。
	/// </summary>
	public class Rates
	{
		public Rates()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public static int InsertRate(EntryRate er)
		{
			return DTOProvider.Instance().InsertRate(er);
		}
		
		public static void GetRateScore(EntryRate er)
		{
			
			for(int i=0;i<er.RatingList.Length;i++)
			{
				er.RatingList[i]=DTOProvider.Instance().GetRatePeople(er.EntryID,i+1);
			}
		}

	}
}
