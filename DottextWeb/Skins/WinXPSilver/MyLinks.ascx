<%@ Control Language="c#" Inherits="Dottext.Web.Skins.WinXPSilver.MyLinks" CodeBehind="MyLinks.ascx.cs" AutoEventWireup="false" %>
<asp:HyperLink Runat="server" NavigateUrl="~/Default.aspx" Text="Home" ID="HomeLink" /><asp:Image ID="Divider1" ImageUrl="../Images/divider.gif" Runat="server" ImageAlign="AbsMiddle"></asp:Image>
<asp:HyperLink AccessKey="9" Runat="server" NavigateUrl="~/Contact.aspx" Text="Contact" ID="ContactLink" /><asp:Image ID="Divider2" ImageUrl="../Images/divider.gif" Runat="server" ImageAlign="AbsMiddle"></asp:Image>
<asp:HyperLink Runat="server" NavigateUrl="~/Rss.aspx" target="_blank" Text="Syndicate this Site (RSS 2.0)" ID="Syndication" /><asp:Image ID="Divider3" ImageUrl="../Images/divider.gif" Runat="server" ImageAlign="AbsMiddle"></asp:Image>
<!--<asp:HyperLink Runat="server" NavigateUrl="~/Atom.aspx" target="_blank" Text="Syndicate this Site (Atom)" ID="Syndication2" /><asp:Image ID="Divider6" ImageUrl="../Images/divider.gif" Runat="server" ImageAlign="AbsMiddle"></asp:Image>
<asp:HyperLink Runat="server" NavigateUrl="~/Atom.aspx" target="_blank" Text="" CssClass="XMLLink" ID="XMLLink" />-->
<asp:HyperLink Runat="server" Text="Admin" ID="Admin" /><asp:Image ID="Divider5" ImageUrl="../Images/divider.gif" Runat="server" ImageAlign="AbsMiddle"></asp:Image>
