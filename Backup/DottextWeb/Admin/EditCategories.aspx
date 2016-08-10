<%@ Page language="c#" Codebehind="EditCategories.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.EditCategories" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<ANW:PAGE id="PageContainer" runat="server" TabSectionID="Posts">
	<ANW:MessagePanel id="Messages" runat="server"></ANW:MessagePanel>
	<ANW:AdvancedPanel id="Edit" runat="server" Collapsible="False" HeaderText="Edit Categories" HeaderCssClass="CollapsibleHeader"
		DisplayHeader="true">
		<asp:DataGrid id="dgrItems" runat="server" AutoGenerateColumns="False" GridLines="None" CssClass="Listing">
			<AlternatingItemStyle CssClass="Alt"></AlternatingItemStyle>
			<HeaderStyle CssClass="Header"></HeaderStyle>
			<Columns>
				<asp:TemplateColumn HeaderText="Category">
					<ItemTemplate>
						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
						</asp:Label>
						<br>
						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>' ID="Label2" NAME="Label1">
						</asp:Label>
					</ItemTemplate>
					<EditItemTemplate>
						Title<br>
						<asp:TextBox width = "350" id="txbTitle" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
						</asp:TextBox>
						<br>Description<br>
						<asp:TextBox width = "350" rows="5" textmode="MultiLine" id="txbDescription" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'>
						</asp:TextBox>
					</EditItemTemplate>
				</asp:TemplateColumn>
				<asp:TemplateColumn HeaderText="Visible">
					<ItemTemplate>
						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsActive") %>'>
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
	<ANW:AdvancedPanel id="Add" runat="server" Collapsible="False" HeaderText="Add New Category" HeaderCssClass="CollapsibleTitle"
		DisplayHeader="true" BodyCssClass="Edit"><LABEL class="Block">Title&nbsp; 
<asp:RequiredFieldValidator id="valtxbNewTitleRequired" runat="server" ControlToValidate="txbNewTitle" ForeColor="#990066"
				ErrorMessage="Your category must have a description"></asp:RequiredFieldValidator></LABEL>
<asp:TextBox id="txbNewTitle" runat="server" width="350"></asp:TextBox>&nbsp; 
Visible 
<asp:Label id="BlogID" runat="server" Visible="false"></asp:Label>
<asp:CheckBox id="ckbNewIsActive" runat="server" Checked="true"></asp:CheckBox><BR><LABEL class="Block">Description (1000 characters including HTML)</LABLE><BR>
<asp:TextBox id="txbNewDescription" runat="server" width="450" max="1000" rows="5" textmode="MultiLine"></asp:TextBox>
<DIV style="MARGIN-TOP: 8px">
				<asp:linkbutton id="lkbPost" runat="server" CssClass="Button" Text="Add"></asp:linkbutton><BR>
				&nbsp;
			</DIV></ANW:AdvancedPanel>
</ANW:PAGE></LABEL>
