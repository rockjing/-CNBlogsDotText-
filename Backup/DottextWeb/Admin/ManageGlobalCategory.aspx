<%@ Page language="c#" Codebehind="ManageGlobalCategory.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.ManageGlobalCategory" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<ANW:PAGE id="PageContainer" TabSectionID="ManageSite" runat="server">
	<ANW:MessagePanel id="Messages" runat="server"></ANW:MessagePanel>
	<ANW:AdvancedPanel id="GlobalCategoryPanel" runat="server" HeaderText="网站分类管理<a href=ManageGlobalCategory.aspx>#</a>"
		Collapsible="true" HeaderCssClass="CollapsibleHeader" LinkStyle="Image" LinkBeforeHeader="True"
		DisplayHeader="true">
		<ANW:AdvancedPanel id="apAddCategoryLevel1" runat="server" HeaderText="添加一级分类" Collapsible="False"
			HeaderCssClass="CollapsibleTitle" DisplayHeader="true" BodyCssClass="Edit">
<asp:TextBox id="txbCategory1" runat="server" Width="300"></asp:TextBox>
<asp:CheckBox id="ckbNewIsActive" runat="server" Text="Visible" Checked="true"></asp:CheckBox>&nbsp; 
<asp:Button id="btnCategory1" runat="server" Width="90" Text="添加"></asp:Button>
<asp:RequiredFieldValidator id="valtxbNewTitleRequired" runat="server" ErrorMessage="分类名称不能为空" ControlToValidate="txbCategory1"></asp:RequiredFieldValidator></ANW:AdvancedPanel>
		<asp:DataGrid id="CategoryLevel1" runat="server" CssClass="Listing" OnDeleteCommand="dgrCategories_DeleteCommand"
			OnUpdateCommand="dgrCategories_UpdateCommand" OnEditCommand="dgrCategories_EditCommand" OnCancelCommand="dgrCategories_CancelCommand"
			GridLines="None" AutoGenerateColumns="False">
			<AlternatingItemStyle CssClass="Alt"></AlternatingItemStyle>
			<HeaderStyle CssClass="Header"></HeaderStyle>
			<Columns>
				<asp:TemplateColumn HeaderText="Category">
					<ItemTemplate>
						<%# (Container.ItemIndex+1)+"."%>
						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Title") %>' ID="Label1">
						</asp:Label>
						&nbsp;
						<asp:HyperLink id="lnkConfig" runat="server" NavigateUrl='<%# Dottext.Framework.Configuration.Config.CurrentBlog().FullyQualifiedUrl+"admin/EditSiteBlogConfig.aspx?cateid="+DataBinder.Eval(Container, "DataItem.CategoryID",null) %>'>Config</asp:HyperLink>
						<!-- 二级分类 -->
						<br>
						<asp:TextBox id="Category2Name" runat="server" style="width:100px;border: 1px solid #6B86B3;" Visible='<%# Dottext.Framework.Configuration.Config.Settings.CategoryDepth==2 %>'></asp:TextBox>
							<asp:LinkButton id="btnCrecteNewCategory2" CausesValidation="False" runat="server" Text="添加二级分类"
								style="width:90px;" OnClick="btnCrecteNewCategory2_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CategoryID") %>' Visible='<%# Dottext.Framework.Configuration.Config.Settings.CategoryDepth==2 %>'></asp:LinkButton>
						<asp:DataGrid id="CategoryLevel2" runat="server" CssClass="Listing2" GridLines="None" AutoGenerateColumns="False"
							ShowHeader="False" Width="100%" DataKeyField="CategoryID" OnCancelCommand="dgrCategories_CancelCommand"
							OnEditCommand="dgrCategories2_EditCommand" OnUpdateCommand="dgrCategories2_UpdateCommand"
							OnDeleteCommand="dgrCategories_DeleteCommand">
							<Columns>
								<asp:TemplateColumn>
									<ItemTemplate>
										<%# (((DataGridItem)(Container.Parent.Parent.Parent.Parent)).ItemIndex+1)+"."+(Container.ItemIndex+1)%>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Title") %>' ID="Label4">
										</asp:Label>
										&nbsp;
										<asp:HyperLink id="Hyperlink1" runat="server" NavigateUrl='<%# Dottext.Framework.Configuration.Config.CurrentBlog().FullyQualifiedUrl+"admin/EditSiteBlogConfig.aspx?cateid="+DataBinder.Eval(Container, "DataItem.CategoryID",null) %>'>Config</asp:HyperLink>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ParentID") %>' ID="lbParentID" Visible="false">
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										
										Title<br>
										<asp:TextBox width = "350" id="txbTitle2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsActive") %>' ID="Label6">
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:CheckBox id="ckbIsActive2" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.IsActive") %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
								<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
						</asp:DataGrid>
						<!-- 二级分类结束 -->
					</ItemTemplate>
					<EditItemTemplate>
						Title<br>
						<asp:TextBox width = "350" id="txbTitle" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
						</asp:TextBox>
					</EditItemTemplate>
				</asp:TemplateColumn>
				<asp:TemplateColumn HeaderText="Visible">
					<ItemTemplate>
						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsActive") %>' ID="Label3">
						</asp:Label>
					</ItemTemplate>
					<EditItemTemplate>
						<asp:CheckBox id="ckbIsActive" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.IsActive") %>'/>
					</EditItemTemplate>
				</asp:TemplateColumn>
				<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
				<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
				
			</Columns>
		</asp:DataGrid>
		
	</ANW:AdvancedPanel>
</ANW:PAGE>
