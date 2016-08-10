namespace Dottext.Web.UI.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	using Dottext.Framework;
	using Dottext.Framework.Tracking;
	using Dottext.Framework.Components;
	using Dottext.Framework.Util;
	using Dottext.Common.Data;

	/// <summary>
	///		PostRate 的摘要说明。
	/// </summary>
	public class PostRate : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.RadioButtonList rbtRate;
		protected System.Web.UI.HtmlControls.HtmlTable ScoreTable;
		protected System.Web.UI.WebControls.Literal LiteralAverage;
		protected System.Web.UI.WebControls.Literal LiteralPeople;
		protected System.Web.UI.HtmlControls.HtmlTable ScoreTable1;
		protected System.Web.UI.HtmlControls.HtmlTable ScoreTable3;
		protected System.Web.UI.WebControls.Button btnSubmit;

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.Visible=Dottext.Web.UI.Globals.CheckContorVisible("Rate");
			CreateScore();
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
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			Entry currentEntry =  Cacher.GetEntryFromRequest(Context,CacheTime.Short);
			EntryRate er=new EntryRate(currentEntry.EntryID);
			er.ClientID=Dottext.Framework.Util.Globals.GetUserIpAddress(Context);
			er.Score=int.Parse(rbtRate.SelectedValue);
			Rates.InsertRate(er);
			Response.Redirect(string.Format("{0}?Pending=true",Request.Path));
		}

		protected void CreateScore()
		{
			Entry currentEntry = Cacher.GetEntryFromRequest(Context,CacheTime.Short);
			EntryRate er=new EntryRate(currentEntry.EntryID);
			Rates.GetRateScore(er);
			if(er.RateCount==0)
			{
				ScoreTable.Visible=false;
				ScoreTable1.Visible=false;
				ScoreTable3.Visible=false;
				return;
			}
			LiteralAverage.Text=er.AverageRating.ToString();
			LiteralPeople.Text=er.RateCount.ToString();
			HtmlTableRow row1=new HtmlTableRow();
			HtmlTableRow row2=new HtmlTableRow();
			HtmlTableCell cell;
			System.Web.UI.WebControls.Image image;
			//HtmlTableCell cell1;
			for(int i=1;i<=9;i++)
			{
				cell=new HtmlTableCell();
				cell.Width="13";
				cell.Align="Center";
				cell.InnerText=i.ToString();
				row1.Cells.Add(cell);
				cell=new HtmlTableCell();
				cell.Align="Center";
				image=new System.Web.UI.WebControls.Image();
				image.Width=12;
				image.Height=(int)System.Math.Ceiling(40*(er.RatingList[i-1]/er.MaxPeople));
				image.ImageUrl="~/images/rtg_Bar.gif";
				cell.Controls.Add(image);
				row2.Cells.Add(cell);
			}
			this.ScoreTable.Rows.Add(row2);
			this.ScoreTable.Rows.Add(row1);
		}

		
	}
}
