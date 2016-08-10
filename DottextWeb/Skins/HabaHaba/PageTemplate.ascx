<%@ Register TagPrefix="uc1" TagName="MyLinks" Src="Controls/MyLinks.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SingleColumn" Src="Controls/SingleColumn.ascx" %>
<%@ Register TagPrefix="uc1" TagName="News" Src="Controls/News.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BlogStats" Src="Controls/BlogStats.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Footer" Src="Controls/Footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Controls/Header.ascx" %>
<%@ Register TagPrefix="DT" Namespace="Dottext.Web.UI.WebControls" Assembly="Dottext.Web" %>
<%@ Control %>
<%@ Register TagPrefix="uc1" TagName="Calendar" Src="../../UI/Controls/Calendar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MySearch" Src="../../UI/Controls/MySearch.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<table width="100%" class="Framework" cellspacing="0" cellpadding="0">
	<tr>
		<td colspan="2">
			<uc1:Header id="Header1" runat="server"></uc1:Header></td>
	</tr>
	<tr>
		<td class="LeftCell">
			<div id="leftmenu">
				<DT:contentregion id="MPLeftColumn" runat="server">
					<uc1:MyLinks id="MyLinks1" runat="server"></uc1:MyLinks>
					<uc1:News id="News1" runat="server"></uc1:News>
					<uc1:Calendar id="Calendar1" runat="server"></uc1:Calendar>
					<uc1:SingleColumn id="SingleColumn1" runat="server"></uc1:SingleColumn>
				</DT:contentregion>
			</div>
		</td>
		<td class="MainCell" width="100%">
			<div id="main">
				<DT:contentregion id="MPMain" runat="server"></DT:contentregion>
			</div>
		</td>
	</tr>
	<tr>
		<td colspan="2" class="FooterCell">
			<uc1:Footer id="Footer1" runat="server"></uc1:Footer>
		</td>
	</tr>
</table>

