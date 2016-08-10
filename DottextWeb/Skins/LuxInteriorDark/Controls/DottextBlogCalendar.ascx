<%@ Control language="C#" classname="DottextBlogCalendar" inherits="Dottext.Web.UI.Controls.BaseControl" %>
<%@import namespace="System.Data" %>
<%@import namespace="Dottext.Common.Data"%>
<%@import namespace="Dottext.Framework.Components"%>
<script runat="server">
// DottextBlogCalendar created on 2/14/2004 by:
//*Scott Willeke (http://blogs.pingpoet.com/overflow)
//
//With inspiration and guidance from:
//*Scott Mitchell (http://scottonwriting.net/sowblog/posts/708.aspx)
//*Scott Watermasysk (http://scottwater.com/blog/archive/2004/02/13/CalendarControl.aspx)
		
	// The list of entries found for the month
	EntryCollection _monthEntries;
	// Current index into _monthEntries.
	int _currentDateIndex;
	// Number of entries in _monthEntries
	int _dateCount;
	// True if the url is for a month and not a day (see ChooseSelectedDateFromUrl).
	bool _isUrlMonthMode;
	
	
	
	/// <summary>
	/// If the page is on a "day page" then have the calendar select the day the URL is on. 
	///	Otherwise use the current day.
	/// </summary>
	void Page_Load(object sender, System.EventArgs e)
	{
		DateTime selectedDate = ChooseSelectedDateFromUrl();
		entryCal.ToolTip = selectedDate.ToShortDateString();

		// Setup current month			
		entryCal.SelectedDate = selectedDate;
		entryCal.VisibleDate = selectedDate;
		
		// setup prev/next months
		DateTime tempDate;
		tempDate = selectedDate.AddMonths(-1);
		entryCal.PrevMonthText = string.Format("<a href=\"{0}\">{1}</a>", CurrentBlog.UrlFormats.MonthUrl(tempDate), string.Format("{0:MMM}",tempDate));
		tempDate = selectedDate.AddMonths(1);
		entryCal.NextMonthText = string.Format("<a href=\"{0}\">{1}</a>", CurrentBlog.UrlFormats.MonthUrl(tempDate), string.Format("{0:MMM}",tempDate));
		
		// fix the selected date if we're in "month mode"
//		if (_isUrlMonthMode)
//			entryCal.SelectedDate = DateTime.MinValue;
		
		LoadMonthData();
	}
	
	
	/// <summary>
	/// Chooses the selected date from the url.
	/// </summary>
	/// <returns></returns>
	private DateTime ChooseSelectedDateFromUrl()
	{
		string dateStr;
		DateTime parsedDate = DateTime.MinValue;
		Regex match;
		_isUrlMonthMode = false;
				
		// /YYYY/MM/DD.aspx ?
		match = new Regex("(.*)(\\d{4})/(\\d{2})/(\\d{2}).aspx$");
		if (match.IsMatch(Request.RawUrl))
		{
			dateStr = match.Replace(Request.RawUrl, "$3-$4-$2");

			if (TryParseDateTime(dateStr, out parsedDate))
				return parsedDate;
		}
		
		// /YYYY/MM.aspx ?
		match = new Regex("(.*)(\\d{4})/(\\d{2}).aspx$");
		if (match.IsMatch(Request.RawUrl))
		{
			dateStr = match.Replace(Request.RawUrl, "$3-1-$2");

			if (TryParseDateTime(dateStr, out parsedDate))
			{
				_isUrlMonthMode = true;
				return parsedDate;
			}
		}
		// If all else fails set the cal to today.
		return DateTime.Now;
	}
	
	
	/// <summary>
	/// Attemps to parse the specified string as a DateTime.
	/// </summary>
	/// <param name="dateString">The string to parse.</param>
	/// <param name="parsedDate">The date if the string was parsed succesfully.</param>
	/// <returns>True if the string was parsed succesfully.</returns>
	private bool TryParseDateTime(string dateString, out DateTime parsedDate)
	{ 
		try
		{
			parsedDate = DateTime.Parse(dateString);
			return true;
		}
		catch (FormatException)
		{
			parsedDate = DateTime.Now;
			return false;
		}
	}
	
	
	/// <summary>
	/// Load all entries for the selected month.
	/// </summary>
	private void LoadMonthData()
	{
		_monthEntries = Cacher.GetMonth(entryCal.SelectedDate, CacheTime.Long, Context);
		if (_monthEntries == null)
		{
			Trace.Warn("DottextBlogCalendar Error: Cacher.GetMonth");
			_dateCount = 0;
		}
		else
		{
			_dateCount = _monthEntries.Count;
		}
		_currentDateIndex = _dateCount - 1;
	}
	
	
	/// <summary>
	/// As each day is rendered in the calendar, put a link if an entry exists for that day.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	void entryCal_DayRender(object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
	{
		if (_currentDateIndex >= _dateCount || _currentDateIndex < 0)
			return;
		
		DateTime entryDate = _monthEntries[_currentDateIndex].DateCreated;
		DateTime calDate = e.Day.Date;
		
		if (IsSameDay(calDate,entryDate))
		{
			e.Cell.Text = string.Format("<a href=\"{0}\">{1}</a>", CurrentBlog.UrlFormats.DayUrl(e.Day.Date), e.Day.Date.Day);
			
			// Go through the rest of the entries. (_monthEntries should always be sorted by DateCreated in descending order)
			do
			{
				_currentDateIndex--;
			} while (_currentDateIndex > -1 && IsSameDay(e.Day.Date, _monthEntries[_currentDateIndex].DateCreated));
		}		   
	}
	
	
	/// <summary>
	/// Returns true if the two dates fall on the same day.
	/// </summary>
	static bool IsSameDay(DateTime date1, DateTime date2)
	{
		return (date1.Day == date2.Day) && (date1.Month == date2.Month) && (date1.Year == date2.Year);
	}
	
	
	/// <summary>
	/// Occurs when the user clicks on the next or previous month navigation controls on the title heading.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	void entryCal_VisibleMonthChanged(object sender, System.Web.UI.WebControls.MonthChangedEventArgs e)
	{		
		//string url = CurrentBlog.UrlFormats.MonthUrl(e.NewDate);
		
		//Server.Transfer(url);
	}</script><div align="center">
<asp:calendar id="entryCal" runat="server" selectionmode="None"
	daynameformat="FirstLetter" forecolor="#FFFFFF" width="180px"  font-names="Verdana" Font-Size="8pt"
	bordercolor="#000000" cellpadding="1" ondayrender="entryCal_DayRender" onvisiblemonthchanged="entryCal_VisibleMonthChanged" BorderStyle="None">
	<TodayDayStyle ForeColor="#FFFFFF" BackColor="#666666" Font-Bold="True"></TodayDayStyle>
	<SelectorStyle BackColor="#444444"></SelectorStyle>
	<NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
	<DayHeaderStyle Font-Bold="True" BackColor="#444444"></DayHeaderStyle>
	<SelectedDayStyle Font-Bold="True" BackColor="#111111" ForeColor="#FFFFFF" BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC"></SelectedDayStyle>
	<TitleStyle Font-Bold="True"  BackColor="#333333"></TitleStyle>
	<WeekendDayStyle BackColor="#444444"></WeekendDayStyle>
	<OtherMonthDayStyle ForeColor="#AAAAAA"></OtherMonthDayStyle>
</asp:calendar></div>