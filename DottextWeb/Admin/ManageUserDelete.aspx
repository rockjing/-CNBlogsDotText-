<%@ Page language="c#" Codebehind="ManageUserDelete.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.ManageUserDelete" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<ANW:PAGE id="PageContainer" TabSectionID="ManageSite" runat="server">
	<ANW:MESSAGEPANEL id="Messages" runat="server"></ANW:MESSAGEPANEL>
	<ANW:ADVANCEDPANEL id="SqlPanel" runat="server" Collapsible="true" LinkText="[toggle]" HeaderCssClass="CollapsibleHeader"
		DisplayHeader="true" LinkBeforeHeader="True" LinkStyle="Image" HeaderText="删除Blog帐号" Visible="true"><FONT face="宋体">
		</FONT><BR>Blog帐号: 
<asp:TextBox id="tbUserName" runat="server" Width="150px"></asp:TextBox>
<asp:Button id="btnReadBlog" runat="server" Text="读取"></asp:Button></ANW:ADVANCEDPANEL>
	<ANW:ADVANCEDPANEL id="BlogInfo" runat="server" Collapsible="true" LinkText="[toggle]" HeaderCssClass="CollapsibleHeader"
		DisplayHeader="true" LinkBeforeHeader="True" LinkStyle="Image" HeaderText="Blog帐号信息" Visible="false"><FONT face="宋体">
		</FONT><BR>BlogID: 
<asp:Literal id="ltBlogID" runat="server"></asp:Literal><BR>昵称: 
<asp:Literal id="ltAuthor" runat="server"></asp:Literal><BR>标题: 
<asp:Literal id="ltTitle" runat="server"></asp:Literal><BR>子标题: 
<asp:Literal id="ltSubTitle" runat="server"></asp:Literal><BR>随笔数: 
<asp:Literal id="ltPostCount" runat="server"></asp:Literal><BR>文章数: 
<asp:Literal id="ltStorycount" runat="server"></asp:Literal><BR><BR>
<asp:Button id="btnDelete" runat="server" Text="删除"></asp:Button></ANW:ADVANCEDPANEL>
</ANW:PAGE>
