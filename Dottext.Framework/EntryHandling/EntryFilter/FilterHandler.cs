using System;
using System.Text.RegularExpressions;

namespace Dottext.Framework.EntryHandling
{
	/// <summary>
	/// FilterHandler 的摘要说明。
	/// </summary>
	public class FilterHandler
	{
		private FilterHandler()
		{
			
		}

		public static string Process(FilterType filterType,string filterContent)
		{
			if((filterType&FilterType.Script)==FilterType.Script)
			{
				filterContent=FilterScript(filterContent);
				Console.WriteLine("FilterScript");
			}
			if((filterType&FilterType.Html)==FilterType.Html)
			{
				filterContent= FilterHtml(filterContent);
				Console.WriteLine("FilterHtml");
			}
			if((filterType&FilterType.Object)==FilterType.Object)
			{
				filterContent= FilterObject(filterContent);
				Console.WriteLine("FilterObject");
			}
			return filterContent;
			/*switch (filterType)
			{
				case filterType&FilterType.Script:
					filterContent=FilterScript(filterContent);
					
				case filterType&FilterType.Html:
					filterContent= FilterHtml(filterContent);

				case filterType&FilterType.Object:
					filterContent= FilterObject(filterContent);
					
				default:
					return filterContent;

			}
			return filterContent;*/

		}

		public static string FilterScript(string content)
		{
			string regexstr=@"(?i)<script([^>])*>(\w|\W)*</script([^>])*>";
			return Regex.Replace(content,regexstr,string.Empty,RegexOptions.IgnoreCase);
		}

		public static string FilterHtml(string content)
		{
			string newstr=FilterScript(content);
			string regexstr=@"<[^>]*>";
			return Regex.Replace(newstr,regexstr,string.Empty,RegexOptions.IgnoreCase);
		}

		public static string FilterObject(string content)
		{
			string regexstr=@"(?i)<Object([^>])*>(\w|\W)*</Object([^>])*>";
			return Regex.Replace(content,regexstr,string.Empty,RegexOptions.IgnoreCase);
		}


	}
}
