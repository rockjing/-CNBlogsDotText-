<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.MyLinks" %>
<h3>����</h3>
<ul>
	<li>
		<asp:HyperLink Runat="server" NavigateUrl="~/Default.aspx" Text="��ҳ" ID="HomeLink" />
	<li><asp:HyperLink Runat="server" Text="��ҳ" ID="MyHomeLink" /></li>
	<li><asp:HyperLink Runat="server" Text="�����" ID="NewPostLink" /></li>
	<li>
		<asp:HyperLink AccessKey="9" Runat="server" NavigateUrl="~/Contact.aspx" Text="��ϵ" ID="ContactLink" />
	<li>
		<asp:HyperLink Runat="server" NavigateUrl="~/Rss.aspx" Text="�ۺ�" ID="Syndication" /><asp:HyperLink ImageUrl="~/images/xml.gif" Runat="server" NavigateUrl="~/Rss.aspx" ID="XMLLink" />
	<li>
		<asp:HyperLink Runat="server" Text="����" ID="Admin" /></li>
</ul>
