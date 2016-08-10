<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.GalleryThumbNailViewer" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<br>
<h1><asp:Literal id="GalleryTitle" runat="server" /></h1>
<asp:Literal ID = "Description" Runat = "server" />

<asp:DataList 
  id="ThumbNails" 
  runat="server"
  OnItemCreated = "ImageCreated" 
  Gridlines = "both" 
  BorderColor = "#000000" 
  BorderStyle = "None" 
  BorderWidth = "1" 
  cellpadding = "10" 
  cellspacing = "25" 
  RepeatColumns = "3" 
  RepeatDirection = "Horizontal"
  HorizontalAlign = "center">
	<ItemTemplate>
		<p align="center"><asp:HyperLink Runat="server" ID="ThumbNailImage" /></p>
		<body>
		  <br>
		  <font face="palatino" size="1" color="#000000">
		    <p align="center">Click on Thumbnail<br> for Larger Image </p>
		  </font>
		</body>
	</ItemTemplate>
</asp:DataList>
