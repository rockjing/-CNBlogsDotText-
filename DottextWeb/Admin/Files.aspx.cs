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
using System.Configuration;
using System.Text.RegularExpressions;

using Dottext.Framework;
using Dottext.Framework.Components;
using Dottext.Framework.Util;
using Dottext.Framework.Configuration;

namespace Dottext.Web.Admin.Pages
{
	/// <summary>
	/// Summary description for Files.
	/// </summary>
	public class Files : AdminPage
	{
		protected System.Web.UI.WebControls.LinkButton lnkDelete;
		protected System.Web.UI.WebControls.LinkButton lbkAddFile;
		protected Dottext.Web.Admin.WebUI.MessagePanel Messages;
		
		private string userFolder;
		private string UploadUrl;
		private string filename;
		private long OnceUploadLimit=0;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel AddFiles;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Results;
		protected Dottext.Web.Admin.WebUI.Page PageContainer;
		protected System.Web.UI.WebControls.Repeater fileRepeater;
		protected System.Web.UI.WebControls.Literal TotalSize;
		protected System.Web.UI.WebControls.Literal OnceSize;
		protected System.Web.UI.WebControls.Literal UsedSize;
		protected System.Web.UI.WebControls.Literal LeftSize;
		protected System.Web.UI.WebControls.Literal ltFileType;
		private long TotalUploadLimit=0;
		protected System.Web.UI.HtmlControls.HtmlInputFile myFile;
		private BlogFileCollection bfc;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!(Security.IsInRole("UploadUsers")||Config.Settings.EnableAllUserUpload))
			{
				return;
			}
			
			try
			{
				OnceUploadLimit=long.Parse(ConfigurationSettings.AppSettings["OnceUploadLimit"]);
				OnceSize.Text=OnceUploadLimit.ToString();
			}
			catch(Exception e1)
			{
				Messages.ShowError(e1.Message);
			}
			try
			{
				TotalUploadLimit=long.Parse(ConfigurationSettings.AppSettings["TotalUploadLimit"]);
				TotalSize.Text=TotalUploadLimit.ToString();
			}
			catch(Exception e2)
			{
				Messages.ShowError(e2.Message);
				
			}

			ltFileType.Text=ConfigurationSettings.AppSettings["UploadFileType"];
			string app=Request.ApplicationPath;
			if(!app.EndsWith("/"))
			{
				app+="/";
			}
			string tmpstr=ConfigurationSettings.AppSettings["UploadPath"]+"/"+Config.CurrentBlog().UserName+"/";
			UploadUrl=Dottext.Framework.Util.Globals.GetAppUrl(Request)+tmpstr;
			userFolder=MapPath(app+tmpstr);
			
			if (IsPostBack)
			{
				if (myFile.PostedFile.ContentLength > 0) SaveFileToUserFolder(myFile);
			}

			ReadFiles();
			UsedSize.Text=(GetTotalFileSize()/1024).ToString();
			LeftSize.Text=(long.Parse(ConfigurationSettings.AppSettings["TotalUploadLimit"])-GetTotalFileSize()/1024).ToString();

		}

		private void CheckUserFolder()
		{
			try 
			{
				if (!System.IO.Directory.Exists(userFolder)) System.IO.Directory.CreateDirectory(userFolder);
			}
			catch (Exception e)
			{
				Messages.ShowError(e.Message);
			}

		}

		private bool CheckUploadFile(System.Web.UI.HtmlControls.HtmlInputFile file)
		{
			string fname=file.PostedFile.FileName;
			filename=fname.Substring(fname.LastIndexOf("\\")+1);
			if(!ValidateFileType(filename))
			{
				Messages.ShowError("上传文件类型不符合要求,只能上传"+ConfigurationSettings.AppSettings["UploadFileType"]+"类型文件");
				return false;
			}
            
			if(file.PostedFile.ContentLength>(OnceUploadLimit*1024))
			{
				Messages.ShowError("上传文件超出规定大小"+OnceUploadLimit.ToString()+"KB");
				return false;
			}
			if(File.Exists(this.userFolder+filename))
			{
				Messages.ShowError("已存在相同文件名的文件!");
				return false;
			}
			if((GetTotalFileSize()+file.PostedFile.ContentLength)>(TotalUploadLimit*1024))
			{
				Messages.ShowError("已达到上传文件总容量限制!"+TotalUploadLimit.ToString()+"KB");
				return false;
			}
			return true;
			

		}
		
		private long GetTotalFileSize()
		{
			bfc=BlogFiles.GetBlogFileCollection(this.userFolder,this.UploadUrl);
			return bfc.TotalSize;
			
		}
		public  bool ValidateFileType(string filename)
		{
			string regexstr=ConfigurationSettings.AppSettings["UploadFileType"];
			return Regex.IsMatch(filename,regexstr,	RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
		}

		private void SaveFileToUserFolder(System.Web.UI.HtmlControls.HtmlInputFile theFile)
		{
			CheckUserFolder();
			if(!CheckUploadFile(theFile))
			{
				return;
			}
			try
			{
				//string fileName = System.Text.RegularExpressions.Regex.Match(theFile.PostedFile.FileName, @"\\\w*\.\w*", System.Text.RegularExpressions.RegexOptions.RightToLeft).ToString().Replace("\\","");
				//fileName = Server.MapPath("..\\files\\" + fileName);

				if(Images.SaveFile(Images.GetFileStream(theFile.PostedFile),this.userFolder+this.filename))
				{

					//this.Messages.ShowMessage(Images.GetFileStream(theFile.PostedFile).Length.ToString()+this.filename);//Constants.RES_SUCCESSEDIT);
					Response.Redirect(Request.RawUrl);
				}
				else
				{
					this.Messages.ShowError("上传失败");
				}
			}
			catch (Exception e)
			{
				Messages.ShowError(e.Message);
				//Messages.ShowError(userFolder+theFile.PostedFile.FileName);

			}
		}


		private void ReadFiles()
		{
			CheckUserFolder();

			try
			{
				bfc=BlogFiles.GetBlogFileCollection(this.userFolder,this.UploadUrl);//dirInfo.GetFiles();//System.IO.Directory.GetFiles(userFolder);
				fileRepeater.DataSource=bfc;
				fileRepeater.DataBind();
			}
			catch (Exception e)
			{
				Messages.ShowError(e.Message);
			}
		}

		private void DeleteUserFile(string theFile)
		{
			try
			{
				System.IO.File.Delete(this.userFolder+theFile);
				Messages.ShowMessage("The file has been deleted");
			}
			catch (Exception e)
			{
				Messages.ShowError(e.Message);
			}
		}

		public string GenerateURL(string theFile)
		{
			string url = UploadUrl;//Config.CurrentBlog().FullyQualifiedUrl + "files/";
			url += theFile.Substring(theFile.ToString().LastIndexOf("\\") + 1);
			return url;
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.fileRepeater.ItemCreated += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.fileRepeater_ItemCreated);
			this.fileRepeater.ItemCommand += new System.Web.UI.WebControls.RepeaterCommandEventHandler(this.fileRepeater_ItemCommand_1);
			this.lbkAddFile.Click += new System.EventHandler(this.lbkAddFile_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void fileRepeater_ItemCreated(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			foreach(Control con in e.Item.Controls)//得到每个控件
			{
				if(con is LinkButton)//检查每个控件,看是否是DataGridLinkButton
					//奇怪的是在System.Web.UI.WebControls中没有这个类，我是通过Response.Write(con.ToString())发现的
				{
					LinkButton lb=(LinkButton)con;
					if(lb.CommandName=="Delete")
					{
						lb.Attributes.Add("onclick", "return confirm('您真的要删除该文件吗？')");
					}
				}
			}


		}

		private void fileRepeater_ItemCommand_1(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{
			switch (e.CommandName.ToLower()) 
			{
				case "delete" :
					DeleteUserFile(e.CommandArgument.ToString());
					Response.Redirect(Request.RawUrl);
					break;
				default:
					break;
			}		
		}

		private void lbkAddFile_Click(object sender, System.EventArgs e)
		{
			SaveFileToUserFolder(this.myFile);
			
		}

		
		
	}
}
