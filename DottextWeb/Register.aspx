<%@ Register TagPrefix="uc1" TagName="CityList" Src="Controls/CityList.ascx" %>
<%@ Page language="c#" Codebehind="Register.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Register" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�²���ע��</title>
		<style>BODY { PADDING-RIGHT: 32px; MARGIN-TOP: 10px; PADDING-LEFT: 32px; FONT-SIZE: 13px; BACKGROUND: #eee; PADDING-BOTTOM: 32px; MARGIN-LEFT: auto; WIDTH: 270px; COLOR: #000; MARGIN-RIGHT: auto; PADDING-TOP: 0px; FONT-FAMILY: arial }
	.DIV#Main { BORDER-RIGHT: #bbb 1px solid; PADDING-RIGHT: 32px; BORDER-TOP: #bbb 1px solid; PADDING-LEFT: 32px; BACKGROUND: #fff; PADDING-BOTTOM: 32px; BORDER-LEFT: #bbb 1px solid; PADDING-TOP: 32px; BORDER-BOTTOM: #bbb 1px solid }
	DIV#Heading { PADDING-RIGHT: 0px; PADDING-LEFT: 0px; FONT-WEIGHT: bold; FONT-SIZE: 150%; PADDING-BOTTOM: 18px; MARGIN: 0px; COLOR: #904; PADDING-TOP: 0px; FONT-FAMILY: "trebuchet ms", ""lucida grande"", verdana, arial, sans-serif }
	H2 { PADDING-RIGHT: 0px; PADDING-LEFT: 0px; FONT-WEIGHT: bold; FONT-SIZE: 105%; PADDING-BOTTOM: 0px; MARGIN: 0px 0px 8px; TEXT-TRANSFORM: uppercase; COLOR: #999; PADDING-TOP: 0px; BORDER-BOTTOM: #ddd 1px solid; FONT-FAMILY: "trebuchet ms", ""lucida grande"", verdana, arial, sans-serif }
	P { PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 6px; MARGIN: 0px; PADDING-TOP: 6px }
	.msgfont { FONT-SIZE: 12px; FONT-FAMILY: arial }
	A:link { COLOR: #002c99; TEXT-DECORATION: none }
	A:visited { COLOR: #002c99; TEXT-DECORATION: none }
	A:hover { COLOR: #cc0066; BACKGROUND-COLOR: #f5f5f5; TEXT-DECORATION: underline }
	LABEL { DISPLAY: block; FONT-WEIGHT: bold; FONT-SIZE: 12px; MARGIN: 6px 0px 2px; TEXT-TRANSFORM: uppercase; COLOR: #999 }
	.header { DISPLAY: block; FONT-WEIGHT: bold; FONT-SIZE: 14px; MARGIN: 6px 0px 2px; TEXT-TRANSFORM: uppercase; COLOR: #999 }
	INPUT.Textbox { PADDING-RIGHT: 2px; PADDING-LEFT: 2px; PADDING-BOTTOM: 2px; WIDTH: 200px; PADDING-TOP: 2px; FONT-FAMILY: verdana, arial, sans-serif }
	A.Button:link { BORDER-RIGHT: #999 1px solid; PADDING-RIGHT: 12px; BORDER-TOP: #999 1px solid; DISPLAY: block; PADDING-LEFT: 12px; FONT-WEIGHT: bold; BACKGROUND: #904; FLOAT: left; PADDING-BOTTOM: 3px; BORDER-LEFT: #999 1px solid; COLOR: #fff; PADDING-TOP: 3px; BORDER-BOTTOM: #999 1px solid }
	A.Button:visited { BORDER-RIGHT: #999 1px solid; PADDING-RIGHT: 12px; BORDER-TOP: #999 1px solid; DISPLAY: block; PADDING-LEFT: 12px; FONT-WEIGHT: bold; BACKGROUND: #904; FLOAT: left; PADDING-BOTTOM: 3px; BORDER-LEFT: #999 1px solid; COLOR: #fff; PADDING-TOP: 3px; BORDER-BOTTOM: #999 1px solid }
	SPAN.ErrorMessage { DISPLAY: block; FONT-WEIGHT: bold; COLOR: #904 }
	P.Small { MARGIN-TOP: 12px; FONT-SIZE: 85% }
	</style>
	</HEAD>
	<body>
		<form id="frmRegister" method="post" runat="server">
			<table width="400" align="center">
				<tr>
					<td class="header" align="center">�²���ע��(*Ϊ������)
					</td>
				</tr>
				<tr>
					<td class="header" align="center">����:����վ��רע��Java�����Ĳ�����վ��</td>
				</tr>
				<tr>
					<td><LABEL class="Block">�ʺ�(��֧������)</LABEL>
						<asp:textbox id="txbUser" runat="server" width="400"></asp:textbox>*
						<asp:requiredfieldvalidator id="RequiredFieldValidator_txbUser" runat="server" CssClass="msgfont" ErrorMessage="�ʺŲ���Ϊ��"
							ControlToValidate="txbUser"></asp:requiredfieldvalidator>
						<LABEL class="Block">����</LABEL>
						<asp:textbox id="txbPwd" runat="server" width="400" TextMode="Password"></asp:textbox>*
						<asp:requiredfieldvalidator id="Requiredfieldvalidator_txbPwd" runat="server" CssClass="msgfont" ErrorMessage="���벻��Ϊ��"
							ControlToValidate="txbPwd"></asp:requiredfieldvalidator>
						<LABEL class="Block">ȷ������</LABEL>
						<asp:textbox id="txbPwd2" runat="server" width="400" TextMode="Password"></asp:textbox>*
						<asp:CompareValidator id="CompareValidator_Pwd" runat="server" ErrorMessage="���벻һ��" ControlToValidate="txbPwd2"
							ControlToCompare="txbPwd"></asp:CompareValidator>
						<LABEL class="Block">��ʾ����</LABEL>
						<asp:textbox id="txbAuthor" runat="server" width="400"></asp:textbox>*
						<asp:requiredfieldvalidator id="Requiredfieldvalidator_txbAuthor" runat="server" CssClass="msgfont" ErrorMessage="��ʾ���Ʋ���Ϊ��"
							ControlToValidate="txbAuthor"></asp:requiredfieldvalidator>
						<LABEL class="Block">��ϵ�ʼ�</LABEL>
						<asp:textbox id="txbEmail" runat="server" width="400"></asp:textbox>*
						<asp:requiredfieldvalidator id="Requiredfieldvalidator_txbEmail" runat="server" CssClass="msgfont" ErrorMessage="��ϵ�ʼ�����Ϊ��"
							ControlToValidate="txbEmail"></asp:requiredfieldvalidator>
						<LABEL class="Block">����(��Ϊ��,������ʾ���Ʊ�ʾ)</LABEL>
						<asp:textbox id="txbTitle" runat="server" width="400"></asp:textbox>
						<LABEL class="Block">����</LABEL>
						<asp:textbox id="txbSubtitle" runat="server" width="400"></asp:textbox>
						<LABEL class="Block">����</LABEL>
						<uc1:CityList id="CityList1" runat="server"></uc1:CityList>
						<LABEL class="Block">Skin</LABEL>
						<asp:DropDownList id="ddlSkin" runat="server"></asp:DropDownList></td>
				</tr>
				<tr>
					<td align="center"><asp:linkbutton id="Linkbutton1" runat="server" CssClass="Button" Text="ע��"></asp:linkbutton></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
