<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Calendar.ascx.cs" Inherits="Dottext.Web.UI.Controls.Calendar" %>
<asp:Calendar id="entryCal" runat="server" SelectionMode="None" BackColor="#EEEEEE" Width="200px"
	DayNameFormat="Full" ForeColor="Black" Height="180px" Font-Size="8pt" Font-Names="Verdana"
	BorderColor="#999999" CellPadding="4">
	<TodayDayStyle ForeColor="Black" BackColor="#CCCCCC"></TodayDayStyle>
	<SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
	<NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
	<DayHeaderStyle Font-Size="8pt" Font-Bold="False" BackColor="#CCCCCC" Font-Names="Arial"></DayHeaderStyle>
	<SelectedDayStyle Font-Bold="True" BackColor="Silver"></SelectedDayStyle>
	<TitleStyle Font-Bold="True" BorderColor="Black" BackColor="#999999"></TitleStyle>
	<WeekendDayStyle BackColor="#EEEEEE"></WeekendDayStyle>
	<OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle>
	
</asp:Calendar>
