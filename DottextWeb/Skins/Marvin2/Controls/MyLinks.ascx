<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.MyLinks" %>
<h3>导航</h3>
<ul>
	<li>
		<asp:HyperLink Runat="server" NavigateUrl="~/Default.aspx" Text="首页" ID="HomeLink" />
	<li><asp:HyperLink Runat="server" Text="首页" ID="MyHomeLink" /></li>
	<li><asp:HyperLink Runat="server" Text="新随笔" ID="NewPostLink" /></li>
	<li>
		<asp:HyperLink AccessKey="9" Runat="server" NavigateUrl="~/Contact.aspx" Text="联系" ID="ContactLink" />
	<li>
		<asp:HyperLink Runat="server" NavigateUrl="~/Rss.aspx" Text="聚合" ID="Syndication" /><asp:HyperLink ImageUrl="~/images/xml.gif" Runat="server" NavigateUrl="~/Rss.aspx" ID="XMLLink" />
	<li>
		<asp:HyperLink Runat="server" Text="管理" ID="Admin" /></li>
</ul>
