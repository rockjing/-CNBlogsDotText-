<%@ Register TagPrefix="uc1" TagName="ArchiveLinks" Src="Controls/ArchiveLinks.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SingleColumn" Src="Controls/SingleColumn.ascx" %>
<%@ Register TagPrefix="uc1" TagName="News" Src="Controls/News.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MyLinks" Src="Controls/MyLinks.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CategoryDisplay" Src="Controls/CategoryDisplay.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BlogStats" Src="Controls/BlogStats.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Controls/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Controls/Header.ascx" %>
<%@ Register TagPrefix="DT" Namespace="Dottext.Web.UI.WebControls" Assembly="Dottext.Web" %>
<%@ Control %>
<%@ Register TagPrefix="uc1" TagName="Calendar" Src="../../UI/Controls/Calendar.ascx" %>
<!--done-->
<div id="header">
	<uc1:Header id="Header1" runat="server"></uc1:Header>
</div>
<div id="mylinks"><uc1:MyLinks id="MyLinks1" runat="server"></uc1:MyLinks></div>
<div id="mytopmenu">
	<DT:contentregion id="MPTopColumn" runat="server">
		<DIV id="mystats">
			<uc1:BlogStats id="BlogStats1" runat="server"></uc1:BlogStats></DIV>
	</DT:contentregion>
</div>
<div id="leftcontent">
	<DT:contentregion id="MPLeftColumn" runat="server">
		<DIV id="leftcontentcontainer">
			<uc1:News id="News1" runat="server"></uc1:News>
			<uc1:Calendar id="Calendar1" runat="server"></uc1:Calendar>
			<uc1:SingleColumn id="SingleColumn1" runat="server"></uc1:SingleColumn></DIV>
	</DT:contentregion>
</div>
<div id="centercontent">
	<DT:contentregion id="MPMain" runat="server"></DT:contentregion>
</div>
<uc1:Footer id="Footer1" runat="server"></uc1:Footer>

