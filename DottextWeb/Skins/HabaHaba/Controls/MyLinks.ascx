<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.MyLinks" %>
<h3>����</h3>
<ul>
	<li>
		<asp:HyperLink Runat="server" NavigateUrl="~/Default.aspx" Text="Home" ID="HomeLink" />
	<li>
		<asp:HyperLink Runat="server" Text="�ҵ���ҳ" ID="MyHomeLink" />
	<li>
		<asp:HyperLink Runat="server" Text="�����" ID="NewPostLink" />
	<li>
		<asp:HyperLink AccessKey="9" Runat="server" NavigateUrl="~/Contact.aspx" Text="Contact" ID="ContactLink" />
	<li>
		<asp:HyperLink ImageUrl="~/images/xml.gif" Runat="server" NavigateUrl="~/Rss.aspx" ID="XMLLink">RSS 2.0 Feed</asp:HyperLink><asp:HyperLink Runat="server" NavigateUrl="~/Rss.aspx" Text="Syndication" ID="Syndication" Visible="False" />
	<li>
		<asp:HyperLink Runat="server" Text="Admin" ID="Admin" /></li>
</ul>
