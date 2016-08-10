<%@ Page language="c#" Codebehind="ManageSite.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.ManageSite" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<ANW:PAGE id="PageContainer" TabSectionID="ManageSite" runat="server">
	<FONT face="����"></FONT>
	<ANW:MessagePanel id="Messages" runat="server"></ANW:MessagePanel>
	<ANW:AdvancedPanel id="Results" runat="server" DisplayHeader="true" HeaderCssClass="CollapsibleHeader"
		HeaderText="ManageSite" Collapsible="False">
<P align="left">���µ�ַ:&nbsp;&nbsp;
			<asp:textbox id="txbUrl" runat="server" Width="400"></asp:textbox>
			<asp:button id="ButtonRead" runat="server" Text="��ȡ"></asp:button>&nbsp;&nbsp;<BR>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="���µ�ַ����Ϊ��" ControlToValidate="txbUrl"></asp:RequiredFieldValidator></P>����: 
<asp:Literal id="Title" runat="server" visible="false"></asp:Literal><BR><BR>ID: 
<asp:Literal id="PostID" runat="server" visible="false"></asp:Literal>
<asp:Literal id="ltBlogID" runat="server" visible="false"></asp:Literal>
<P class="Label">
			<asp:Literal id="ltGroup" Text="��վ����:" Runat="server"></asp:Literal>
			<asp:RadioButtonList id="cklSiteGroups" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"></asp:RadioButtonList></P>����������: 
<asp:RadioButtonList id="cklPickedCategory" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"></asp:RadioButtonList>
<asp:Button id="btnPutTech" runat="server" Text="����������վ����"></asp:Button>
<asp:Button id="btnDisableMain" runat="server" Text="��ֹ��ʾ����ҳ"></asp:Button>
<asp:Button id="btnPutPicked" runat="server" Text="���뾫����"></asp:Button>
<asp:Button id="ButtonPickedRemove" runat="server" Text="�Ƴ�������"></asp:Button><!--<P>
			<asp:Literal id="literalGroup" Text="��վ����:" Runat="server"></asp:Literal>
			<asp:RadioButtonList id="cklGroups" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"></asp:RadioButtonList></P>
		<P class="ValueLabel">
			<asp:CheckBox id="ckbPublished" runat="server" Text="Published" textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
			<asp:CheckBox id="chkComments" runat="server" Text="Allow Comments" textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
			<asp:CheckBox id="chkDisplayHomePage" runat="server" Text="��ʾ���ҵ�Blogҳ��" textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
			<asp:CheckBox id="chkMainSyndication" runat="server" Text="Syndicate on Main Feed" textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
			<asp:CheckBox id="chkSyndicateDescriptionOnly" runat="server" Text="Syndicate Description Only"
				textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
			<asp:CheckBox id="chkIsAggregated" runat="server" Text="��ʾ����ҳ" textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
			<asp:CheckBox id="chkIsMoveTo" runat="server" Visible="False" textalign="Left" Checked="False"></asp:CheckBox></P>
		<P>
			<asp:Button id="btnUpdate" runat="server" Text="����"></asp:Button></P>--></ANW:AdvancedPanel>
</ANW:PAGE>
