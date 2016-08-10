<%@ Import Namespace = "Dottext.Web.Admin" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EntryEditor.ascx.cs" Inherits="Dottext.Web.Admin.UserControls.EntryEditor" Debug="True"%>
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
				FTB_InsertText('Editor_Edit_ftbBody',oPersistDiv.getAttribute("sPersistContent"));
				var title=document.getElementById('Editor_Edit_txbTitle');
				title.value=oPersistDiv.getAttribute("sPersistTitle");
			}
			function ClearTemp()
			{
				oPersistDiv.setAttribute("sPersistValue","");
				oPersistDiv.save("oXMLStore");
			}
</SCRIPT>
<!--Ene TempSave--><ANW:MESSAGEPANEL id="Messages" runat="server"></ANW:MESSAGEPANEL><ANW:ADVANCEDPANEL id="Results" runat="server" LinkStyle="Image" LinkBeforeHeader="True" DisplayHeader="True"
	HeaderCssClass="CollapsibleHeader" LinkText="[toggle]" Collapsible="True">
	<asp:Repeater id="rprSelectionList" runat="server">
		<HeaderTemplate>
			<table id="Listing" class="Listing" cellSpacing="0" cellPadding="0" border="0" style='<%= CheckHiddenStyle() %>' >
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
					(
					<asp:Literal runat = "server" Text = '<%# (DateTime.Parse(DataBinder.Eval(((RepeaterItem)Container).DataItem,"DateCreated").ToString())).ToString("MM-dd HH:mm") %>' ID="Literal2"/>)
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
					(
					<asp:Literal runat = "server" Text = '<%# (DateTime.Parse(DataBinder.Eval(((RepeaterItem)Container).DataItem,"DateCreated").ToString())).ToString("MM-dd HH:mm") %>' ID="Literal1"/>)
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
	<P id="NoMessagesLabel" runat="server" visible="false">No entries found.</P>
	<ANW:Pager id="ResultsPager" runat="server" UseSpacer="False" PrefixText="<div>Goto page</div>"
		LinkFormatActive='<a href="{0}" class="Current">{1}</a>' UrlFormat="EditPosts.aspx?pg={0}"
		CssClass="Pager"></ANW:Pager>
	<BR class="Clear">
</ANW:ADVANCEDPANEL><ANW:ADVANCEDPANEL id="Edit" runat="server" LinkStyle="Image" DisplayHeader="True" HeaderCssClass="CollapsibleTitle"
	Collapsible="False" LinkImageCollapsed="~/admin/resources/toggle_gray_down.gif" LinkImage="~/admin/resources/toggle_gray_up.gif"
	HeaderText="Edit Post">
	<TABLE class="TableEdit" id="TableEdit" width="100%">
		<TR>
			<TD>
				<asp:HyperLink id="hlEntryLink" Runat="server" Target="_blank"></asp:HyperLink></TD>
		</TR>
		<TR>
			<TD><B>标题:</B>
				<asp:RequiredFieldValidator id="valTitleRequired" runat="server" ErrorMessage="请输入标题" ForeColor="#990066" ControlToValidate="txbTitle"></asp:RequiredFieldValidator></TD>
		</TR>
		<TR>
			<TD>
				<asp:TextBox id="txbTitle" runat="server" MaxLength="250" width="98%" columns="255"></asp:TextBox></TD>
		</TR>
		<TR>
			<TD><B>内容:</B>
				<asp:RequiredFieldValidator id="valftbBodyRequired" runat="server" ErrorMessage="请输入内容" ForeColor="#990066"
					ControlToValidate="ftbBody"></asp:RequiredFieldValidator></TD>
		</TR>
		<TR>
			<TD>
				<ftb:FreeTextBox language="zh-cn" id="ftbBody" runat="server" Width="98%" Height="400" ToolbarStyleConfiguration="OfficeXP"
					Visible="true"></ftb:FreeTextBox></TD>
		</TR>
		<TR>
			<TD><BR>
				<B>个人分类:</B>
			</TD>
		</TR>
		<TR>
			<TD>
				<asp:CheckBoxList id="cklCategories" runat="server" Width="95%" RepeatDirection="Horizontal" RepeatColumns="6"></asp:CheckBoxList>
				<asp:Literal id="literalGroup" Runat="server">
					<B>网站分类:</B></asp:Literal>
			</TD>
		</TR>
		<TR>
			<TD>
				<asp:RadioButtonList id="cklGroups" runat="server" Width="98%" RepeatDirection="Horizontal" RepeatColumns="6"
					BackColor="#F5F5F5"></asp:RadioButtonList></TD>
		</TR>
		<TR>
			<TD>
				<asp:Literal id="LiteralOptions" Runat="server">
					<B>选项:</B></asp:Literal>
			</TD>
		</TR>
		<TR>
			<TD>
				<asp:CheckBox id="chkIsAggregated" runat="server" Text="发布到所选网站分类" textalign="right" Checked="True"></asp:CheckBox>&nbsp;&nbsp;
			</TD>
		</TR>
		<TR>
			<TD height="5"></TD>
		</TR>
		<TR>
			<TD>
				<DIV>
					<asp:LinkButton id="lkbPost" runat="server" CssClass="Button" Text="Post"></asp:LinkButton>
					<asp:LinkButton id="lkbCancel" runat="server" CssClass="Button" Text="Cancel" CausesValidation="False">Cancel</asp:LinkButton>
					<asp:LinkButton id="LkbPreview" runat="server" CssClass="Button" Text="Post">Preview</asp:LinkButton><BR>
					&nbsp;
				</DIV>
			</TD>
		</TR>
	</TABLE>
	<ANW:AdvancedPanel id="Advanced" runat="server" Collapsible="True" LinkText="[toggle]" HeaderCssClass="CollapsibleTitle"
		DisplayHeader="True" LinkBeforeHeader="True" LinkStyle="Image" HeaderText="Advanced Options" HeaderTextCssClass="CollapsibleTitle"
		Collapsed="true" BodyCssClass="Edit">
		<P class="ValueLabel">
		<table width="100%"><tr>
		<td>
			<asp:CheckBox id="ckbPublished" runat="server" textalign="Left" Text="Published"></asp:CheckBox>
		</td>
		<td>
			<asp:CheckBox id="chkComments" runat="server" textalign="Left" Text="Allow Comments"></asp:CheckBox>
		</td>
		<td>
			<asp:CheckBox id="chkDisplayHomePage" runat="server" textalign="Left" Text="显示在我的主页"></asp:CheckBox>
		</td>
		<td>
			<asp:CheckBox id="chkMainSyndication" runat="server" textalign="Left" Text="允许客户端订阅[RSS]"></asp:CheckBox>
		</td>
		<td>
			<asp:CheckBox id="chkSyndicateDescriptionOnly" runat="server" textalign="Left" Text="仅聚合文章摘要"></asp:CheckBox>
		</td>
		</tr>
		<tr>
		<td>
			<asp:CheckBox id="chkIsMoveTo" runat="server" Visible="False" textalign="Left" Checked="False"></asp:CheckBox>
		</td>
		<td>
			<asp:CheckBox id="chkUpdateCreatedTime" runat="server" Visible="False" textalign="Left" Text="更新创建时间"
				Checked="False"></asp:CheckBox>
		</td></tr>
		</table>
		</P>
		<P class="Label">EntryName (page name)
			<asp:RegularExpressionValidator id="vRegexEntryName" runat="server" ControlToValidate="txbEntryName" Text="Invalid EntryName Format. Must match the follwing pattern: ^[a-zA-Z][\w-]{1,149}$"
				ValidationExpression="^[a-zA-Z][\w-]{1,149}$"></asp:RegularExpressionValidator></P>
		<P>
			<asp:TextBox id="txbEntryName" runat="server" MaxLength="150" width="98%" columns="255"></asp:TextBox></P>
		<P class="Label">摘要</P>
		<P>
			<asp:TextBox id="txbExcerpt" runat="server" MaxLength="500" width="98%" textmode="MultiLine"
				rows="5"></asp:TextBox></P>
		<P class="Label">Title Url</P>
		<P>
			<asp:TextBox id="txbTitleUrl" runat="server" MaxLength="250" width="98%" columns="255"></asp:TextBox></P>
		<P class="Label">Source Name</P>
		<P>
			<asp:TextBox id="txbSourceName" runat="server" width="98%" columns="255"></asp:TextBox></P>
		<P class="Label">Source Url</P>
		<P>
			<asp:TextBox id="txbSourceUrl" runat="server" width="98%" columns="255"></asp:TextBox></P>
	</ANW:AdvancedPanel>
</ANW:ADVANCEDPANEL>
<P></P>
<P><asp:validationsummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"
		DisplayMode="SingleParagraph"></asp:validationsummary></P>
