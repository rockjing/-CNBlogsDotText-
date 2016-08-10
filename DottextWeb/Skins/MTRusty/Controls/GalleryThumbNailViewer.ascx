<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.GalleryThumbNailViewer" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<br>
<h1><asp:Literal id="GalleryTitle" runat="server" /></h1>
<asp:Literal ID = "Description" Runat = "server" />

<asp:DataList 
  id="ThumbNails" 
  runat="server"
  OnItemCreated = "ImageCreated" 
  Gridlines = "both" 
  BorderColor = "#993300" 
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
		  <font face="Arial" size="2" color="#FF9933">
		    <p align="center">Click on Thumbnail<br> for Larger Image </p>
		  </font>
		</body>
	</ItemTemplate>
</asp:DataList>
