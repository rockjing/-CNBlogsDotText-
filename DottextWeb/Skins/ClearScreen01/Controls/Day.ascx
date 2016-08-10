<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.Day" %>
<%@ Import Namespace = "Dottext.Framework" %>

<div class="day">
	<div class = "dayTitle">
		<asp:HyperLink Runat="server" Title = "Day link" ImageUrl="~/images/link.gif" height="15" Width="12" vspace="100" BorderWidth="0" ID="ImageLink" />
		&nbsp;
		<asp:Literal ID = "DateTitle" Runat = "server" />		  
	</div>

	<asp:Repeater runat="Server" Runat="server" ID="DayList" OnItemCreated="PostCreated">
		<ItemTemplate>
			<div class = "postTitle">
				<asp:HyperLink  CssClass="postTitle2" Runat="server" ID="TitleUrl" />
			</div>
			<asp:Literal id="PostText"  runat="server" />
			<div class = "postDesc"><asp:Literal id="PostDesc"  runat="server" /></div>
		</ItemTemplate>
		<SeparatorTemplate>
			<div class="postSeparator"></div>
		</SeparatorTemplate>
	</asp:Repeater>
</div>