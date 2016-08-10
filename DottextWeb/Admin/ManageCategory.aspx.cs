using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Dottext.Framework;
using Dottext.Framework.Configuration;
using Dottext.Framework.Components;
using Dottext.Framework.Data;
using System.Data.SqlClient;


namespace Dottext.Web.Admin.Pages
{
	/// <summary>
	/// ManageCategory 的摘要说明。
	/// </summary>
	public class ManageCategory : AdminPage
	{
		protected Dottext.Web.Admin.WebUI.MessagePanel Messages;
		protected System.Web.UI.HtmlControls.HtmlGenericControl detail;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel GlobalCats;
		protected System.Web.UI.WebControls.TextBox txbCategory;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Button btnDel;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected Dottext.Web.Admin.WebUI.Page PageContainer;
		private Dottext.Framework.Components.CategoryTree ct;
		private string DelNodeID;
		
		#region 常量
		private const string TEXT_MODIFY_CONFIRM="保存修改";
		private const string TEXT_MODIFY="修改";
		private const string TEXT_ADD_CONFIRM="保存添加";
		private const string TEXT_ADD="添加";
		private const string TEXT_DEL_CONFIRM="提交删除";
		protected System.Web.UI.WebControls.Button btnRename;
		protected System.Web.UI.WebControls.Button btnCategoryConfig;
		protected System.Web.UI.WebControls.Panel Panel1;
		private const string TEXT_DEL="删除";
		#endregion

		/*private void BindGlobalCategoryList()
		{
			
			//显示网站分类
			ct=new Dottext.Framework.Components.CategoryTree(-1);
			AbstractComponent rootnode=ct.Build();
			TreeViewCategory.Nodes.Clear();
			BuildCategoryTree(rootnode,TreeViewCategory.Nodes);
			TreeViewCategory.ExpandLevel=2;
				
		}*/

		/*protected void BuildCategoryTree(AbstractComponent composite,TreeNodeCollection nodes)
		{
			TreeNode n = new TreeNode();
			n.Text=((LinkCategory)composite.GetObject()).Title;
			n.ID=((LinkCategory)composite.GetObject()).CategoryID.ToString();
			if(composite.isLeaf())
			{
				n.NavigateUrl="EditSiteBlogConfig.aspx?cateid="+n.ID;
				n.Target="detail";
			}
			nodes.Add(n);
			while(composite.GoNextChild())
			{
				BuildCategoryTree(composite.GetChild(),nodes[nodes.Count-1].Nodes);
				
			}
	
		}*/


		#region Web 窗体设计器生成的代码

		protected override void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.btnAdd.Click += new System.EventHandler(this.Add_Click);
			this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			this.btnCategoryConfig.Click += new System.EventHandler(this.btnCategoryConfig_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			btnDel.Attributes.Add("onclick", "return confirm('真的要删除吗?')");
			//TreeViewCategory.
			if(!IsPostBack)
			{
				BindUIText();
				BindGlobalCategoryList();
			}
		}

		private void Add_Click(object sender, System.EventArgs e)
		{
			if(btnAdd.Text==TEXT_ADD)
			{
				//TreeNode node=new TreeNode();
				//node.Text=txbCategory.Text;
				//TreeViewCategory.GetNodeFromIndex(TreeViewCategory.SelectedNodeIndex).Nodes.Add(node);
				LinkCategory lc=new LinkCategory();
				lc.Title=txbCategory.Text;
				lc.IsActive=true;
				lc.BlogID=-1;
				lc.ParentID=int.Parse(TreeViewCategory.GetNodeFromIndex(TreeViewCategory.SelectedNodeIndex).ID);
				lc.CategoryType=CategoryType.Global;
				Links.CreateLinkCategory(lc);
				BindGlobalCategoryList();
			}
			
		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			if(btnDel.Text==TEXT_DEL)
			{
				TreeNode deleteNode=TreeViewCategory.GetNodeFromIndex(TreeViewCategory.SelectedNodeIndex);
				this.DelNodeID=deleteNode.ID;
				if(deleteNode.Nodes.Count>0)
				{
					Messages.ShowMessage("含有子节点, 不能被删除");
					return;
				}
				Links.DeleteLinkCategory(int.Parse(this.DelNodeID),-1);
				TreeViewCategory.GetNodeFromIndex(TreeViewCategory.SelectedNodeIndex).Remove();
				//btnDel.Text=TEXT_DEL_CONFIRM;
			}
			
		}

		private void btnRename_Click(object sender, System.EventArgs e)
		{
			if(btnRename.Text==TEXT_MODIFY_CONFIRM)
			{
				TreeViewCategory.GetNodeFromIndex(TreeViewCategory.SelectedNodeIndex).Text=txbCategory.Text;
				btnRename.Text=TEXT_MODIFY;
				int cateid=int.Parse(TreeViewCategory.GetNodeFromIndex(TreeViewCategory.SelectedNodeIndex).ID);
				LinkCategory lc=Links.GetLinkCategory(cateid,false,-1);
				Links.UpdateLinkCategory(lc);
				lc.Title=txbCategory.Text;
			}
			else
			{
				txbCategory.Text=TreeViewCategory.GetNodeFromIndex(TreeViewCategory.SelectedNodeIndex).Text;
				btnRename.Text=TEXT_MODIFY_CONFIRM;

			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			ct=new Dottext.Framework.Components.CategoryTree(-1);
			AbstractComponent rootnode=ct.Build();
			ct.Persistent();
			//TreeSaveToDB(TreeViewCategory.Nodes);
		}

		/*private void TreeSaveToDB(TreeNodeCollection nodes)
		{
			string delsql="delete from blog_LinkCategories where CategoryType="+CategoryType.Global;
			SqlConnection  conn=new SqlConnection(Config.Settings.BlogProviders.DbProvider.ConnectionString);
			SqlTransaction trans=conn.BeginTransaction();
			SqlHelper.ExecuteNonQuery(trans,delsql);
			
			for(int i=0;i<nodes.Count;i++)
			{
				if(nodes[i].ID!=null&&nodes[i].ID!="")
				{
					LinkCategory lc=Links.GetLinkCategory(int.Parse(nodes[i].ID),false);
					lc.Title=nodes[i].Text;
					Links.UpdateLinkCategory(lc);
					//Response.Write(nodes[i].ID+"<br>");
				}
				//BusinessFacade.Facade.instance().WriteDB(sql);
				TreeSaveToDB(nodes[i].Nodes);
			}
					
		}*/

		private void BindUIText()
		{
			btnAdd.Text=TEXT_ADD;
			btnRename.Text=TEXT_MODIFY;
			btnDel.Text=TEXT_DEL;
		}

		private void btnCategoryConfig_Click(object sender, System.EventArgs e)
		{
		
		}

		
	}
}