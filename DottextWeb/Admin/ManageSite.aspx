<%@ Page language="c#" Codebehind="ManageSite.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.ManageSite" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<ANW:PAGE id="PageContainer" TabSectionID="ManageSite" runat="server">
	<FONT face="宋体"></FONT>
	<ANW:MessagePanel id="Messages" runat="server"></ANW:MessagePanel>
	<ANW:AdvancedPanel id="Results" runat="server" DisplayHeader="true" HeaderCssClass="CollapsibleHeader"
		HeaderText="ManageSite" Collapsible="False">
<P align="left">文章地址:&nbsp;&nbsp;
			<asp:textbox id="txbUrl" runat="server" Width="400"></asp:textbox>
			<asp:button id="ButtonRead" runat="server" Text="读取"></asp:button>&nbsp;&nbsp;<BR>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="文章地址不能为空" ControlToValidate="txbUrl"></asp:RequiredFieldValidator></P>标题: 
<asp:Literal id="Title" runat="server" visible="false"></asp:Literal><BR><BR>ID: 
<asp:Literal id="PostID" runat="server" visible="false"></asp:Literal>
<asp:Literal id="ltBlogID" runat="server" visible="false"></asp:Literal>
<P class="Label">
			<asp:Literal id="ltGroup" Text="网站分类:" Runat="server"></asp:Literal>
			<asp:RadioButtonList id="cklSiteGroups" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"></asp:RadioButtonList></P>精华区分类: 
<asp:RadioButtonList id="cklPickedCategory" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"></asp:RadioButtonList>
<asp:Button id="btnPutTech" runat="server" Text="更改所属网站分类"></asp:Button>
<asp:Button id="btnDisableMain" runat="server" Text="禁止显示在首页"></asp:Button>
<asp:Button id="btnPutPicked" runat="server" Text="放入精华区"></asp:Button>
<asp:Button id="ButtonPickedRemove" runat="server" Text="移出精华区"></asp:Button><!--<P>
			<asp:Literal id="literalGroup" Text="网站分类:" Runat="server"></asp:Literal>
			<asp:RadioButtonList id="cklGroups" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"></asp:RadioButtonList></P>
		<P class="ValueLabel">
			<asp:CheckBox id="ckbPublished" runat="server" Text="Published" textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
			<asp:CheckBox id="chkComments" runat="server" Text="Allow Comments" textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
			<asp:CheckBox id="chkDisplayHomePage" runat="server" Text="显示在我的Blog页面" textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
			<asp:CheckBox id="chkMainSyndication" runat="server" Text="Syndicate on Main Feed" textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
			<asp:CheckBox id="chkSyndicateDescriptionOnly" runat="server" Text="Syndicate Description Only"
				textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
			<asp:CheckBox id="chkIsAggregated" runat="server" Text="显示在首页" textalign="Left"></asp:CheckBox>&nbsp;&nbsp;
			<asp:CheckBox id="chkIsMoveTo" runat="server" Visible="False" textalign="Left" Checked="False"></asp:CheckBox></P>
		<P>
			<asp:Button id="btnUpdate" runat="server" Text="更改"></asp:Button></P>--></ANW:AdvancedPanel>
</ANW:PAGE>
