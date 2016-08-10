<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.Day" %>
<%@ Import Namespace = "Dottext.Framework" %>
<p class="date">
	<span>		  
	<asp:HyperLink Runat="server" Title = "Day Archive" BorderWidth="0" ID="ImageLink" ><asp:Literal ID = "DateTitle" Runat = "server" /></asp:HyperLink>
	</span>
</p>

<asp:Repeater runat="Server" Runat="server" ID="DayList" OnItemCreated="PostCreated">

	<ItemTemplate>
		<div class="post">
			<h2><asp:HyperLink Runat="server" ID="TitleUrl" /></h2>
			<div class="postbody">
			<asp:Literal  runat="server" ID="PostText" />
			</div>
			<p class="postfoot">		
			<asp:Literal ID = "PostDesc" Runat = "server" />
			</p>
		</div>
	</ItemTemplate>
</asp:Repeater>
