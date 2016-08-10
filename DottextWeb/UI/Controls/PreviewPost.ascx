<%@ Control Language="c#" AutoEventWireup="false" Codebehind="PreviewPost.ascx.cs" Inherits="Dottext.Web.UI.Controls.PreviewPost" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ OutputCache Duration="1" VaryByParam="*" VaryByCustom="Url" %>
<div class="post">
	<h2>
		<asp:HyperLink Runat="server" ID="TitleUrl" />
	</h2>
	<div class="postbody">
		<asp:Literal id="Body" runat="server" />
	</div>
	<p class="postfoot" align="right">
			<a href="#" onclick="window.close()">¹Ø±Õ</a>
	</p>
</div>
