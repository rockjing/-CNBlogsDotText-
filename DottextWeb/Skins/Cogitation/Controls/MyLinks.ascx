<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.MyLinks" %>
&nbsp;
<asp:HyperLink Runat="server" NavigateUrl="~/Default.aspx" Text="Home" ID="HomeLink" />&nbsp;::
<asp:HyperLink Runat="server" Text="我的首页" ID="MyHomeLink" />&nbsp;::
<asp:HyperLink Runat="server" Text="新随笔" ID="NewPostLink" />&nbsp;::
<asp:HyperLink AccessKey="9" Runat="server" NavigateUrl="~/Contact.aspx" Text="Contact" ID="ContactLink" />&nbsp;::
<asp:HyperLink Runat="server" NavigateUrl="~/Rss.aspx" Text="Syndication" ID="Syndication" />
<asp:HyperLink CssClass="XMLLink" ImageUrl="../images/xml.gif" Runat="server" NavigateUrl="~/Rss.aspx" ID="XMLLink" />&nbsp;::
<asp:HyperLink Runat="server" Text="Admin" ID="Admin" />&nbsp;::

