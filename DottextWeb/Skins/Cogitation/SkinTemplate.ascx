<%@ Register TagPrefix="uc1" TagName="MyLinks" Src="Controls/MyLinks.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SingleColumn" Src="Controls/SingleColumn.ascx" %>
<%@ Register TagPrefix="uc1" TagName="News" Src="Controls/News.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Controls/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Controls/Header.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.PageTemplate" %>
<%@ Register TagPrefix="uc1" TagName="Calendar" Src="../../UI/Controls/Calendar.ascx" %>
<div id="top">
	<uc1:Header id="Header1" runat="server"></uc1:Header>
</div>
<div id="leftmenu">
	<uc1:Calendar id="Calendar1" runat="server"></uc1:Calendar>
	<uc1:News id="News1" runat="server"></uc1:News>
	<uc1:SingleColumn id="SingleColumn1" runat="server"></uc1:SingleColumn>
</div>
<div id="main">
	<asp:PlaceHolder id="BodyControl" runat="server" />
</div>
<uc1:Footer id="Footer1" runat="server"></uc1:Footer>

