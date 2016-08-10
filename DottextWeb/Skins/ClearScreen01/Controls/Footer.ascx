<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.Footer" %>
<!--done-->
<div class="footer">
	Powered by: 
	<br />
	<asp:HyperLink ImageUrl="~/images/100x30_Logo.gif" NavigateUrl="http://scottwater.com/blog" Runat="server" ID="Hyperlink2" NAME="Hyperlink1"/>
	<asp:HyperLink ImageUrl="~/images/PoweredByAsp.Net.gif" NavigateUrl="http://ASP.NET" Runat="server" ID="Hyperlink3" NAME="Hyperlink1"/>
	<asp:HyperLink ImageUrl="../Images/DotTextSkin.gif" NavigateUrl="http://blogs.clearscreen.com/migs" Runat="server" ID="Hyperlink1" NAME="Hyperlink1"/>
	<br />
	Copyright &copy;<%=System.DateTime.Now.Year.ToString()%> <asp:Literal id="FooterText" runat="server" />
</div>