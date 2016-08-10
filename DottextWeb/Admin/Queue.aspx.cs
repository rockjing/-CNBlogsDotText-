using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Dottext.Search;
using Dottext.Framework.Util;

namespace Dottext.Web
{
	/// <summary>
	/// Summary description for Queue.
	/// </summary>
	public class Queue : System.Web.UI.Page
	{
	
		private void Page_Load(object sender, System.EventArgs e)
		{
//			Literal1.Text = Dottext.Framework.Util.ManagedThreadPool.ActiveThreads.ToString();
//			Literal2.Text = Dottext.Framework.Util.ManagedThreadPool.WaitingCallbacks.ToString();

			IndexQueue que = new IndexQueue();

			//Dottext.Framework.Util.ManagedThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(que.Run));
			
//			StopWatch sw = new StopWatch();
//			IndexManager.RebuildSafeIndex();
//			Response.Write(string.Format("I took {0} milliseconds",sw.Peek()/(float)10));
			

			
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
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}

	public class IndexQueue
	{
		public IndexQueue()
		{
			string s = Dottext.Search.SearchConfiguration.Instance().PhysicalPath;
		}

		public void Run(object state)
		{
			IndexManager.RebuildSafeIndex();
		}
	}
}
