<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.Day" %>
<%@ Import Namespace = "Dottext.Framework" %>
<p class="date">
	<asp:Literal ID = "DateTitle" Runat = "server" />		  
	<asp:HyperLink Runat="server" Title = "Day Archive" Text = "#" height="15" Width="12" BorderWidth="0" ID="ImageLink" />
</p>

<asp:Repeater runat="Server" Runat="server" ID="DayList" OnItemCreated="PostCreated">

	<ItemTemplate>
		<div class="post">
			<h2><asp:HyperLink Runat="server" ID="TitleUrl" /></h2>
			
			<asp:Literal  runat="server" ID="PostText" />
			
			<p class="postfoot">		
				<asp:Literal ID = "PostDesc" Runat = "server" />
			</p>
		</div>
	</ItemTemplate>
</asp:Repeater>
