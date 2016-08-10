namespace Dottext.Web.AggSite
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	using System.Globalization;
	using Dottext.Framework.Components;
	using Dottext.Framework.Util;
	using Dottext.Framework.Data;
	using Dottext.Framework.Configuration;
	using Dottext.Common.Data;
	using Dottext.Framework;


	/// <summary>
	///		Calendar 的摘要说明。
	/// </summary>
	public class Calendar : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Calendar entryCal;
		protected int EntryCount;
		protected DateTime selDate=DateTime.Now;
		protected EntryCollection entries;
		private System.Threading.Thread t;
		private CultureInfo oldCulture;
		protected System.Web.UI.WebControls.Literal CalTitle;
		private static readonly string[] dateFormats = {"yyyy'/'MM'/'d","yyyy'/'MM'/'dd","yyyy'/'M'/'dd","yyyy'/'M'/'d","yyyy'/'MM","yyyy'/'M"};

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				if(!(CheckDay()||CheckMonth()))
				{
					this.selDate=DateTime.Now;
				}
				LoadMonthData();										
			}
		}

		protected bool CheckDay()
		{
			if(null != Request.QueryString["date"])
			{
				string datestr=Request.QueryString["date"];
				string[] dateFormat ={"yyyy'/'MM'/'dd"};
				//Response.Write(datestr);
				this.selDate=DateTime.ParseExact(datestr,dateFormat,CultureInfo.CurrentCulture,DateTimeStyles.None);
				entryCal.VisibleDate=this.selDate;
				return true;
			}
			return false;

		}

		protected bool CheckMonth()
		{
			if(null != Request.QueryString["date"])
			{
				string datestr=Request.QueryString["date"];
				string[] dateFormat ={"yyyy'/'MM"};
				this.selDate=DateTime.ParseExact(datestr,dateFormat,CultureInfo.CurrentCulture,DateTimeStyles.None);
				entryCal.VisibleDate=this.selDate;
				return true;
			}
			return false;

		}

		protected void LoadMonthData()
		{
			
			string timestr=this.selDate.ToString("yyyy-MM-01 00:00");
			DateTime dt=DateTime.Parse(timestr);
			EntryQuery query = new EntryQuery();
			query.PostConfig=PostConfig.IsAggregated|PostConfig.IsActive;
			query.PostType=PostType.BlogPost;
			/*if(Request.QueryString["cateid"]=="-2")
			{
				query.PostConfig=PostConfig.IsActive;
				query.PostType=PostType.Comment;
			}*/
			query.StartDate =dt;
			query.EndDate = dt.AddMonths(1);
			//string cateID=UI.UIData.GetSiteCatalogData(Request,"CategoryID");
			/*Dottext.Framework.Components.LinkCategory lc=UI.UIData.GetSiteCategory(Request);
			if(lc!=null)
			{
				query.CategoryID=lc.CategoryID;//int.Parse(cateID);
			}*/
			query=Dottext.Framework.Util.Globals.BuildEntryQuery(query,Config.CurrentBlog(Context));
			entries =  Entries.GetEntryCollection(query);
			EntryCount=entries.Count;
			CalTitle.Text=Config.CurrentBlog(Context).Title;
			
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		设计器支持所需的方法 - 不要使用代码编辑器
		///		修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.entryCal.DayRender += new System.Web.UI.WebControls.DayRenderEventHandler(this.entryCal_DayRender);
			this.entryCal.VisibleMonthChanged += new System.Web.UI.WebControls.MonthChangedEventHandler(this.entryCal_VisibleMonthChanged);
			this.entryCal.SelectionChanged += new System.EventHandler(this.entryCal_SelectionChanged);
			this.entryCal.PreRender += new System.EventHandler(this.entryCal_PreRender);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void entryCal_DayRender(object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
		{
			int count=0;
			t.CurrentCulture=this.oldCulture; 
			string lnkstr="";
			for(int i=0;i<this.EntryCount;i++)
			{
				if(entries[i].DateCreated.Date==e.Day.Date)
				{
					count++;
				}
			}
			if(count>0)
			{
				lnkstr=Dottext.Framework.Util.Globals.RemoveParamFromUrl(Request.RawUrl,"page");
				lnkstr=Dottext.Framework.Util.Globals.AddParamToUrl(lnkstr,"date",e.Day.Date.ToString("yyyy'/'MM'/'dd"));
				//lnkstr=lnkstr+"date="+e.Day.Date.ToString("yyyy'/'MM'/'dd");//Regex.Replace(entries[i].TitleUrl,@"(/\d+\.aspx)$",".aspx",RegexOptions.IgnoreCase);
				e.Cell.Text = string.Format("<a href=\"" +lnkstr+"\" title=\"{1}\"><u>{0}</u></a><br>",e.Day.Date.Day,count.ToString());
			}
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

		private void entryCal_VisibleMonthChanged(object sender, System.Web.UI.WebControls.MonthChangedEventArgs e)
		{
			
			this.selDate = e.NewDate.Date;
			LoadMonthData();
		}

		private void entryCal_SelectionChanged(object sender, System.EventArgs e)
		{
			
		}
	}
}
