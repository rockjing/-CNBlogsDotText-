using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ActiproSoftware.CodeHighlighter;

namespace Dottext.Web
{
	/// <summary>
	/// InsertCode 的摘要说明。
	/// </summary>
	public class InsertCode : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList LanguageDropDownList;
		protected System.Web.UI.WebControls.TextBox CodeTextBox;
		protected System.Web.UI.WebControls.Button HighlightButton;
		protected System.Web.UI.WebControls.TextBox CodeText;
		protected ActiproSoftware.CodeHighlighter.CodeHighlighter Codehighlighter1;
		protected System.Web.UI.HtmlControls.HtmlTable Table1;
		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Expires=-1;
			if(!IsPostBack)
			{
				
				CodeHighlighterConfiguration codeConfig=(CodeHighlighterConfiguration)System.Configuration.ConfigurationSettings.GetConfig("codeHighlighter");
				foreach(string key in codeConfig.LanguageConfigs.Keys)
				{
					LanguageDropDownList.Items.Add(key);
					if(key=="C#")
					{
						LanguageDropDownList.SelectedIndex=LanguageDropDownList.Items.Count-1;
					}
				}

			}

		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.HighlightButton.Click += new System.EventHandler(this.HighlightButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void HighlightButton_Click(object sender, System.EventArgs e)
		{
			Codehighlighter1.LanguageKey=LanguageDropDownList.SelectedItem.Text;
			Codehighlighter1.OutliningEnabled=true;
			Codehighlighter1.Text = CodeText.Text.Replace("\\","\\\\");
			
			
		}

		public void CodeHighlighter_PostRender(object sender, System.EventArgs e)
		{
			if(IsPostBack)
			{
				string html=Codehighlighter1.Output.Replace("\"","\\\"");
				html=html.Replace("\r\n","<br>\"+\r\n\"");
				html=Dottext.Framework.Util.Globals.ReplaceSpace(html);
				string imgpath=Dottext.Framework.Util.Globals.GetAppUrl(Request)+"Images/";
				html=html.Replace("...","<img src='"+imgpath+"dot.gif'>");
				//html=html.Replace("<div>",string.Empty);
				//html=html.Replace("</div>",string.Empty);
				//html=html.Replace(" ","&nbsp;");
				//html=html.Replace("\r","\"+\r");
				//html=html.Replace("\n","\"\n");
				/*System.IO.StreamWriter sw=new System.IO.StreamWriter("f:\\test.txt");
				sw.Write(html);
				sw.Flush();
				sw.Close();*/
				string divstr=@"<div style='BORDER-RIGHT: windowtext 0.5pt solid;PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 0.5pt solid; PADDING-LEFT: 5.4pt; BACKGROUND: #e6e6e6; PADDING-BOTTOM: 4px;PADDING-TOP: 4px; 	BORDER-LEFT: windowtext 0.5pt solid;WIDTH: 98%;	BORDER-BOTTOM: windowtext 0.5pt solid;word-break:break-all'>";
				Response.Write(@"
				<script language='javascript'>
				window.parent.returnValue = """+divstr+html+@"</div>"";
				window.parent.close();
				</script>");
				
			}
								
		}
		
		
	}
}
