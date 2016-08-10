<%@ Import Namespace = "Dottext.Web.Admin" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EntryEditor.ascx.cs" Inherits="Dottext.Web.Admin.UserControls.EntryEditor" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<!--Beging Temp Save-->
<STYLE>.userData { BEHAVIOR: url(#default#userdata) }
	</STYLE>
<DIV class="userData" id="oPersistDiv"></DIV>
<SCRIPT>
			function TempSave(title,body)
			{
				oPersistDiv.setAttribute("sPersistContent",body);
				oPersistDiv.setAttribute("sPersistTitle",title.value);
				oPersistDiv.save("oXMLStore");
			}
			function Restore(editor)
			{
				oPersistDiv.load("oXMLStore");
				editor.focus();
				sel = editor.document.selection.createRange();
				sel.pasteHTML(oPersistDiv.getAttribute("sPersistContent"));
				var title=document.getElementById('Editor_Edit_txbTitle');
				title.value=oPersistDiv.getAttribute("sPersistTitle");
			}
			function ClearTemp()
			{
				oPersistDiv.setAttribute("sPersistValue","");
				oPersistDiv.save("oXMLStore");
			}
</SCRIPT>
<!--Ene TempSave-->
<P><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><ANW:MESSAGEPANEL id="Messages" runat="server"></ANW:MESSAGEPANEL><ANW:ADVANCEDPANEL id="Results" runat="server" Collapsible="True" LinkText="[toggle]" HeaderCssClass="CollapsibleHeader"
		DisplayHeader="True" LinkBeforeHeader="True" LinkStyle="Image">
		<asp:Repeater id="rprSelectionList" runat="server">
			<HeaderTemplate>
				<table id="Listing" class="Listing" cellSpacing="0" cellPadding="0" border="0" style='<%= CheckHiddenStyle() %>'>
					<tr style="text-align:center">
						<th>
							Description</th>
						<th width="40" style="text-align:center">
							Active</th>
						<th width="70" style="text-align:center">
							Web Views</th>
						<th width="70" style="text-align:center">
							Agg Views</th>
						<th width="40" style="text-align:center">
							Referrals</th>
						<th width="40" style="text-align:center">
							&nbsp;</th>
						<th width="40" style="text-align:center">
							&nbsp;</th>
					</tr>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td>
						<asp:HyperLink Runat="server" CssClass="titlelink" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "TitleUrl") %>' Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' ID="LinkTitle">
						</asp:HyperLink>
					</td>
					<td style="text-align:center">
						<%# DataBinder.Eval(Container.DataItem, "IsActive") %>
					</td>
					<td style="text-align:center">
						<%# DataBinder.Eval(Container.DataItem, "WebCount") %>
					</td>
					<td style="text-align:center">
						<%# DataBinder.Eval(Container.DataItem, "AggCount") %>
					</td>
					<td style="text-align:center">
						<a href='Referrers.aspx?EntryID=<%# DataBinder.Eval(Container.DataItem, "EntryID") %>'>
							View</a>
					</td>
					<td style="text-align:center">
						<asp:LinkButton id="lnkEdit" CausesValidation = "False" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EntryID") %>' Text="Edit" runat="server" />
					</td>
					<td style="text-align:center">
						<asp:LinkButton id="lnkDelete" CausesValidation = "False" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EntryID") %>' Text="Delete" runat="server" />
					</td>
				</tr>
			</ItemTemplate>
			<AlternatingItemTemplate>
				<tr class="Alt" style="text-align:center">
					<td>
						<asp:HyperLink Runat="server" CssClass="titlelink" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "TitleUrl") %>' Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' ID="Hyperlink1">
						</asp:HyperLink>
					</td>
					<td style="text-align:center">
						<%# DataBinder.Eval(Container.DataItem, "IsActive") %>
					</td>
					<td style="text-align:center">
						<%# DataBinder.Eval(Container.DataItem, "WebCount") %>
					</td>
					<td style="text-align:center">
						<%# DataBinder.Eval(Container.DataItem, "AggCount") %>
					</td>
					<td style="text-align:center">
						<a href='Referrers.aspx?EntryID=<%# DataBinder.Eval(Container.DataItem, "EntryID") %>'>
							View</a>
					</td>
					<td style="text-align:center">
						<asp:LinkButton id="lnkEditAlt" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EntryID") %>' Text="Edit" runat="server" />
					</td>
					<td style="text-align:center">
						<asp:LinkButton id="lnkDeleteAlt" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EntryID") %>' Text="Delete" runat="server" />
					</td>
				</tr>
			</AlternatingItemTemplate>
			<FooterTemplate>
				</table>
			</FooterTemplate>
		</asp:Repeater>
		<P id="NoMessagesLabel" runat="server" visible="false">没有文章.</P>
		<ANW:Pager id="ResultsPager" runat="server" CssClass="Pager" UrlFormat="EditPosts.aspx?pg={0}"
			LinkFormatActive='<a href="{0}" class="Current">{1}</a>' PrefixText="<div>Goto page</div>"
			UseSpacer="False"></ANW:Pager>
		<BR class="Clear">
	</ANW:ADVANCEDPANEL><ANW:ADVANCEDPANEL id="Edit" runat="server" Collapsible="False" HeaderCssClass="CollapsibleTitle" DisplayHeader="True"
		LinkStyle="Image" HeaderText="Edit Post" LinkImage="~/admin/resources/toggle_gray_up.gif" LinkImageCollapsed="~/admin/resources/toggle_gray_down.gif">
		<DIV class="Edit"><!-- DEBUG -->
			<P class="Label">
				<asp:HyperLink id="hlEntryLink" Target="_blank" Runat="server"></asp:HyperLink></P>
			<P class="Label">标题:
				<asp:RequiredFieldValidator id="valTitleRequired" runat="server" ControlToValidate="txbTitle" ForeColor="#990066"
					ErrorMessage="请输入标题"></asp:RequiredFieldValidator></P>
			<P>
				<asp:TextBox id="txbTitle" runat="server" columns="255" width="98%" MaxLength="250"></asp:TextBox></P>
			<P class="Label">内容:
				<asp:RequiredFieldValidator id="valtbBodyRequired" runat="server" ControlToValidate="txbBody" ForeColor="#990066"
					ErrorMessage="请输入内容"></asp:RequiredFieldValidator>
				<asp:RequiredFieldValidator id="valftbBodyRequired" runat="server" ControlToValidate="ftbBody" ForeColor="#990066"
					ErrorMessage="请输入内容"></asp:RequiredFieldValidator></P>
			<P>
				<FTB:FreeTextBox id="ftbBody" runat="server" visible="False" width="98%" toolbarbackcolor="Transparent"
					backcolor="Transparent" height="300px" toolbartype="Custom" downlevelmode="TextArea" gutterbackcolor="Transparent"
					GutterBorderColorDark="Transparent" EditorBorderColorDark="Transparent" EditorBorderColorLight="Transparent"
					BreakMode="LineBreak"></FTB:FreeTextBox>
				<asp:TextBox id="txbBody" runat="server" visible="False" width="98%" rows="20" textmode="MultiLine"
					Enabled="False"></asp:TextBox></P>
			<ANW:AdvancedPanel id="MyCategory" runat="server" LinkStyle="Image" LinkBeforeHeader="True" DisplayHeader="True"
				HeaderCssClass="CollapsibleTitle" LinkText="[toggle]" Collapsible="True" HeaderText="个人分类" BodyCssClass="Edit"
				Collapsed="false" HeaderTextCssClass="CollapsibleTitle">
				<asp:CheckBoxList id="cklCategories" runat="server" Width="98%" RepeatColumns="6" RepeatDirection="Horizontal"></asp:CheckBoxList>
			</ANW:AdvancedPanel>
			<ANW:AdvancedPanel id="GlobalCategory" runat="server" LinkStyle="Image" LinkBeforeHeader="True" DisplayHeader="True"
				HeaderCssClass="CollapsibleTitle" LinkText="[toggle]" Collapsible="True" HeaderText="网站分类" BodyCssClass="Edit"
				Collapsed="false" HeaderTextCssClass="CollapsibleTitle">
				<asp:Panel id="GlobalCategoryPanel" Runat="server"></asp:Panel>
			</ANW:AdvancedPanel><BR>
			<DIV>
				<asp:LinkButton id="lkbPost" runat="server" CssClass="Button" Text="Post"></asp:LinkButton>
				<asp:LinkButton id="lkbCancel" runat="server" CssClass="Button" Text="Cancel" CausesValidation="False">Cancel</asp:LinkButton>
				<asp:LinkButton id="LkbPreview" runat="server" CssClass="Button" Text="Post">Preview</asp:LinkButton><BR>
				&nbsp;
			</DIV>
		</DIV>
		<ANW:AdvancedPanel id="Advanced" runat="server" LinkStyle="Image" LinkBeforeHeader="True" DisplayHeader="True"
			HeaderCssClass="CollapsibleTitle" LinkText="[toggle]" Collapsible="True" HeaderText="Advanced Options"
			BodyCssClass="Edit" Collapsed="true" HeaderTextCssClass="CollapsibleTitle">
			<P class="ValueLabel">
				<asp:CheckBox id="ckbPublished" runat="server" Text="Published" textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
				<asp:CheckBox id="chkComments" runat="server" Text="Allow Comments" textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
				<asp:CheckBox id="chkDisplayHomePage" runat="server" Text="显示在我的主页" textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
				<asp:CheckBox id="chkMainSyndication" runat="server" Text="允许客户端订阅[RSS]" textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
				<asp:CheckBox id="chkSyndicateDescriptionOnly" runat="server" Text="仅聚合文章摘要" textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
				<asp:CheckBox id="chkIsAggregated" runat="server" Text="显示在站点主页" textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
				<asp:CheckBox id="chkIsMoveTo" runat="server" textalign="Left" Visible="False" Checked="False"></asp:CheckBox></P>
			<P class="Label">EntryName (page name)
				<asp:RegularExpressionValidator id="vRegexEntryName" runat="server" ControlToValidate="txbEntryName" Text="Invalid EntryName Format. Must match the follwing pattern: ^[a-zA-Z][\w-]{1,149}$"
					ValidationExpression="^[a-zA-Z][\w-]{1,149}$"></asp:RegularExpressionValidator></P>
			<P>
				<asp:TextBox id="txbEntryName" runat="server" columns="255" width="98%" MaxLength="150"></asp:TextBox></P>
			<P class="Label">摘要</P>
			<P>
				<asp:TextBox id="txbExcerpt" runat="server" width="98%" MaxLength="500" rows="5" textmode="MultiLine"></asp:TextBox></P>
			<P class="Label">Title Url</P>
			<P>
				<asp:TextBox id="txbTitleUrl" runat="server" columns="255" width="98%" MaxLength="250"></asp:TextBox></P>
			<P class="Label">Source Name</P>
			<P>
				<asp:TextBox id="txbSourceName" runat="server" columns="255" width="98%"></asp:TextBox></P>
			<P class="Label">Source Url</P>
			<P>
				<asp:TextBox id="txbSourceUrl" runat="server" columns="255" width="98%"></asp:TextBox></P>
		</ANW:AdvancedPanel>
	</ANW:ADVANCEDPANEL>
<P></P>
<P><asp:validationsummary id="ValidationSummary1" runat="server" DisplayMode="SingleParagraph" ShowSummary="False"
		ShowMessageBox="True"></asp:validationsummary></P>
