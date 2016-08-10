<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.MyLinks" %>
<ul>
	<li>
		<asp:HyperLink Runat="server" NavigateUrl="~/Default.aspx" Text="Home" ID="HomeLink"/></li>
	<li><asp:HyperLink Runat="server" Text="Ê×Ò³" ID="MyHomeLink" /></li>
<li><asp:HyperLink Runat="server" Text="ÐÂËæ±Ê" ID="NewPostLink" /></li>
	<li>
		<asp:HyperLink AccessKey="9" Runat="server" NavigateUrl="~/Contact.aspx" Text="Contact" ID="ContactLink" /></li>
	
	<li>
		<asp:HyperLink Runat="server" Text="Admin" ID="Admin" /></li>
		
</ul><span><asp:HyperLink ImageUrl="~/images/xml.gif" Runat="server" NavigateUrl="~/Rss.aspx" ID="XMLLink" >RSS 2.0 Feed</asp:HyperLink><asp:HyperLink Runat="server" NavigateUrl="~/Rss.aspx" Text="Syndication" ID="Syndication" Visible="False" /></span>
