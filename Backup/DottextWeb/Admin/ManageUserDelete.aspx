<%@ Page language="c#" Codebehind="ManageUserDelete.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.ManageUserDelete" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<ANW:PAGE id="PageContainer" TabSectionID="ManageSite" runat="server">
	<ANW:MESSAGEPANEL id="Messages" runat="server"></ANW:MESSAGEPANEL>
	<ANW:ADVANCEDPANEL id="SqlPanel" runat="server" Collapsible="true" LinkText="[toggle]" HeaderCssClass="CollapsibleHeader"
		DisplayHeader="true" LinkBeforeHeader="True" LinkStyle="Image" HeaderText="ɾ��Blog�ʺ�" Visible="true"><FONT face="����">
		</FONT><BR>Blog�ʺ�: 
<asp:TextBox id="tbUserName" runat="server" Width="150px"></asp:TextBox>
<asp:Button id="btnReadBlog" runat="server" Text="��ȡ"></asp:Button></ANW:ADVANCEDPANEL>
	<ANW:ADVANCEDPANEL id="BlogInfo" runat="server" Collapsible="true" LinkText="[toggle]" HeaderCssClass="CollapsibleHeader"
		DisplayHeader="true" LinkBeforeHeader="True" LinkStyle="Image" HeaderText="Blog�ʺ���Ϣ" Visible="false"><FONT face="����">
		</FONT><BR>BlogID: 
<asp:Literal id="ltBlogID" runat="server"></asp:Literal><BR>�ǳ�: 
<asp:Literal id="ltAuthor" runat="server"></asp:Literal><BR>����: 
<asp:Literal id="ltTitle" runat="server"></asp:Literal><BR>�ӱ���: 
<asp:Literal id="ltSubTitle" runat="server"></asp:Literal><BR>�����: 
<asp:Literal id="ltPostCount" runat="server"></asp:Literal><BR>������: 
<asp:Literal id="ltStorycount" runat="server"></asp:Literal><BR><BR>
<asp:Button id="btnDelete" runat="server" Text="ɾ��"></asp:Button></ANW:ADVANCEDPANEL>
</ANW:PAGE>
