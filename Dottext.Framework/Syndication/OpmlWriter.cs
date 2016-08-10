using System;
using System.Data;
using System.IO;
using System.Xml;

namespace Dottext.Framework.Syndication
{
	/// <summary>
	/// OpmlWriter 的摘要说明。
	/// </summary>
	public class OpmlWriter
	{
		public OpmlWriter()
		{
			
		}

		public static void Write(DataTable dt, string FullAppPath,string SiteTitle,Stream OutStream)
		{
			try
			{
				//StringWriter sw = new StringWriter();
					
				//XmlTextWriter writer = new XmlTextWriter(sw);
				XmlTextWriter writer = new XmlTextWriter(OutStream,System.Text.Encoding.UTF8);
				writer.Formatting = Formatting.Indented;

				writer.WriteStartDocument();

				//OPML ROOT
				writer.WriteStartElement("opml");

				//Body
				writer.WriteStartElement("body");
				writer.WriteStartElement("outline");
				writer.WriteAttributeString("title",SiteTitle);
				DataRow[] rows=dt.Select("opml=true");
				int count = rows.Length;
				for(int i = 0; i< count; i++)
				{
					DataRow dr =rows[i];
					writer.WriteStartElement("outline");

					//string title = (string)dr["Title"];
					//string htmlUrl = string.Format(baseUrl,(string)dr["Host"],(string)dr["Application"]);
					//string xmlUrl= htmlUrl + "/rss.aspx";

					writer.WriteAttributeString("title",dr[0].ToString());
					writer.WriteAttributeString("htmlUrl",FullAppPath+dr[1].ToString());
					writer.WriteAttributeString("xmlUrl",FullAppPath+dr[2].ToString());

					writer.WriteEndElement();									
				}
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.Flush();
				writer.Close();
				//sw.Close();
				//return sw.ToString();

			}
			catch(Exception e)
			{
				throw e;
			}


		}
	}
}
