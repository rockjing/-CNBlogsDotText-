<%@ Register TagPrefix="uc1" TagName="BlogStats" Src="BlogStats.ascx" %>
<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.Header" %>
<div id="top">
<table width="100%" cellpadding="8" cellspacing="0">
	<tr>
		<td nowrap>
			<h1><asp:HyperLink id="HeaderTitle" CssClass="headermaintitle" runat="server" /></h1>
			<asp:Literal id="HeaderSubTitle" runat="server" />
		</td>
	</tr>
</table>
</div>
<div id="sub"><uc1:BlogStats id="BlogStats1" runat="server"></uc1:BlogStats></div>


