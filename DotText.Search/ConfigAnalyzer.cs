using System;
using Lucene.Net;

namespace Dottext.Search
{
	/// <summary>
	/// ConfigAnalyzer ��ժҪ˵����
	/// </summary>
	public class ConfigAnalyzer
	{
		public ConfigAnalyzer()
		{
			
		}

		public static Lucene.Net.Analysis.Analyzer GetAnalyzer()
		{
			//return new Lucene.Net.Analysis.Standard.StandardAnalyzer(); 
			//return new Lucene.Net.Analysis.CJK.CJKAnalyzer(); 
			return new Lucene.Net.Analysis.Cn.ChineseAnalyzer();
		}
	}
}
