<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.MyLinks" %>
<!--done-->
<asp:HyperLink Runat="server" CssClass="listitem" NavigateUrl="~/Default.aspx" Text="Home" ID="HomeLink" />&nbsp;&nbsp;::&nbsp;
<asp:HyperLink Runat="server" CssClass="listitem" Text="Ê×Ò³" ID="MyHomeLink" />&nbsp;&nbsp;::&nbsp;
<asp:HyperLink Runat="server" CssClass="listitem" Text="ÐÂËæ±Ê" ID="NewPostLink" />&nbsp;&nbsp;::&nbsp;
<asp:HyperLink AccessKey = "9" Runat="server" CssClass="listitem" NavigateUrl="~/Contact.aspx" Text="Contact" ID="ContactLink" />&nbsp;&nbsp;::&nbsp;
<asp:HyperLink Runat="server"  CssClass="listitem" NavigateUrl="~/Rss.aspx" Text="Syndication" ID="Syndication" />&nbsp;<asp:HyperLink ImageUrl="../Images/xml.gif" Runat="server" NavigateUrl="~/Rss.aspx" ID="XMLLink" />&nbsp;&nbsp;::&nbsp;
<asp:HyperLink Runat="server" CssClass="listitem" Text="Admin" ID="Admin" />
