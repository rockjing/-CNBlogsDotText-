<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.Comments" %>
<div class="post">
<a name="feedback" />
<div class="moreinfo">
	<div class="moreinfotitle">
		Comments
	</div>
	<asp:Literal ID = "NoCommentMessage" Runat ="server" />
	<asp:Repeater id="CommentList" runat="server" OnItemCreated="CommentsCreated" OnItemCommand="RemoveComment_ItemCommand">
		<HeaderTemplate>
			<div class="comments">
		</HeaderTemplate>
		<ItemTemplate>
			<div class="comment">
				<div class="comment_title">
					<asp:Literal Runat = "server" ID = "Title" />
				</div>
				<div class="comment_author"><asp:HyperLink Target="_blank" Runat="server" ID="NameLink" /></div>
				<div class="comment_content"><asp:Literal id = "PostText" Runat = "server" /></div>
				<div class="itemdesc">Posted @ <asp:Literal id = "PostDate" Runat = "server" />&nbsp;&nbsp;<asp:LinkButton Runat="server" ID="EditLink" CausesValidation="False" /></div>
			</div>
		</ItemTemplate>
		<FooterTemplate>
			</div>
		</FooterTemplate>
	</asp:Repeater>
</div>
</div>
<div class="seperator">&nbsp;</div>
