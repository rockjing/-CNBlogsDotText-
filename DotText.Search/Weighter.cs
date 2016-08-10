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
using Dottext.Framework.Components;

namespace Dottext.Search
{
	/// <summary>
	/// Summary description for Weighter.
	/// </summary>
	public class Weighter
	{
		private DateTime currentDateTime;
		public Weighter()
		{
			currentDateTime = DateTime.Now;
		}

		public int Calculate(int PostLength, int FeedBackCount, int WebViewCount, DateTime CreatedDate, PostType posttype)
		{
			int totalScore = 0;

			//Weight Feedback
			totalScore += Scorer(FeedBackCount,3,5); //Max 5
			//Weight WebViews
			totalScore += Scorer(WebViewCount,200,5); //Max 5
			//Weight Length
			totalScore += Scorer(PostLength,500,5); //Max 5
			//Weight Time
			totalScore += ScoreDate(CreatedDate); //Max 12

			//bump up articles
			if(posttype == PostType.Article)  // 5
			{
				totalScore +=5;
			}


			return totalScore;
		}

		protected int ScoreDate(DateTime CreatedDate)
		{
			TimeSpan ts = currentDateTime - CreatedDate;
			int days = ts.Days;
			int w = 0;
			if(days <= 360)
			{
				int factor = days/30;
				w = (factor - 12) * -1;
			}

			return w;
		}

		protected int Scorer(int count, int factor, int max)
		{
			int score = count/factor;

			if(score > max)
			{
				score = max;
			}
			return score;
		}
	
	}
}
