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
using System.IO;

namespace Dottext.Web
{
	/// <summary>
	/// EmoticonGallery 的摘要说明。
	/// </summary>
	public class EmoticonsGallery : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Table EmoticonsTable;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			System.IO.StreamReader sr=new System.IO.StreamReader(MapPath("Script")+"\\Emoticon.js");
			this.RegisterClientScriptBlock("EmoticonScript",sr.ReadToEnd());
			sr.Close();

			int ColumnCount=10;
			int index=0;
			int totalWidth=0;
			int totalHeight=0;
			if(Request.QueryString["rif"]==null)
			{
				return;
			}
			string imagepath=Request.QueryString["rif"];
			if(!imagepath.EndsWith("/"))
			{
				imagepath+="/";
			}
			string path=MapPath(imagepath);
			System.IO.DirectoryInfo dir=new System.IO.DirectoryInfo(path);
			TableRow row=new TableRow();
			foreach (FileInfo file in dir.GetFiles())
			{
				TableCell cell=new TableCell();
				
				//System.Web.UI.WebControls.Image image=new System.Web.UI.WebControls.Image();
				//image.ImageUrl=imagepath+"/"+file.Name;
				if(file.Extension.ToLower()==".jpg"||file.Extension.ToLower()==".gif")
				{
					System.Drawing.Image myimg=System.Drawing.Image.FromFile(file.FullName);
					if(EmoticonsTable.Rows.Count==0)
					{
						totalWidth+=myimg.Width+8;
					}
					
					string width=myimg.Width.ToString();
					string height=myimg.Height.ToString();
					string apppath=Dottext.Framework.Util.Globals.GetAppUrl(Request);
					string imgurl=imagepath+file.Name;
					imgurl.Replace("//","/");
					string celltext="<div onclick=\"returnImage('"+apppath+imgurl+"','"+width+"','"+height+"')\">";
					celltext+="<img src='"+imgurl+"'>";
					celltext+="</div>";
					cell.Text=celltext;
					//image.Attributes.Add("ondblclick","returnImage('"+image.ImageUrl+"','"+width+"','"+height+"')");
					//cell.Controls.Add(image);
					row.Cells.Add(cell);
					index++;
					if(index % ColumnCount == 0)
					{
						totalHeight+=myimg.Height+10;
						EmoticonsTable.Rows.Add(row);
						row=new TableRow();
					}
				}

			}
			//EmoticonsTable.Width=new Unit(totalWidth);
			//EmoticonsTable.Height=new Unit(totalHeight);
			Response.Write(string.Format("<script language='javascript'>dialogWidth='{0}px';dialogHeight='{1}px';</script>",totalWidth,totalHeight+10));
			Response.Expires=10;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
