<%@ Page language="c#" Codebehind="AddToFavorite.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Pages.AddToFavorite" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>��ӵ��ղؼ�</title>
		<style>BODY { PADDING-RIGHT: 32px; MARGIN-TOP: 60px; PADDING-LEFT: 32px; FONT-SIZE: 13px; BACKGROUND: #eee; PADDING-BOTTOM: 32px; MARGIN-LEFT: auto; WIDTH: 100px; COLOR: #000; MARGIN-RIGHT: auto; PADDING-TOP: 32px; FONT-FAMILY: arial }
	DIV#Main { BORDER-RIGHT: #bbb 1px solid; PADDING-RIGHT: 32px; BORDER-TOP: #bbb 1px solid; FONT-SIZE: 14px;PADDING-LEFT: 32px; BACKGROUND: #fff; PADDING-BOTTOM: 32px; BORDER-LEFT: #bbb 1px solid; WIDTH: 300px; PADDING-TOP: 32px; BORDER-BOTTOM: #bbb 1px solid }
	DIV#Heading { PADDING-RIGHT: 0px; PADDING-LEFT: 0px; FONT-WEIGHT: bold; FONT-SIZE: 15px; PADDING-BOTTOM: 18px; MARGIN: 0px; COLOR: #904; PADDING-TOP: 0px; FONT-FAMILY: arial }
	.button { BORDER-RIGHT: #999 1px solid; PADDING-RIGHT: 12px; BORDER-TOP: #999 1px solid; DISPLAY: block; PADDING-LEFT: 12px; FONT-WEIGHT: bold; BACKGROUND: #904; FLOAT: left; PADDING-BOTTOM: 3px; BORDER-LEFT: #999 1px solid; COLOR: #fff; PADDING-TOP: 3px; BORDER-BOTTOM: #999 1px solid }
	SPAN.ErrorMessage { DISPLAY: block; FONT-WEIGHT: bold; COLOR: #904 }
	</style>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table id="tbAddFavorite" align="center" runat="server">
				<tr>
					<td>
						<div id="Main">
							<asp:label id="entryid" runat="server"></asp:label>
							<div id="Heading">��ѡ���ղ����:</div>
							<b>���±���:</b>&nbsp;<asp:label id="lbTitle" runat="server"></asp:label><br>
							<b>����:</b>&nbsp;<asp:label id="lbAuthor" runat="server"></asp:label>
							<asp:radiobuttonlist id="CategoryList" runat="server"></asp:radiobuttonlist><asp:checkbox id="ckbNewWindow" runat="server" Checked="True" Text="New Window"></asp:checkbox><br>
							<asp:button id="Submit" runat="server" Text="���" Width="60px"  CssClass="button"></asp:button>  <asp:button id="btnNewCategory" runat="server" Text="�½�����" Width="80px" CssClass="button"></asp:button><br>
							<br style="CLEAR: both">
							<asp:label id="Message" runat="server" CssClass="ErrorMessage" ForeColor="Red" FontBold="true"></asp:label>
						<asp:HyperLink ID="ReturnLink" runat="server">��������</asp:HyperLink>&nbsp;&nbsp;<asp:HyperLink ID="lnkEnterMyBlog" runat="server">�鿴�ҵ��ղؼ�</asp:HyperLink>
						</div>
					</td>
				</tr>
			</table>
			<table align="center" runat="server" id="tbCreateCategory" visible="false">
				<tr>
					<td>
						<div id="Main">
							<div id="Heading">�½��ղط���:</div>
							��������:<asp:TextBox ID="tbCategoryName" Runat="server" Width="150"></asp:TextBox><br>
							<br>
							<asp:button id="btnCreateCategory" runat="server" Text="���"  CssClass="button"></asp:button><br><br>
							<asp:button id="btnReturnBefore" runat="server" Text="����"  CssClass="button"></asp:button>
						</div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
