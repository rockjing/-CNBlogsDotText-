<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.MyLinks" %>
<h1 class = "listtitle">����</h1>
<ul class = "list">
			<li class = "listitem"><asp:HyperLink Runat="server" CssClass="listitem" NavigateUrl="~/Default.aspx" Text="Home" ID="HomeLink" /></li>
			<li class = "listitem"><asp:HyperLink Runat="server" CssClass="listitem" Text="��ҳ" ID="MyHomeLink" /></li>
			<li class = "listitem"><asp:HyperLink Runat="server" CssClass="listitem" Text="�����" ID="NewPostLink" /></li>
			<li class = "listitem"><asp:HyperLink AccessKey = "9" Runat="server" CssClass="listitem" NavigateUrl="~/Contact.aspx" Text="Contact" ID="ContactLink" /></li>
			<li class = "listitem"><asp:HyperLink Runat="server"  CssClass="listitem" NavigateUrl="~/Rss.aspx" Text="Syndication" ID="Syndication" /><asp:HyperLink ImageUrl="~/images/xml.gif" Runat="server" NavigateUrl="~/Rss.aspx" ID="XMLLink" />
			<li class = "listitem"><asp:HyperLink Runat="server" CssClass="listitem" Text="Admin" ID="Admin" /></li>
</ul>