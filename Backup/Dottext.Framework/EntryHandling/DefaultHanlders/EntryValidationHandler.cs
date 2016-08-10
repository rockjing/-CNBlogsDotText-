using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Web;
using System.Text.RegularExpressions;
using Dottext.Framework;
using Dottext.Framework.Components;
using Sgml;
using Dottext.Framework.Util;

namespace Dottext.Framework.EntryHandling
{
	/// <summary>
	/// Validates an Entry for illegal scripting elements and attributes. This should happen before the post is sent
	/// to the datastore. If the validation fails, a BlogFailedPostException is thrown.
	/// </summary>
	public class EntryValidationHandler : IEntryFactoryHandler
	{
		
		public EntryValidationHandler()
		{
		}

		#region IEntryFactoryHandler Members

		/// <summary>
		/// Validate the body of the Entry. Elements like Script and IFrame are not allowed. To complete the validation,
		/// the Entry.Body html will be converted to XML. This value will not be saved to the database. It is only used for 
		/// validation
		/// </summary>
		/// <param name="e"></param>
		public void Process(Dottext.Framework.Components.Entry e)
		{
			
			//First iteration used XPath validation followed by a secondary Regex validation. For per reasons, it 
			//is probably better to use the Regex validation first and then move onto the XPath validation. This way,
			//no scripting words/elements are found in the post, we know we are safe. However, if a scripting keyword is
			//found, use XPath to see if it is an element, or part of the post body
			try
			{
				ReplaceEntry(e);

				//e.Body=Util.Globals.FilterScript(e.Body);
				//e.Title=Globals.SafeFormat(e.Title);
				//e.Author = Globals.SafeFormat(e.Author);
				//First, we test using XPath. If that fails, we throw a BlogFailedPostException. 
				if(!Validate(e.Body) || !Validate(e.Description))
				{
					//throw new BlogFailedPostException("不允许插入脚本!");//"Invalid elements and/or elements where found in your post. Script,IFrame,Object,FrameSet,Meta,Link and attributes which start with \"on\" are not allowed");
				}
			}
			//Many bloggers are still typing their orinal posts in a MS office application, which has the nasty habbit of creating some crappy HTML, which SGML reader
			//may choke on (especially xml namespaces). If an XmlException is found, we will use a regular expression to validate the body of the post. If any of the 
			//illegal words are found (either as a HTML elment, HTML attribute, or body of the post, a BlogFailedPostException is throw as well. 
			catch(XmlException)
			{
				/*if(!RegexTest(e.Body) || !RegexTest(e.Description))
				{
					throw new BlogFailedPostException("Invalid elements and/or elements where found in your post. Script,IFrame,Object,FrameSet,Meta,Link and attributes which start with \"on\" are not allowed. In addition, unnecessary html was found in your post, which could also be causing this exception.");
				}*/

			}
			
		}

		private bool RegexTest(string text)
		{

			if(text != null)
			{
				string pattern = "script";//|iframe|object|frameset|frame|meta|link|style|onabort|onblur|onchange|onclick|ondblclick|onerror|onfocus|onkeydown|onkeypress|onkeyup|onload|onmousedown|onmouseout|onmouseover|onmouseup|onreset|onresize|onsubmit|onunload";
				return !Regex.IsMatch(text.Replace(" ",string.Empty),pattern,RegexOptions.IgnoreCase);
			}
			return true;
		}

		private void ReplaceEntry(Entry e)
		{
			Dottext.Framework.Configuration.BlogConfig config = Dottext.Framework.Configuration.Config.GetConfig(HttpContext.Current.User.Identity.Name);
			if(e.Author=="" || e.Author==null)
			{
				e.Author=config.UserName;
			}

			/*if(e.Body.IndexOf("<pre>",0)>=0)
			{
				e.Body=ProcessPre(e.Body,e.Body.IndexOf("<pre>"),e.Body.LastIndexOf("</pre>"));
			}
			else if(e.Body.IndexOf("<PRE>",0)>=0)
			{
				e.Body=ProcessPre(e.Body,e.Body.IndexOf("<PRE>",0),e.Body.LastIndexOf("</PRE>",0));
			}
			*/
			
			/*
			if(e.BlogID!=config.BlogID)
			{
				string author="["+config.Author+"]";
				if(e.Title.IndexOf(author)<0)
				{
					e.Title=e.Title+author;
				}
			}*/
			//e.Body=Util.Globals.RemoveHtmlTag(e.Body,"pre");
		}
		/// <summary>
		/// Convert the text to XML and look for illegal elements and attributes
		/// </summary>
		/// <param name="body"></param>
		/// <returns></returns>
		private bool Validate(string text)
		{
			//Thanks Drew Marsh and Kirk Evans for the XPath statements
			
			/*string msg="";
			string filterword="";
			if(text != null)
			{
				if(text.IndexOf("<script")>-1||text.IndexOf("</script>")>-1)
				{
					throw new BlogFailedPostException("不允许插入脚本!");
					return false;
				}
				
				
				string[] words=filterword.Split(';');
				foreach(string word in words)
				{
					if(text.IndexOf(word)>-1)
					{
						throw new BlogFailedPostException(msg);
						return false;
					}
				}
			

				return true;
				//Util.Globals.FilterScript(text);
				/*SgmlReader r = new SgmlReader();
				r.DocType = "HTML";
				r.InputStream = new StringReader(string.Format("<body>{0}</body>",text));
				StringWriter sw = new StringWriter();
				XmlTextWriter w = new XmlTextWriter(sw);
				while (r.Read()) 
				{
					w.WriteNode(r, true);
				}
			
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(sw.ToString());
				sw.Close();
				w.Close();  
			
				XPathNavigator nav = doc.CreateNavigator();//if(nav.Select("//script|//iframe|//object|//frameset|//frame|//meta|//link|//style").Count == 0)
				if(nav.Select("//script").Count == 0)
				{
					return nav.Select("//attribute::*[starts-with(name(),'on')]").Count == 0;
				}
				return false;
			}*/
			return true;
				
		}


		private string ProcessPre(string body,int firstIndex,int lastIndex)
		{
			//Logger.LogManager.Log("ProcessPre",firstIndex.ToString());
			//Logger.LogManager.Log("ProcessPre",lastIndex.ToString());
			return body;
			//string ReplaceStr=body.Substring(firstIndex+5,lastIndex-firstIndex-4);
			//string TargetStr=Globals.ReplaceSpace(ReplaceStr);
			//return body.Substring(0,firstIndex-1)+TargetStr;//+body.Substring(lastIndex+5);
		}
		

		//nothing to pre configure
		public void Configure()
		{
			
		}

		#endregion
	}
}
