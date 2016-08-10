using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Globalization;
using Dottext.Framework.Components;
using Dottext.Framework.Util;
using Dottext.Framework.Data;
using Dottext.Framework.Configuration;
using Dottext.Common.Data;
using Dottext.Framework;

namespace Dottext.Web.UI.Controls
{
	/// <summary>
	/// Calendar 的摘要说明。
	/// </summary>
	public class Calendar : Dottext.Web.UI.Controls.BaseControl
	{
		protected Dottext.Web.UI.Controls.EntryList Days;
		protected System.Web.UI.WebControls.Calendar entryCal;
		protected int EntryCount;
		protected DateTime selDate;
		protected EntryCollection entries;
		private System.Threading.Thread t;
		private CultureInfo oldCulture;
		private string fileExt=Config.Settings.UrlFormat;

		protected override void OnLoad(EventArgs e)
		{
			this.Visible=Globals.CheckContorVisible("Calendar");
			if(!Visible)
			{
				return;
			}
			base.OnLoad (e);
			if(!IsPostBack)
			{
				if(!(CheckDay()||CheckDayCollection()||CheckMonth()))
				{
				this.selDate=DateTime.Now;
				}
				LoadMonthData();
				
				//entryCal.DayNameFormat=DayNameFormat.
							
			}
		
			
		}

		protected bool CheckDay()
		{
			Regex DayRegex = new Regex(@"/archive/\d{4}/\d{2}/\d{2}/\d+\."+fileExt+"$",RegexOptions.IgnoreCase);
			if(DayRegex.IsMatch(Request.Path))
			{
				string urlstr=Regex.Replace(Request.Path,string.Format(@"(/\d+\.{0})$",fileExt),"."+fileExt,RegexOptions.IgnoreCase);
				this.selDate = WebPathStripper.GetDateFromRequest(urlstr,"archive");
				entryCal.VisibleDate=this.selDate;
				return true;
			}
			return false;

		}

		protected bool CheckDayCollection()///archive/\d{4}/\d{1,2}/\d{1,2}\.aspx$  /archive/\d{4}/\d{1,2}/\d{1,2}/\d+\.aspx$
		{
			Regex DayRegex = new Regex(@"/archive/\d{4}/\d{1,2}/\d{1,2}\."+fileExt+"$",RegexOptions.IgnoreCase);
			if(DayRegex.IsMatch(Request.Path))
			{
				this.selDate = WebPathStripper.GetDateFromRequest(Request.Path,"archive");
				entryCal.VisibleDate=this.selDate;
				return true;
			}
			return false;

		}

		protected bool CheckMonth()
		{
			
			Regex MonthRegex=new Regex(@"/archive/\d{4}/(\d{1,2})+\."+fileExt+"$",RegexOptions.IgnoreCase);
			if(MonthRegex.IsMatch(Request.Path))
			{
				this.selDate = WebPathStripper.GetDateFromRequest(Request.Path,"archive");
				entryCal.VisibleDate=this.selDate;
				return true;
			}
			return false;

		}

		protected void LoadMonthData()
		{
			string timestr=this.selDate.ToString("yyyy-MM-01 12:00");
			DateTime dt=DateTime.Parse(timestr);
			EntryQuery query = new EntryQuery(PostConfig.IsActive,PostType.BlogPost);
			query.StartDate =dt;
			query.EndDate = dt.AddMonths(1);
			entries =  Entries.GetEntryCollection(query);
			EntryCount=entries.Count;	

		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
			
		}

		
		
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.entryCal.DayRender += new System.Web.UI.WebControls.DayRenderEventHandler(this.dayRender);
			this.entryCal.VisibleMonthChanged += new System.Web.UI.WebControls.MonthChangedEventHandler(this.monthChanged);
			this.entryCal.PreRender += new System.EventHandler(this.entryCal_PreRender);
			//this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dayRender(object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
		{
			t.CurrentCulture=this.oldCulture; 
			string lnkstr="";
			for(int i=0;i<this.EntryCount;i++)
			{
				if(entries[i].DateCreated.Date==e.Day.Date)
				{
					lnkstr=Regex.Replace(entries[i].TitleUrl,string.Format(@"(/\d+\.{0})$",fileExt),"."+fileExt,RegexOptions.IgnoreCase);
					e.Cell.Text = "<a href=\"" +lnkstr+"\"><u>" + e.Day.Date.Day + "</u></a>";
				}

			}
			
			
		}

		private void monthChanged(object sender, System.Web.UI.WebControls.MonthChangedEventArgs e)
		{
			selDate = e.NewDate.Date;

			LoadMonthData();
		}

		private void entryCal_PreRender(object sender, System.EventArgs e)
		{
			t=System.Threading.Thread.CurrentThread; 
			oldCulture=t.CurrentCulture; 
			CultureInfo newci=(CultureInfo)oldCulture.Clone(); 
			newci.DateTimeFormat.DayNames=new string[]{"日","一","二","三","四","五","六"}; 
			newci.DateTimeFormat.FirstDayOfWeek=DayOfWeek.Sunday; 
			t.CurrentCulture=newci;
		
		}
	}
}
