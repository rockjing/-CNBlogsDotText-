using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Dottext.Framework.Configuration;
using Dottext.Framework.Components;
using Dottext.Framework;
using Dottext.Web.Admin.WebUI;
using Dottext.Web.Admin.UserControls;

namespace Dottext.Web.Admin.Pages
{
	/// <summary>
	/// ManageCategory 的摘要说明。
	/// </summary>
	public class ManageGlobalCategory : ManagePage
	{
		protected Dottext.Web.Admin.WebUI.MessagePanel Messages;
		protected System.Web.UI.WebControls.Repeater CategoryLevel2;
		protected System.Web.UI.WebControls.DataGrid CategoryLevel1;
		protected System.Web.UI.WebControls.TextBox txbCategory1;
		protected System.Web.UI.WebControls.Button btnCategory1;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel GlobalCategoryPanel;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.CheckBox ckbNewIsActive;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel apAddCategoryLevel1;
		protected System.Web.UI.WebControls.RequiredFieldValidator valtxbNewTitleRequired;
		protected System.Web.UI.WebControls.HyperLink lnkConfig;
		protected Dottext.Web.Admin.WebUI.Page PageContainer;

		
		private void BindGlobalCategoryList1()
		{
          	CategoryLevel1.DataSource=GetGlobalCategory(-1);
			CategoryLevel1.DataKeyField = "CategoryID";
			CategoryLevel1.DataBind();
			
		}

		private void BindGlobalCategoryList2(DataGrid dg,int ParentID)
		{
			LinkCategoryCollection lcc=GetGlobalCategory(ParentID);
			if(lcc!=null)
			{
				dg.DataSource=lcc;
				dg.DataKeyField = "CategoryID";
				dg.DataBind();
			}
			
			
		}
		
		protected LinkCategoryCollection GetGlobalCategory(int ParentID)
		{
			return Links.GetCategoriesByParentID(CategoryType.Global,ParentID,false);
		}

		private void BuildCategoryList(AbstractComponent node)
		{
			
			if(!node.isRoot()&&!node.isLeaf())
			{
				AdvancedPanel ap=new AdvancedPanel();
				
				ap.ID="AdvancedPanel"+((LinkCategory)node.GetObject()).CategoryID.ToString();
				ap.HeaderText=((LinkCategory)node.GetObject()).Title;
				ap.Collapsed=false;
				ap.Collapsible=true;
				ap.LinkStyle=CollapseLinkStyle.Image;
				ap.LinkBeforeHeader=true;
				ap.DisplayHeader=true;
				ap.LinkText="[toggle]";
				ap.BodyCssClass="Edit";
				ap.HeaderCssClass="CategoryHeader";
				ap.HeaderTextCssClass="CategoryHeader";
				LinkCategoryCollection lcc=new LinkCategoryCollection();
				while(node.GoNextChild())
				{
					AbstractComponent child=node.GetChild();
					if(child.isLeaf())
					{
						lcc.Add((LinkCategory)child.GetObject());
					}
				}
				if(lcc!=null)
				{
						
					if(Config.Settings.GlobalCategorySingleSelect)
					{
						RadioButtonList rbl=new RadioButtonList();
						rbl.ID=((LinkCategory)node.GetObject()).CategoryID.ToString();
						rbl.RepeatDirection=RepeatDirection.Horizontal;
						rbl.RepeatColumns=4;
						rbl.Width=new Unit("98%");
						rbl.DataTextField="Title";
						rbl.DataValueField="CategoryID";
						rbl.DataSource=lcc;
						rbl.DataBind();
						ap.Controls.Add(rbl);
					}
					else
					{
						CheckBoxList cbl=new CheckBoxList();
						cbl.ID=((LinkCategory)node.GetObject()).CategoryID.ToString();
						cbl.RepeatDirection=RepeatDirection.Horizontal;
						cbl.RepeatColumns=4;
						cbl.Width=new Unit("98%");
						cbl.DataTextField="Title";
						cbl.DataValueField="CategoryID";
						cbl.DataSource=lcc;
						cbl.DataBind();
						ap.Controls.Add(cbl);
					}
				}
				GlobalCategoryPanel.Controls.Add(ap);
				
			}
			else
			{
				while(node.GoNextChild())
				{
					BuildCategoryList(node.GetChild());
				}
			}

		}
		

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
			this.btnCategory1.Click += new System.EventHandler(this.btnCategory1_Click);
			this.CategoryLevel1.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.CategoryLevel1_ItemCreated);
			this.CategoryLevel1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.CategoryLevel1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				BindGlobalCategoryList1();
			}
		}

		private void btnCategory1_Click(object sender, System.EventArgs e)
		{
			LinkCategory lc=new LinkCategory();
			lc.Title=txbCategory1.Text;
			lc.IsActive=ckbNewIsActive.Checked;
			lc.BlogID=-1;
			lc.ParentID=-1;
			lc.CategoryType=CategoryType.Global;
			Links.CreateLinkCategory(lc);
			txbCategory1.Text="";
			//BindGlobalCategoryList1();
			Response.Redirect(Request.RawUrl);
		}

		protected void btnCrecteNewCategory2_Click(object sender, System.EventArgs e)
		{
			LinkButton b = (LinkButton) sender;
			TextBox t = (TextBox) b.Parent.FindControl("Category2Name");
			LinkCategory lc=new LinkCategory();
			lc.Title=t.Text;
			lc.IsActive=true;
			lc.BlogID=-1;
			lc.ParentID=int.Parse(b.CommandArgument);
			lc.CategoryType=CategoryType.Global;
			Links.CreateLinkCategory(lc);
			txbCategory1.Text="";
			Response.Redirect(Request.RawUrl);
		}

		private void CategoryLevel1_ItemCreated(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			foreach(Control con in e.Item.Controls)//得到每个控件
			{
				if(con is LinkButton)
				{
					LinkButton lb=(LinkButton)con;
					if(lb.CommandName=="Delete")
					{
						lb.Attributes.Add("onclick", "return confirm('您真的要删除吗？')");
					}
				}
			}
		}

		private void CategoryLevel1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			Control con1 =((Control)sender);
			Control con2=e.Item.FindControl("CategoryLevel2");
			if(con2!=null && Config.Settings.CategoryDepth==1)
			{
				con2.Visible=false;
			}
			if(con1 is DataGrid && con2!=null &&con2.Visible)
			{
				int ParentID = Convert.ToInt32(((DataGrid)con1).DataKeys[e.Item.ItemIndex]);
				DataGrid dg2=((DataGrid)con2);
				/*dg2.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgrCategories_CancelCommand);
				dg2.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgrCategories2_EditCommand);
				dg2.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgrCategories_UpdateCommand);
				dg2.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgrCategories_DeleteCommand);
				*/
				dg2.DataSource=GetGlobalCategory(ParentID);
				dg2.DataBind();
			}
		}

		

		/*protected void CategoryLevel1_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{
			switch (e.CommandName.ToLower())
			{
				case "delete":
					Links.DeleteLinkCategory(Convert.ToInt32(e.CommandArgument),-1);
					Response.Redirect(Request.RawUrl);
					break;
				default:
					break;
			}
			
		}

		protected void CategoryLevel2_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{
			switch (e.CommandName.ToLower())
			{
				case "delete":
					Links.DeleteLinkCategory(Convert.ToInt32(e.CommandArgument),-1);
					Response.Redirect(Request.RawUrl);
					break;
				default:
					break;
			}
			
		}*/

		protected void dgrCategories_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Control con =((Control)source);
			if(con is DataGrid)
			{
				((DataGrid)con).EditItemIndex = e.Item.ItemIndex;
				BindGlobalCategoryList1();
				this.Messages.Clear();
				ToggleAddNew(false);
			}
		}

		protected void dgrCategories2_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Control con =((Control)source);
			if(con is DataGrid)
			{
				((DataGrid)con).EditItemIndex = e.Item.ItemIndex;
				Control con2 = e.Item.FindControl("lbParentID");
				if(con2!=null)
				{
					BindGlobalCategoryList2((DataGrid)con,Convert.ToInt32(((Label)con2).Text));
					this.Messages.Clear();
					ToggleAddNew(false);
				}
			}
		}

		protected void dgrCategories_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{	
			TextBox title = e.Item.FindControl("txbTitle") as TextBox;
			CheckBox isActive = e.Item.FindControl("ckbIsActive") as CheckBox;
			
			if (null == title || null == isActive)
				throw new ApplicationException("Update failed, could not located either the item Title or IsActive");			

			if (Page.IsValid)
			{
				if (Utilities.IsNullorEmpty(title.Text))
				{
					Messages.ShowError("You cannot have a category with a blank description");
					return;
				}

				int id = Convert.ToInt32(CategoryLevel1.DataKeys[e.Item.ItemIndex]);
				
				LinkCategory existingCategory = Links.GetLinkCategory(id,false);
				existingCategory.Title = title.Text;
				existingCategory.IsActive = isActive.Checked;
				existingCategory.BlogID=-1;
				
		
				if (id != 0) 
					PersistCategory(existingCategory);
				CategoryLevel1.EditItemIndex = -1;
				//Response.Redirect(Request.RawUrl);
				BindGlobalCategoryList1();
				ToggleAddNew(true);
			}
		}
		
		protected void dgrCategories2_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{	
			Control con =((Control)source);
			if(con is DataGrid)
			{
				DataGrid dgCategory2=(DataGrid)con;
				TextBox title = e.Item.FindControl("txbTitle2") as TextBox;
				CheckBox isActive = e.Item.FindControl("ckbIsActive2") as CheckBox;
			
				if (null == title || null == isActive)
					throw new ApplicationException("Update failed, could not located either the item Title or IsActive");			

				if (Page.IsValid)
				{
					if (Utilities.IsNullorEmpty(title.Text))
					{
						Messages.ShowError("You cannot have a category with a blank description");
						return;
					}

					int id = Convert.ToInt32(dgCategory2.DataKeys[e.Item.ItemIndex]);
				
					LinkCategory existingCategory = Links.GetLinkCategory(id,false);
					existingCategory.Title = title.Text;
					existingCategory.IsActive = isActive.Checked;
					existingCategory.BlogID=-1;
				
		
					if (id != 0) 
						PersistCategory(existingCategory);
				
					dgCategory2.EditItemIndex = -1;
					BindGlobalCategoryList2(dgCategory2,existingCategory.ParentID);
					ToggleAddNew(true);
				}
				
				//Response.Redirect(Request.RawUrl);
				//BindGlobalCategoryList1();
				//ToggleAddNew(true);
			}
		}


		protected void dgrCategories_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Control con =((Control)source);
			if(con is DataGrid)
			{
				int id = Convert.ToInt32(((DataGrid)con).DataKeys[e.Item.ItemIndex]);
				LinkCategory lc = Links.GetLinkCategory(id,false);
				ConfirmDelete(id, lc.Title);
			}
		}

		protected void dgrCategories_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Control con =((Control)source);
			if(con is DataGrid)
			{
				((DataGrid)con).EditItemIndex = -1;
				Response.Redirect(Request.RawUrl);
			}
			
		}

		protected void PersistCategory(LinkCategory category)
		{
			try
			{
				if (category.CategoryID > 0)
				{
					Links.UpdateLinkCategory(category);
					this.Messages.ShowMessage(String.Format("Category \"{0}\" was updated.", category.Title));
				}
				else
				{
					category.CategoryID = Links.CreateLinkCategory(category);
					this.Messages.ShowMessage(String.Format("Category \"{0}\" was added.", category.Title));
				}					
			}
			catch(Exception ex)
			{
				this.Messages.ShowError(String.Format(Constants.RES_EXCEPTION, "TODO...", ex.Message));
			}
		}

		private void ConfirmDelete(int categoryID, string categoryTitle)
		{
			this.Command = new DeleteCategoryCommand(categoryID, categoryTitle,-1);
			this.Command.RedirectUrl = Request.Url.ToString();
			this.Command.TabSectionID=this.PageContainer.TabSectionID;
			Server.Transfer(Constants.URL_CONFIRM);
		}

		private void ToggleAddNew(bool showAddNew)
		{
			apAddCategoryLevel1.Visible = showAddNew;
			valtxbNewTitleRequired.Enabled = showAddNew;
		}

		private void CategoryLevel1_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			

		}
		
	}
}