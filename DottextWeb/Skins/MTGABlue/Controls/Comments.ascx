<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.Comments" %>

<div id="comments">
<h3>Feedback</h3>
	<font color="#999966" size="2"><asp:Literal ID = "NoCommentMessage" Runat ="server" /></font>
	<asp:Repeater id="CommentList" runat="server" OnItemCreated="CommentsCreated" OnItemCommand="RemoveComment_ItemCommand">
		<ItemTemplate>
			<h4>
				<asp:Literal Runat = "server" ID = "Title" />
					<span>
						<asp:Literal id = "PostDate" Runat = "server" />
					</span>
				<asp:HyperLink Target="_blank" Runat="server" ID="NameLink" />
			</h4>
			<p>
				<asp:Literal id = "PostText" Runat = "server" />
				<asp:LinkButton Runat="server" ID="EditLink" CausesValidation="False" />
				
			</p>
		</ItemTemplate>
		
	</asp:Repeater>
<br>
</div>