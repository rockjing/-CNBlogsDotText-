<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.Login" %>
<h3 class = "listtitle">Sign In</h3>
	<ul class = "list">
		Username<br><asp:TextBox CssClass="TextBox" id="tbUserName" runat="server" /><br>
		Password<br><asp:TextBox CssClass="Textbox" id="tbPassword" TextMode="Password" runat="server" /><br>
		<asp:Button id="btnLogin" CssClass="Button" runat="server" Text="Log In" CausesValidation="False" />
		&nbsp;<asp:CheckBox ID = "RememberMe" Checked="True" Runat = "server" />Remember Me
		&nbsp;<asp:Literal id="Message" runat="server" />
</ul>