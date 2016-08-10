<%@ Page language="c#" %>
<script runat="server" language="C#">

// Messages
private string NoFileMessage = "��û��ѡ���ļ���";
private string UploadSuccessMessage = "�ϴ��ɹ�";
private string UploadFailureMessage = "�ϴ�ʧ�ܡ�";
private string NoImagesMessage = "û��ͼƬ,�����ϴ�!";//"���ļ��в����ڻ����ǿյ�";
private string NoFolderSpecifiedMessage = "��Ҫ�ϴ������ļ��в����ڡ�";
private string NoFileToDeleteMessage = "��û��ѡ��Ҫɾ�����ļ���";
private string InvalidFileTypeMessage = "���޷��ϴ��������͵��ļ���";
private string[] AcceptedFileTypes = new string[] {"..."};

// Configuration
private bool	UploadIsEnabled = false;         // �Ƿ������ϴ��ļ�
private bool	DeleteIsEnabled = false;         // �Ƿ�����ɾ���ļ�
private string	DefaultImageFolder = "Images";  // Ĭ�ϵ���ʼ�ļ���

private void Page_Load(object sender, System.EventArgs e) {
	string isframe = "" + Request["frame"];
	Response.Write("hell");
	if (isframe != "") {
		MainPage.Visible = true;
		iframePanel.Visible = false;
	
		string rif = "" + Request["rif"];
		string cif = "" + Request["cif"];	

		if (cif != "" && rif != "") {
			RootImagesFolder.Value = rif;
			CurrentImagesFolder.Value = cif;
		} else {
			RootImagesFolder.Value = DefaultImageFolder;
			CurrentImagesFolder.Value = DefaultImageFolder;	
		}

		UploadPanel.Visible = false;//UploadIsEnabled;
		DeleteImage.Visible = false;//DeleteIsEnabled;

		string FileErrorMessage = "";
		string ValidationString = ".*(";
		//[\.jpg]|[\.jpeg]|[\.jpe]|[\.gif]|[\.JPG]|[\.JPEG]|[\.JPE]|[\.GIF])$"
		for (int i=0;i<AcceptedFileTypes.Length; i++) {
			ValidationString += "[\\." + AcceptedFileTypes[i] + "]";
			if (i < (AcceptedFileTypes.Length-1)) ValidationString += "|";
			FileErrorMessage += AcceptedFileTypes[i];
			if (i < (AcceptedFileTypes.Length-1)) FileErrorMessage += ", ";
		}
		FileValidator.ValidationExpression = ValidationString+")$";
		FileValidator.ErrorMessage=FileErrorMessage;

		if (!IsPostBack) {
			DisplayImages();
		}
	} else {
		
	}
}

public void UploadImage_OnClick(object sender, EventArgs e) {	
	if (Page.IsValid) {
		if (CurrentImagesFolder.Value != "") {
			if (UploadFile.PostedFile.FileName.Trim() != "") {
				if (IsValidFileType(UploadFile.PostedFile.FileName)) {
					try {
						string UploadFileName = "";
						string UploadFileDestination = "";
						UploadFileName = UploadFile.PostedFile.FileName;
						UploadFileName = UploadFileName.Substring(UploadFileName.LastIndexOf("\\")+1);
						UploadFileDestination = HttpContext.Current.Request.PhysicalApplicationPath;
						UploadFileDestination += CurrentImagesFolder.Value;
						UploadFileDestination += "\\";
						UploadFile.PostedFile.SaveAs(UploadFileDestination + UploadFileName);
						ResultsMessage.Text = UploadSuccessMessage;
					} catch(Exception ex) {
						//ResultsMessage.Text = "Your file could not be uploaded: " + ex.Message;
						ResultsMessage.Text = UploadFailureMessage;
					}
				} else {
					ResultsMessage.Text = InvalidFileTypeMessage;
				}
			} else {
				ResultsMessage.Text = NoFileMessage;
			}
		} else {
			ResultsMessage.Text = NoFolderSpecifiedMessage;
		}
	} else {
		ResultsMessage.Text = InvalidFileTypeMessage;
		
	}
	DisplayImages();
}

public void DeleteImage_OnClick(object sender, EventArgs e) {
	if (FileToDelete.Value != "" && FileToDelete.Value != "undefined") {
		try {
			string AppPath = HttpContext.Current.Request.PhysicalApplicationPath;
			System.IO.File.Delete(AppPath  + CurrentImagesFolder.Value + "\\" + FileToDelete.Value);
			ResultsMessage.Text = "��ɾ��: " + FileToDelete.Value;
		} catch(Exception ex) {			
			ResultsMessage.Text = "ɾ��ʧ�ܡ�";
		}
	} else {
		ResultsMessage.Text = NoFileToDeleteMessage;
	}
	DisplayImages();
}

private bool IsValidFileType(string FileName) {
	string ext = FileName.Substring(FileName.LastIndexOf(".")+1,FileName.Length-FileName.LastIndexOf(".")-1);
	for (int i=0; i<AcceptedFileTypes.Length; i++) {
		if (ext == AcceptedFileTypes[i]) {
			return false;
			
		}	
	}
	return false;
}


private string[] ReturnFilesArray() {
	if (CurrentImagesFolder.Value != "") {
		try {
			string AppPath = HttpContext.Current.Request.PhysicalApplicationPath;
			string ImageFolderPath = AppPath + CurrentImagesFolder.Value;
			if(!System.IO.Directory.Exists(ImageFolderPath))
			{
				System.IO.Directory.CreateDirectory(ImageFolderPath);
			}
			string[] FilesArray = System.IO.Directory.GetFiles(ImageFolderPath,"*");
			return FilesArray;
			
			
		} catch {
		
			return null;
		}
	} else {
		return null;
	}

}

private string[] ReturnDirectoriesArray() {
	if (CurrentImagesFolder.Value != "") {
		try {
			string AppPath = HttpContext.Current.Request.PhysicalApplicationPath;
			string CurrentFolderPath = AppPath + CurrentImagesFolder.Value;
			string[] DirectoriesArray = System.IO.Directory.GetDirectories(CurrentFolderPath,"*");
			return DirectoriesArray ;
		} catch {
			return null;
		}
	} else {
		return null;
	}
}

public void DisplayImages() {
	
	string[] FilesArray = ReturnFilesArray();
	string[] DirectoriesArray = ReturnDirectoriesArray();
	string AppPath = HttpContext.Current.Request.PhysicalApplicationPath;
	string AppUrl;
	
	//Get the application's URL
	if (Request.ApplicationPath == "/")
		AppUrl = Request.ApplicationPath;
	else
		AppUrl = Request.ApplicationPath + "/";
	
	GalleryPanel.Controls.Clear();
	if ( (FilesArray == null || FilesArray.Length == 0) && (DirectoriesArray == null || DirectoriesArray.Length == 0) ) {
		gallerymessage.Text = NoImagesMessage + ": " + RootImagesFolder.Value;
	} else {
		string ImageFileName = "";
		string ImageFileLocation = "";

		int thumbWidth = 25;
		int thumbHeight = 25;
		
		if (CurrentImagesFolder.Value != RootImagesFolder.Value) {

			System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
			myHtmlImage.Src = AppUrl + "images/ftb/folder.up.gif";
			myHtmlImage.Attributes["unselectable"]="on"; 
			myHtmlImage.Attributes["align"]="absmiddle"; 
			myHtmlImage.Attributes["vspace"]="10"; 

			string ParentFolder = CurrentImagesFolder.Value.Substring(0,CurrentImagesFolder.Value.LastIndexOf("\\"));

			System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();					
			myImageHolder.CssClass = "imageholder";
			myImageHolder.Attributes["unselectable"]="on"; 
			myImageHolder.Attributes["onclick"]="divClick(this,'');";  
			myImageHolder.Attributes["ondblclick"]="gotoFolder('" + RootImagesFolder.Value + "','" + ParentFolder.Replace("\\","\\\\") + "');";  
			myImageHolder.Controls.Add(myHtmlImage);

			System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
			myMainHolder.CssClass = "imagespacer";
			myMainHolder.Controls.Add(myImageHolder);

			System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
			myTitleHolder.CssClass = "titleHolder";
			myTitleHolder.Controls.Add(new LiteralControl("����"));
			myMainHolder.Controls.Add(myTitleHolder);

			GalleryPanel.Controls.Add(myMainHolder);		
			
		}
		
		
		
		foreach (string ImageFile in FilesArray) {

			try {

				ImageFileName = ImageFile.ToString();
				ImageFileName = ImageFileName.Substring(ImageFileName.LastIndexOf("\\")+1);
				ImageFileLocation = AppUrl;
				ImageFileLocation = ImageFileLocation.Substring(ImageFileLocation.LastIndexOf("\\")+1);
				//galleryfilelocation += "/";
				ImageFileLocation += CurrentImagesFolder.Value;
				ImageFileLocation += "/";
				ImageFileLocation += ImageFileName;
				System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
				myHtmlImage.Src = ImageFileLocation;
				System.Drawing.Image myImage = System.Drawing.Image.FromFile(ImageFile.ToString());
				myHtmlImage.Attributes["unselectable"]="on";  
				//myHtmlImage.border=0;

				// landscape image
				if (myImage.Width > myImage.Height) {
					if (myImage.Width > thumbWidth) {
						myHtmlImage.Width = thumbWidth;
						myHtmlImage.Height = Convert.ToInt32(myImage.Height * thumbWidth/myImage.Width);						
					} else {
						myHtmlImage.Width = myImage.Width;
						myHtmlImage.Height = myImage.Height;
					}
				// portrait image
				} else {
					if (myImage.Height > thumbHeight) {
						myHtmlImage.Height = thumbHeight;
						myHtmlImage.Width = Convert.ToInt32(myImage.Width * thumbHeight/myImage.Height);
					} else {
						myHtmlImage.Width = myImage.Width;
						myHtmlImage.Height = myImage.Height;
					}
				}
				
				if (myHtmlImage.Height < thumbHeight) {
					myHtmlImage.Attributes["vspace"] = Convert.ToInt32((thumbHeight/2)-(myHtmlImage.Height/2)).ToString(); 
				}


				System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();					
				myImageHolder.CssClass = "imageholder";
				myImageHolder.Attributes["onclick"]="divClick(this,'" + ImageFileName + "');";  
				myImageHolder.Attributes["ondblclick"]="returnImage('" + ImageFileLocation.Replace("\\","/") + "','" + myImage.Width.ToString() + "','" + myImage.Height.ToString() + "');";  
				myImageHolder.Controls.Add(myHtmlImage);


				System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
				myMainHolder.CssClass = "imagespacer";
				myMainHolder.Controls.Add(myImageHolder);

				System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
				myTitleHolder.CssClass = "titleHolder";
				myTitleHolder.Controls.Add(new LiteralControl(ImageFileName + "<BR>" + myImage.Width.ToString() + "x" + myImage.Height.ToString()));
				myMainHolder.Controls.Add(myTitleHolder);

				//GalleryPanel.Controls.Add(myImage);
				GalleryPanel.Controls.Add(myMainHolder);
				
				myImage.Dispose();
			} catch {

			}
		}
		gallerymessage.Text = "";
	}
}
</script>
<asp:panel id="MainPage" runat="server" visible="false">
<!doctype html public "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
<HEAD>
<META HTTP-EQUIV="Expires" CONTENT="0">
<title>����ͼƬ</title>
<style>

body {
	margin: 0px 0px 0px 0px;
	padding: 0px 0px 0px 0px;
	background: #ffffff; 
	width: 100%;
	overflow:hidden;
	border: 0;
}

body,tr,td {
	color: #000000;
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 10pt;
}

div.imagespacer {
	width: 25;
	height: 25;
	text-align: center;			
	float: left;
	font: 10pt verdana;
	margin: 5px;
	overflow: hidden;
}
div.imageholder {
	margin: 0px;
	padding: 0px;
	border: 1 solid #CCCCCC;
	width: 10;
	height: 10;
}

div.titleholder {
	font-family: ms sans serif, arial;
	font-size: 8pt;
	width: 10;
	text-overflow: ellipsis;
	overflow: hidden;
	white-space: nowrap;			
}		

</style>


<script language="javascript">
lastDiv = null;
function divClick(theDiv,filename) {
	if (lastDiv) {
		lastDiv.style.border = "1 solid #CCCCCC";
	}
	lastDiv = theDiv;
	theDiv.style.border = "2 solid #316AC5";
	
	document.getElementById("FileToDelete").value = filename;

}
function gotoFolder(rootfolder,newfolder) {
	window.navigate("ftb.imagegallery.aspx?frame=1&rif=" + rootfolder + "&cif=" + newfolder);
}		
function returnImage(imagename,width,height) {
	var arr = new Array();
	arr["filename"] = imagename;  
	arr["width"] = width;  
	arr["height"] = height;			 
	window.parent.returnValue = arr;
	window.parent.close();	
}		
</script>		
</HEAD>
<body>
<table width=100% height=100% cellpadding=0 cellspacing=0 border=0>

<FORM encType="multipart/form-data" runat="server">

<tr><td>
	<div id="galleryarea" >
		<asp:label id="gallerymessage" runat="server"></asp:label>
		<asp:panel id="GalleryPanel" runat="server"></asp:panel>
	</div>
</td></tr>
<asp:Panel id="UploadPanel" runat="server">
<tr><td height=16 style="padding-left:10px;border-top: 1 solid #999999; background-color:#99ccff;">
	
	<table>
	<tr>
		<td valign=top><input id="UploadFile" type="file" name="UploadFile" runat="server" style="width:300;"/></td>
		<td valign=top><asp:button id="UploadImage" Text="�ϴ�" runat="server" onclick="UploadImage_OnClick" /></td>
		<td valign=top><asp:button id="DeleteImage" Text="ɾ��" runat="server" onclick="DeleteImage_OnClick" /></td>
		<td valign=middle>		
	</tr>
	<tr>
		<td colspan=3>
			<asp:RegularExpressionValidator runat="server" 
				ControlToValidate="UploadFile" 
				id="FileValidator" display="dynamic"/>
			<asp:literal id="ResultsMessage" runat="server" />		
		</td>		
	</tr></table>	
	<input type="hidden" id="FileToDelete" Value="false" runat="server" />
	<input type="hidden" id="RootImagesFolder" Value="BlogImages" runat="server" />
	<input type="hidden" id="CurrentImagesFolder" Value="BlogImages" runat="server" />
</td></tr>
</asp:panel>
</form>
</table>
</body>
</HTML>
</asp:panel>
<asp:panel id="iframePanel" runat="server" >
<html> 
<head><title>����QQ����</title></head>
<style>
body {
	margin: 0px 0px 0px 0px;
	padding: 0px 0px 0px 0px;
	background: #ffffff;
	overflow:hidden;
}
</style>
<body>
	<iframe style="width:100%;height:100%;border:0;" border=0 frameborder=0 src="ftb.imagegallery.aspx?frame=1&<%=Request.QueryString%>"></iframe>
</body>
</html>
</asp:panel>