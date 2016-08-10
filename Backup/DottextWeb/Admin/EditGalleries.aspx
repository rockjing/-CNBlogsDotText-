<%@ Page language="c#" Codebehind="EditGalleries.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.EditGalleries" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<ANW:Page runat="server" id="PageContainer" TabSectionID="Galleries" CategoryType="ImageCollection">
	<ANW:MessagePanel id="Messages" runat="server" MessageCssClass="MessagePanel" MessageIconUrl="~/admin/resources/ico_info.gif"
		ErrorCssClass="ErrorPanel" ErrorIconUrl="~/admin/resources/ico_critical.gif"></ANW:MessagePanel>
	<ANW:AdvancedPanel id="Results" runat="server" Collapsible="True" HeaderText="Galleries" HeaderCssClass="CollapsibleHeader"
		DisplayHeader="True" LinkBeforeHeader="True" LinkImage="~/admin/resources/toggle_gray_up.gif" LinkImageCollapsed="~/admin/resources/toggle_gray_down.gif"
		LinkStyle="Image">
		<asp:DataGrid id="dgrSelectionList" runat="server" AutoGenerateColumns="False" GridLines="None"
			CssClass="Listing">
			<AlternatingItemStyle CssClass="Alt"></AlternatingItemStyle>
			<HeaderStyle CssClass="Header"></HeaderStyle>
			<Columns>
				<asp:TemplateColumn HeaderText="Gallery">
					<ItemTemplate>
						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Title") %>' ID="Label1" NAME="Label1">
						</asp:Label>
						<br>
						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>' ID="Label3" NAME="Label1">
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
						<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsActive") %>' ID="Label2">
						</asp:Label>
					</ItemTemplate>
					<EditItemTemplate>
						<asp:CheckBox id="ckbIsActive" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.IsActive") %>'/>
					</EditItemTemplate>
				</asp:TemplateColumn>
				<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit" />
				<asp:ButtonColumn Text="Delete" CommandName="Delete" />
			</Columns>
		</asp:DataGrid>
		<ANW:AdvancedPanel id="Add" runat="server" Collapsible="False" HeaderText="Add New Gallery" HeaderCssClass="CollapsibleTitle"
			DisplayHeader="true" BodyCssClass="Edit"><LABEL class="Block">Title</LABEL> 
<asp:TextBox id="txbNewTitle" runat="server" width="350"></asp:TextBox>&nbsp; 
Visible 
<asp:CheckBox id="ckbNewIsActive" runat="server" Checked="true"></asp:CheckBox><BR><LABEL class="Block">Description (1000 characters including HTML)</LABLE><BR>
<asp:TextBox id="txbNewDescription" runat="server" width="450" textmode="MultiLine" rows="5"
					max="1000"></asp:TextBox>
<DIV style="MARGIN-TOP: 8px">
					<asp:linkbutton id="lkbPost" runat="server" CssClass="Button" Text="Add"></asp:linkbutton><BR>
					&nbsp;
				</DIV></ANW:AdvancedPanel>
	</ANW:AdvancedPanel>
	<ASP:Panel id="ImagesDiv" runat="server">
		<ANW:AdvancedPanel id="AddImages" runat="server" Collapsible="True" HeaderText="Add New Image" HeaderCssClass="CollapsibleTitle"
			DisplayHeader="true" LinkBeforeHeader="True" LinkImage="~/admin/resources/toggle_gray_up.gif" LinkImageCollapsed="~/admin/resources/toggle_gray_down.gif"
			LinkStyle="Image" BodyCssClass="Edit"><LABEL class="Block">Local File Location</LABEL> <INPUT class="FileUpload" id="ImageFile" type="file" size="82" name="ImageFile" runat="server"> 
<BR class="Clear"><LABEL class="Block">Image Description</LABEL> 
<asp:TextBox id="txbImageTitle" runat="server" size="82"></asp:TextBox>&nbsp; 
Visible 
<asp:CheckBox id="ckbIsActiveImage" runat="server" Checked="true"></asp:CheckBox>
<DIV style="MARGIN-TOP: 8px">
				<asp:linkbutton id="lbkAddImage" runat="server" CssClass="Button" Text="Add"></asp:linkbutton><BR>
				&nbsp;
			</DIV></ANW:AdvancedPanel>
		<H1>
			<ASP:PlaceHolder id="plhImageHeader" runat="server"></ASP:PlaceHolder></H1>
		<ASP:Repeater id="rprImages" runat="server">
			<HeaderTemplate>
				<div class="ImageList">
			</HeaderTemplate>
			<ItemTemplate>
				<div class="ImageThumbnail">
					<div class="ImageThumbnailImage">
						<asp:HyperLink id="lnkThumbnail" runat="server" ImageUrl='<%# EvalImageUrl(Container.DataItem) %>' NavigateUrl='<%# EvalImageNavigateUrl(Container.DataItem) %>'/>
					</div>
					<div class="ImageThumbnailTitle">
						<%# EvalImageTitle(Container.DataItem) %>
						<br>
						<a href='EditImage.aspx?imgid=<%# DataBinder.Eval(Container.DataItem, "ImageID") %>'>
							Edit</a> &nbsp;&bull;&nbsp;
						<asp:linkbutton id="lnkDeleteImage" CommandName="DeleteImage" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ImageID") %>' Text="Delete" runat="server" />
					</div>
				</div>
			</ItemTemplate>
			<FooterTemplate>
				</div>
			</FooterTemplate>
		</ASP:Repeater>
		<BR class="Clear">
	</ASP:Panel>
</ANW:Page></LABEL>
