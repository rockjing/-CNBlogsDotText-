<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.Day" %>
<%@ Import Namespace = "Dottext.Framework" %>
<p class="date">
	<span>		  
	<asp:HyperLink Runat="server" Title = "Day Archive" BorderWidth="0" ID="ImageLink" ><asp:Literal ID = "DateTitle" Runat = "server" /></asp:HyperLink>
	</span>
</p>

<asp:Repeater runat="Server" Runat="server" ID="DayList" OnItemCreated="PostCreated">

	<ItemTemplate>
		<div class="post" style="filter:progid:DXImageTransform.Microsoft.Shadow(color='Blue', Direction=135, Strength=32)">
			<div class="posthead">
				<h2 style="padding-top:4px; padding-bottom:4px;"><asp:HyperLink Runat="server" ID="TitleUrl" /></h2>
			</div>
			<div class="postbody"><asp:Literal  runat="server" ID="PostText" /></div>
			
			<p class="postfoot">		
				<asp:Literal ID = "PostDesc" Runat = "server" />
			</p>
		</div>
	</ItemTemplate>
</asp:Repeater>
