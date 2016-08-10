using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Dottext.Framework.Configuration;

namespace Dottext.Web.Admin.Pages
{
	/// <summary>
	/// ManageRoles 的摘要说明。
	/// </summary>
	public class ManageRoles : ManagePage
	{
		protected DropDownList ddlModuleList;
		protected Repeater rptRoleUsers;
		protected TextBox tbUserName;
		protected Button btnAddUserToRole;
		protected Dottext.Web.Admin.WebUI.MessagePanel Messages;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel RolesGroup;
		protected Dottext.Web.Admin.WebUI.AdvancedPanel Roles;	
		protected Dottext.Web.Admin.WebUI.Page PageContainer;

		private void Page_Load(object sender, EventArgs e)
		{
			
			PageContainer.TabSectionID="ManageSite";
			if (!IsPostBack)
			{
				bindRoleList();								
				
			}

			buildLocalUI();
			
		}

		private void showMessage(string MessageText)
		{
			Messages.ShowMessage(MessageText);
		}

		private void bindRoleList()
		{
			Dottext.Framework.Components.Role[] roles=Dottext.Framework.Roles.GetRoles(-1);
			ddlModuleList.DataSource = roles;
			ddlModuleList.DataTextField = "Name";
			ddlModuleList.DataValueField = "RoleId";

			ddlModuleList.DataBind();

			ddlModuleList.Items.Insert(0, "请选择……");
			

		}

		private void showRoleUser(int ModuleId)
		{
			rptRoleUsers.DataSource = Config.GetConfigByRoleID(ModuleId);
			rptRoleUsers.DataBind();
			Roles.Visible=true;
		}

		private void addRoleUser(int RoleId, string UserName)
		{
			BlogConfig config = Config.GetConfig(UserName);
			if(config!=null)
			{
				Dottext.Framework.Roles.AddUserToRole(config.BlogID,RoleId);
			}
			else
			{
				Messages.ShowMessage("该用户不存在!");
			}
		}

		private void deleteRoleUser(int UserId,int RoleId)
		{
			Dottext.Framework.Roles.RemoveUserFromRole(UserId,RoleId);
		}


		private void setUpdateButtonValid(bool IsValid)
		{
			btnAddUserToRole.Enabled = IsValid;
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
			this.ddlModuleList.SelectedIndexChanged += new System.EventHandler(this.ddlModuleList_SelectedIndexChanged);
			this.rptRoleUsers.ItemCreated += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rptRoleUsers_ItemCreated);
			this.rptRoleUsers.ItemCommand += new System.Web.UI.WebControls.RepeaterCommandEventHandler(this.rptRoleUsers_ItemCommand);
			this.btnAddUserToRole.Click += new System.EventHandler(this.btnAddUserToRole_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}

		#endregion

		

			
		private void buildLocalUI()
		{
			DataTable dt = null;//Helper.getUserRoleModules(Context.User.Identity.Name);

			if (dt != null)
			{
				if (dt.Rows.Count > 0)
				{
					for (int i = 0; i < dt.Rows.Count; i++)
					{						
						HyperLink hl=Utilities.CreateHyperLink(dt.Rows[i]["ModuleName"].ToString(), dt.Rows[i]["ModuleFile"].ToString());
						PageContainer.AddToActions(hl);
					}
				}
			}

		}

		private void btnAddUserToRole_Click(object sender, System.EventArgs e)
		{
			if (ddlModuleList.SelectedIndex > 0)
			{
				string UserName = tbUserName.Text;
				int RoleId = Convert.ToInt32(ddlModuleList.SelectedValue);

				addRoleUser(RoleId, UserName);

				tbUserName.Text = "";

				showRoleUser(RoleId);
			}
		}

		private void rptRoleUsers_ItemCreated(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			foreach(Control con in e.Item.Controls)//得到每个控件
			{
				if(con is LinkButton)//检查每个控件,看是否是DataGridLinkButton
					//奇怪的是在System.Web.UI.WebControls中没有这个类，我是通过Response.Write(con.ToString())发现的
				{
					LinkButton lb=(LinkButton)con;
					if(lb.CommandName=="Delete")
					{
						lb.Attributes.Add("onclick", "return confirm('您真的要删除吗？')");
					}
				}
			}
		}

		private void rptRoleUsers_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{
			if (ddlModuleList.SelectedIndex > 0)
			{
				int UserId = Convert.ToInt32(e.CommandArgument);
				int RoleId = Convert.ToInt32(ddlModuleList.SelectedValue);

				switch (e.CommandName.ToLower())
				{
					case "delete":
						this.deleteRoleUser(UserId,RoleId);
						this.showRoleUser(RoleId);
						break;
					default:
						break;
				}
			}
		}

		private void ddlModuleList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Dottext.Framework.Logger.LogManager.Log("test","test");
			if (ddlModuleList.SelectedIndex > 0)
			{
				showRoleUser(Convert.ToInt32(ddlModuleList.SelectedValue));
				setUpdateButtonValid(true);
			}
			else
			{
				setUpdateButtonValid(false);
			}

		}

		
	}
}