<%@ Register TagPrefix="uc1" TagName="MyLinks" Src="Controls/MyLinks.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SingleColumn" Src="Controls/SingleColumn.ascx" %>
<%@ Register TagPrefix="uc1" TagName="News" Src="Controls/News.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BlogStats" Src="Controls/BlogStats.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Controls/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Controls/Header.ascx" %>
<%@ Register TagPrefix="DT" Namespace="Dottext.Web.UI.WebControls" Assembly="Dottext.Web" %>
<%@ Control %>
<%@ Register TagPrefix="uc1" TagName="Calendar" Src="../../UI/Controls/Calendar.ascx" %>
<div id="container">
	<div id="header"><uc1:Header id="Header1" runat="server"></uc1:Header></div>
	<div class="clr"></div>
	<div id="sidebar-a">
		<DT:contentregion id="MPRightColumn" runat="server">
			<uc1:Calendar id="Calendar1" runat="server"></uc1:Calendar>
			<uc1:News id="News1" runat="server"></uc1:News>
			<uc1:SingleColumn id="SingleColumn1" runat="server"></uc1:SingleColumn>
		</DT:contentregion>
	</div>
	<div id="content">
		<DT:contentregion id="MPMain" runat="server">
		</DT:contentregion>
	</div>
	<div id="footer">
		<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
	</div>
</div>
