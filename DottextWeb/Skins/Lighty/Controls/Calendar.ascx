<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Calendar.ascx.cs" Inherits="Dottext.Web.UI.Controls.Calendar" %>
<asp:Calendar id="entryCal" runat="server" SelectionMode="None" BackColor="#CCCCCC" Width="100%"
	DayNameFormat="Full" ForeColor="Black" Height="100%" Font-Size="8pt" Font-Names="Verdana"
	BorderColor="#999999" CellPadding="1">
	<TodayDayStyle ForeColor="Black" BackColor="#FFF1E4"></TodayDayStyle>
	<SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
	<NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
	<DayHeaderStyle Font-Size="8pt" Font-Bold="False" Font-Names="Arial" BackColor="#FFF1E4"></DayHeaderStyle>
	<SelectedDayStyle Font-Bold="True" BackColor="Silver"></SelectedDayStyle>
	<TitleStyle  ForeColor="#FF6600" BackColor="#FFF1E4"></TitleStyle>
	<WeekendDayStyle ></WeekendDayStyle>
	<OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle>
</asp:Calendar>
