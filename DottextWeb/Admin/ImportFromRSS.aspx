<%@ Register TagPrefix="skm" Namespace="skmRss" Assembly="skmRss" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<%@ Page language="c#" Codebehind="ImportFromRSS.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.ImportFromRSS" %>
<ANW:Page id="PageContainer" TabSectionID="Posts" runat="server">
	<ANW:MessagePanel id="Messages" runat="server"></ANW:MessagePanel>
	<ANW:AdvancedPanel id="Results" runat="server" DisplayHeader="true" HeaderCssClass="CollapsibleHeader"
		HeaderText="ImportFromRSS" Collapsible="False">
		<P align="left">RSS地址:&nbsp;&nbsp;
			<asp:textbox id="TextBoxAddress" runat="server" Width="300"></asp:textbox>
			<asp:button id="ButtonRead" runat="server" Text="读取"></asp:button>&nbsp;&nbsp;
			<asp:button id="ButtonImport" runat="server" Text="导入" visible="false"></asp:button></P>
		<P>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" visible="false" ErrorMessage="请输入RSS地址"
				ControlToValidate="TextBoxAddress"></asp:RequiredFieldValidator></P>
		<P>
			<asp:CheckBox id="ckbIsOriginalTime" runat="server" Text="使用原文日期" Visible="False" TextAlign="Left"></asp:CheckBox>&nbsp;&nbsp;
			<asp:CheckBox id="ckbIsShowImportFlag" runat="server" Text="显示导入标记" Visible="False" TextAlign="Left"
				Checked="True"></asp:CheckBox></P>
		<P>
			<asp:Literal id="LiteralMsg" runat="server" visible="false"></asp:Literal></P>
		<skm:rssfeed id="RssFeed1" runat="server" MaxItems="50" CellPadding="4" Font-Size="10pt" Font-Names="Arial"
			width="80%" HorizontalAlign="center">
			<AlternatingItemStyle BackColor="#E0E0E0" />
			<HeaderStyle Font-Size="14pt" HorizontalAlign="right" Font-Bold="True" ForeColor="black" BackColor="#E0E0E0"></HeaderStyle>
			<ItemTemplate>
				<asp:Literal Runat="server" ID="sn"></asp:Literal>
				<asp:CheckBox Runat="server" id="CheckBox1"></asp:CheckBox>
				<strong>
					<asp:HyperLink NavigateUrl="<%# Container.DataItem.Link %>" Target="_blank" Runat = "server" Text="<%# Container.DataItem.Title %>" ID="LinkTitle">
					</asp:HyperLink>
				</strong>
				<br>
				<i>
					<asp:Literal Runat="server" Text="<%# Container.DataItem.PubDate %>" ID="LiteralDate">
					</asp:Literal>
				</i><i>
					<asp:Literal Runat="server" Text="<%# Container.DataItem.Description %>" ID="LiteralDes" Visible="False">
					</asp:Literal>
				</i>
			</ItemTemplate>
		</skm:rssfeed>
	</ANW:AdvancedPanel>
</ANW:Page>
