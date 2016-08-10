<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<%@ Page language="c#" Codebehind="Preferences.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.EditPreferences" %>
<ANW:PAGE id="PageContainer" CategoriesLabel="Other Items" TabSectionID="Options" runat="server">
	<ANW:MessagePanel id="Messages" runat="server"></ANW:MessagePanel>
	<ANW:AdvancedPanel id="Edit" runat="server" DisplayHeader="True" HeaderText="Preferences" HeaderCssClass="CollapsibleHeader"
		BodyCssClass="Edit">
		<P style="MARGIN-TOP: 8px">Default number of items to display in listings &nbsp;
			<asp:DropDownList id="ddlPageSize" runat="server" AutoPostBack="false">
				<asp:ListItem Value="1">1</asp:ListItem>
				<asp:ListItem Value="2">2</asp:ListItem>
				<asp:ListItem Value="33">3</asp:ListItem>
				<asp:ListItem Value="4">4</asp:ListItem>
				<asp:ListItem Value="5">5</asp:ListItem>
				<asp:ListItem Value="10">10</asp:ListItem>
				<asp:ListItem Value="15">15</asp:ListItem>
				<asp:ListItem Value="20">20</asp:ListItem>
				<asp:ListItem Value="25">25</asp:ListItem>
				<asp:ListItem Value="30">30</asp:ListItem>
				<asp:ListItem Value="40">40</asp:ListItem>
				<asp:ListItem Value="50">50</asp:ListItem>
				<asp:ListItem Value="60">60</asp:ListItem>
			</asp:DropDownList></P>
		<P style="MARGIN-TOP: 8px">Always create new items as Published &nbsp;
			<asp:DropDownList id="ddlPublished" runat="server" AutoPostBack="false">
				<asp:ListItem Value="true">Yes</asp:ListItem>
				<asp:ListItem Value="false">No</asp:ListItem>
			</asp:DropDownList></P>
		<P style="MARGIN-TOP: 8px">Always expand advanced options &nbsp;
			<asp:DropDownList id="ddlExpandAdvanced" runat="server" AutoPostBack="false">
				<asp:ListItem Value="true">Yes</asp:ListItem>
				<asp:ListItem Value="false">No</asp:ListItem>
			</asp:DropDownList></P>
		<P style="MARGIN-TOP: 8px">
			<asp:CheckBox id="EnableComments" runat="Server" Text="Enable Comments" TextAlign="Left"></asp:CheckBox>&nbsp;
		</P>
		<P style="MARGIN-TOP: 8px">
			<asp:CheckBox id="EnableMailNotify" runat="Server" Text="�����ʼ�֪ͨ" TextAlign="Left"></asp:CheckBox>&nbsp;
		</P>
		<P style="MARGIN-TOP: 8px">
			<asp:CheckBox id="chkOnlyTitle" runat="Server" Text="��ҳ���г�����" TextAlign="Left"></asp:CheckBox>&nbsp;
		</P>
		<P style="MARGIN-TOP: 8px">�ؼ���ʾ����(ѡ��ʱ��ʾ):</P>
		<P>
			<asp:CheckBoxList id="cklSkinControl" runat="server" TextAlign="Left" RepeatColumns="5"></asp:CheckBoxList></P>
		<DIV style="MARGIN-TOP: 12px">
			<ASP:LinkButton id="lkbUpdate" runat="server" Text="Save" CssClass="Button"></ASP:LinkButton>
			<ASP:LinkButton id="lkbCancel" runat="server" Text="Cancel" CssClass="Button"></ASP:LinkButton><BR>
			&nbsp;
		</DIV>
	</ANW:AdvancedPanel>
</ANW:PAGE>
