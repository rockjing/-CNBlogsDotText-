using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Dottext.Framework.Configuration;

namespace Dottext.Web.Admin.Pages
{
	/// <summary>
	/// ManageRoles ��ժҪ˵����
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

			ddlModuleList.Items.Insert(0, "��ѡ�񡭡�");
			

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
				Messages.ShowMessage("���û�������!");
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

		#region Web ������������ɵĴ���

		protected override void OnInit(EventArgs e)
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
			foreach(Control con in e.Item.Controls)//�õ�ÿ���ؼ�
			{
				if(con is LinkButton)//���ÿ���ؼ�,���Ƿ���DataGridLinkButton
					//��ֵ�����System.Web.UI.WebControls��û������࣬����ͨ��Response.Write(con.ToString())���ֵ�
				{
					LinkButton lb=(LinkButton)con;
					if(lb.CommandName=="Delete")
					{
						lb.Attributes.Add("onclick", "return confirm('�����Ҫɾ����')");
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