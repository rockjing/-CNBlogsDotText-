<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.Footer" %>
<p id="footer">
	Powered by: 
	<br />
	<asp:HyperLink ImageUrl="~/images/100x30_Logo.gif" NavigateUrl="http://scottwater.com/blog" Runat="server" ID="Hyperlink2" NAME="Hyperlink1"/>
	<asp:HyperLink ImageUrl="~/images/PoweredByAsp.Net.gif" NavigateUrl="http://ASP.NET" Runat="server" ID="Hyperlink3" NAME="Hyperlink1"/>
	<br />
	Copyright &copy; <asp:Literal id="FooterText" runat="server" />
</p>