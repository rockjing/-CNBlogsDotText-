using System;

namespace Dottext.Web.UI.Controls
{
	/// <summary>
	/// MsnToolbar 的摘要说明。
	/// </summary>
	public class MsnToolbar : FreeTextBoxControls.ToolbarListItem
	{
		public MsnToolbar()
		{
			XmlDocument myxml=new XmlDocument();
			//myxml.Load(this.+"emoticons.xml");
			//XmlNodeList nodes=myxml.SelectNodes("/emoticons/emoticon");
			//foreach(XmlNode node in nodes)
		{
			//tbButton=new FreeTextBoxControls.ToolbarButton();
			//FreeTextBoxControls.InsertImage tbButton=new FreeTextBoxControls.InsertImage();
			//tbButton.Title=node.Attributes["title"].InnerText;
			//tbButton.ButtonImage=node.Attributes["name"].InnerText;
			/*imgname=ftbComment.ButtonFolder+tbButton.ButtonImage+".gif";
				System.Drawing.Image myimg=System.Drawing.Image.FromFile(Server.MapPath(imgname));
				imgname=Dottext.Framework.Util.Globals.GetAppUrl(Request)+"Emoticons/"+tbButton.ButtonImage+".gif";
				tbButton.=myimg.Height;
				tbButton.Width=myimg.Width;
				tbButton.Function="FTB_"+tbButton.Name+"_ShowFace";
				tbButton.ScriptBlock = @"<script language=""JavaScript"">
				function "+tbButton.Function+@"(editor,htmlmode) {
				editor.focus();
				sel = editor.document.selection.createRange();
				sel.pasteHTML(""<img src='"+imgname+@"'>"");
				}
				</script>";*/
			//msntb.Items.Add(tbButton);
				
			//msntb.Items.Add(separator); 			
		}

		
	}
}
