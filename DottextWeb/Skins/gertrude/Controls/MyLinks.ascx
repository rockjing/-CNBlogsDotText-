<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.MyLinks" %>
<h3>����</h3>
<ul>
			<li><asp:HyperLink Runat="server" NavigateUrl="~/Default.aspx" Text="Home" ID="HomeLink" /></li>
			<li><asp:HyperLink Runat="server" Text="��ҳ" ID="MyHomeLink" /></li>
			<li><asp:HyperLink Runat="server" Text="�����" ID="NewPostLink" /></li>
			<li><asp:HyperLink AccessKey = "9" Runat="server" NavigateUrl="~/Contact.aspx" Text="Contact" ID="ContactLink" /></li>
			<li><asp:HyperLink Runat="server"  NavigateUrl="~/Rss.aspx" Text="Syndication" ID="Syndication" /><asp:HyperLink ImageUrl="~/images/xml.gif" Runat="server" NavigateUrl="~/Rss.aspx" ID="XMLLink" />
			<li><asp:HyperLink Runat="server" Text="Admin" ID="Admin" /></li>
</ul>