<%@ Page language="c#" Codebehind="EmoticonsGallery.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.EmoticonsGallery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EmoticonGallery</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	
	</HEAD>
	<body MS_POSITIONING="FlowLayout" rightmargin="0px" topmargin="0px" bottommargin="0px"  leftmargin="0px">
		<form id="Form1" method="post" runat="server">
			<asp:Table id="EmoticonsTable" runat="server"></asp:Table>
		</form>
		<script language="javascript">
	
		//window.setTimeout(sizeDialog,1);
		//sizeDialog();
		function sizeDialog()
		{
			dialogHeight = (parseInt(EmoticonsTable.offsetHeight) + 40) + "px";
			dialogWidth = (parseInt(EmoticonsTable.offsetWidth) +20) + "px";
			//window.setTimeout(centerDialog,1);
			
		}
		
		function centerDialog()
		{
			var TopPosition = (screen.height) ? (screen.height-parseInt(dialogHeight))/2 : 0;
			var LeftPosition = (screen.width) ? (screen.width-parseInt(dialogWidth))/2 : 0;
			dialogTop = TopPosition;
			dialogLeft = LeftPosition;
		}
		
	
		</script>
	</body>
</HTML>
