<%@ Register TagPrefix="uc1" TagName="ListTitle" Src="ListTitle.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SiteNavigate.ascx.cs" Inherits="Dottext.Web.AggSite.SiteNavigate" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<H2>Cnblogs
	<asp:Literal id="NavTitle" Runat="Server"></asp:Literal></H2>
<UL class="NavLink">
	<LI class="NavLinkli">
		<asp:hyperlink id="RegisterLink" runat="server" NavigateUrl="~/Register.aspx" Text="新博客注册"></asp:hyperlink>
		- - - -
		<asp:hyperlink id="lnkCnblogs" runat="server" NavigateUrl="http://www.cnblogs.com" Text="博客园"></asp:hyperlink>
	<LI class="NavLinkli">
		<uc1:ListTitle id="ListTitle1" runat="server"></uc1:ListTitle>
		- - - -
		<asp:hyperlink id="TopReadLink" runat="server" NavigateUrl="~/TopPosts.aspx" Text="排行榜"></asp:hyperlink>
	<LI class="NavLinkli">
		<asp:hyperlink id="NewPost" Runat="server" NavigateUrl="~/EnterMyBlog.aspx?NewPost=1" Text="发表新随笔"></asp:hyperlink>
		- - - -
		<asp:hyperlink id="lnkBlogList" Runat="server" NavigateUrl="~/BlogList.aspx" Text="博客列表"></asp:hyperlink>
	<LI class="NavLinkli">
		<asp:hyperlink id="Hyperlink5" Runat="server" NavigateUrl="~/EnterMyBlog.aspx?NewArticle=1" Text="发表新文章"></asp:hyperlink>
		- - - -
		<asp:hyperlink id="lnkCategoryList" Runat="server" NavigateUrl="~/HomePage.aspx" Text="分类列表浏览"></asp:hyperlink>
	<LI class="NavLinkli">
		<asp:hyperlink id="lnkBloggerRead" Runat="server" NavigateUrl="http://www.cnblogs.com/dudu/articles/51993.aspx">博客必读</asp:hyperlink>
		- - - - -
		<asp:hyperlink id="lnkLogin" Runat="server"></asp:hyperlink>
	<LI class="NavLinkli">
		<asp:hyperlink id="EnterMyBlogLink" runat="server" NavigateUrl="~/EnterMyBlog.aspx" Text="==》进入我的博客《=="></asp:hyperlink>
	</LI>
</UL>
