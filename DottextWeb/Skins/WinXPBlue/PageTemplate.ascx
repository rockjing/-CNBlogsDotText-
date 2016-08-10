<%@ Register TagPrefix="uc1" TagName="MyLinks" Src="Controls/MyLinks.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SingleColumn" Src="Controls/SingleColumn.ascx" %>
<%@ Register TagPrefix="uc1" TagName="News" Src="Controls/News.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BlogStats" Src="Controls/BlogStats.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Controls/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Controls/Header.ascx" %>
<%@ Register TagPrefix="DT" Namespace="Dottext.Web.UI.WebControls" Assembly="Dottext.Web" %>
<%@ Control %>
<div id="top">
	<uc1:Header id="Header1" runat="server"></uc1:Header>
</div>
<div id="leftmenu">
	<DT:contentregion id="MPLeftColumn" runat="server">
		<uc1:News id="News1" runat="server"></uc1:News>
		<uc1:SingleColumn id="SingleColumn1" runat="server"></uc1:SingleColumn>
	</DT:contentregion>
<!--
	<br><br>
	<p align="center">
	<a href="http://www.WebHost4Life.com/default.asp?refid=MarkHWagner">
	<img src="http://www.WebHost4Life.com/images/banner3.gif" width="120"
	height="60" border="0" alt="Join WebHost4Life.com"></a>
	</p>
-->
</div>

<div id="main">
	<DT:contentregion id="MPMain" runat="server"></DT:contentregion>
</div>
<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
