<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.Day" %>
<%@ Import Namespace = "Dottext.Framework" %>
<p class="date">
	<asp:Literal ID="DateTitle" Runat = "server" />		  
	<asp:HyperLink Runat="server" Title="Day Archive" Text = "#" height="15" Width="12" BorderWidth="0" ID="ImageLink" />
</p>

<asp:Repeater runat="Server" Runat="server" ID="DayList" OnItemCreated="PostCreated">

	<ItemTemplate>
		<div class="post">
			<div class="postTitle">
				<asp:HyperLink Runat="server" ID="TitleUrl" />
			</div>
			
			<div class="postText">
				<asp:Literal  runat="server" ID="PostText" />
			</div>
			
			<div class="postFoot">
				<asp:Literal ID = "PostDesc" Runat = "server" />
			</div>
		</div>
		<br>
	</ItemTemplate>
</asp:Repeater>