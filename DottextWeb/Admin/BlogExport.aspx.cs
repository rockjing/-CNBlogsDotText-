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

using System.Xml;
using System.Data.SqlClient;
using Dottext.Framework.Data;

namespace Dottext.Web.Admin.Pages
{
	/// <summary>
	/// BlogExport ��ժҪ˵����
	/// </summary>
	public class BlogExport : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			Export();
		}

		protected void Export()
		{
			SqlParameter[] p = 
			{
				SqlHelper.MakeInParam("@BlogID",SqlDbType.Int,4,Dottext.Framework.Configuration.Config.CurrentBlog().BlogID)
			};
			SqlConnection conn=new SqlConnection(Dottext.Framework.Providers.DbProvider.Instance().ConnectionString);
			XmlReader reader=null;
			try
			{
				reader= SqlHelper.ExecuteXmlReader(conn,CommandType.StoredProcedure,"blog_Export",p);
			}
			finally
			{
				//conn.Close();
			}
			
			/*ds.DataSetName="BlogData";
			ds.Tables[0].TableName="blog_Config";
			ds.Tables[1].TableName="blog_Content";
			ds.Tables[2].TableName="blog_EntryViewCount";
			ds.Tables[3].TableName="blog_Images";
			ds.Tables[4].TableName="blog_KeyWords";
			ds.Tables[5].TableName="blog_LinkCategories";
			ds.Tables[6].TableName="blog_Links";
			ds.Tables[7].TableName="blog_Referrals";
			ds.Tables[8].TableName="blog_URLs";*/
			Response.Clear();
			Response.ContentEncoding = System.Text.Encoding.UTF8;//.GetEncoding("gb2312");
			Response.AppendHeader("Content-Disposition","attachment; filename=MyBlogData.xml");
			//Response.AppendHeader("Content-Length","1000");//dataStr.Length.ToString());
			Response.ContentType = "application/octet-stream";
			
			XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Response.ContentEncoding);
			writer.Formatting=Formatting.Indented;
			try
			{
				writer.WriteStartDocument();
				writer.WriteStartElement("CnblogsData","");
				while(!reader.EOF)
				{
					reader.MoveToContent();
					writer.WriteNode(reader,false);
				}
				writer.WriteEndElement();
				writer.Flush();
			}
			finally
			{
				reader.Close();
				writer.Close();
				conn.Close();
				Response.End();
			}
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
