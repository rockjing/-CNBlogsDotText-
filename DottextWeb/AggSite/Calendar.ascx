<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Calendar.ascx.cs" Inherits="Dottext.Web.AggSite.Calendar" %>
<%@ OutputCache Duration="3600" VaryByParam="page;date;id" VaryByCustom="Url" %>
<h2><asp:Literal ID="CalTitle" Runat="server"></asp:Literal>����</h2>
<asp:calendar id="entryCal" runat="server" SelectionMode="None" DayNameFormat="Full" CellPadding="0"
	CellSpacing="0" CssClass="Cal">
	<TodayDayStyle CssClass="CalTodayDay"></TodayDayStyle>
	<SelectorStyle CssClass="CalSelector"></SelectorStyle>
	<NextPrevStyle CssClass="CalNextPrev"></NextPrevStyle>
	<DayHeaderStyle CssClass="CalDayHeader"></DayHeaderStyle>
	<SelectedDayStyle CssClass="CalSelectedDay"></SelectedDayStyle>
	<TitleStyle CssClass="CalTitle"></TitleStyle>
	<WeekendDayStyle CssClass="CalWeekendDay"></WeekendDayStyle>
	<OtherMonthDayStyle CssClass="CalOtherMonthDay"></OtherMonthDayStyle>
</asp:calendar>
