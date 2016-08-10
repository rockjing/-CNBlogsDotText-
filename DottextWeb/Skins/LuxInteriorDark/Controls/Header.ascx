<%@ Register TagPrefix="uc1" TagName="BlogStats" Src="BlogStats.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MyLinks" Src="Mylinks.ascx" %>
<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.Header" %>
<div id="top">
			<h1><asp:HyperLink id="HeaderTitle" CssClass="weblogtitle" runat="server" /></h1>
			<p><asp:Literal id="HeaderSubTitle" runat="server" /></p>
			</div>
<div id="navstats"><uc1:BlogStats id="BlogStats1" runat="server"></uc1:BlogStats></div><div id="nav"><uc1:MyLinks id="MyLinks1" runat="server"></uc1:MyLinks></div>


