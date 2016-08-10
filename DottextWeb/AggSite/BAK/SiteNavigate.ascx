<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SiteNavigate.ascx.cs" Inherits="Dottext.Web.AggSite.SiteNavigate" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="uc1" TagName="ListTitle" Src="ListTitle.ascx" %>
<H2><asp:Literal id="NavTitle" Runat="Server"></asp:Literal></H2>
<UL class="NavLink">
	<LI class="NavLinkli">
		<asp:hyperlink id="RegisterLink" runat="server" NavigateUrl="~/Register.aspx" Text="�²���ע��"></asp:hyperlink>
	<LI class="NavLinkli">
		<uc1:ListTitle id="ListTitle1" runat="server"></uc1:ListTitle>
	<LI class="NavLinkli">
		<asp:hyperlink id="EnterMyBlogLink" runat="server" NavigateUrl="~/EnterMyBlog.aspx" Text="�����ҵĲ���"></asp:hyperlink>
	<LI class="NavLinkli">
		<asp:hyperlink id="TopReadLink" runat="server" NavigateUrl="~/TopPosts.aspx" Text="���а�"></asp:hyperlink>
	<LI class="NavLinkli">
		<asp:hyperlink id="NewPost" Runat="server" NavigateUrl="~/EnterMyBlog.aspx?NewPost=1" Text="���������"></asp:hyperlink>
	<LI class="NavLinkli">
		<asp:hyperlink id="Hyperlink5" Runat="server" NavigateUrl="~/EnterMyBlog.aspx?NewArticle=1" Text="����������"></asp:hyperlink>
	</LI>
</UL>
