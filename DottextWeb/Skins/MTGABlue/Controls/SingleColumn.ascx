<%@ Import Namespace = "Dottext.Framework" %>
<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.SingleColumn" %>
<%@ Register TagPrefix="uc1" TagName="CategoryList" Src="CategoryList.ascx" %>
<uc1:CategoryList id="Categories" runat="server"></uc1:CategoryList>
<br>
<p align="center"><asp:HyperLink ImageUrl="http://www.roudybob.net/images/DotTextSkin.gif" NavigateUrl="http://www.roudybob.net/category/12.aspx" target="_blank" Runat="server" ID="Hyperlink4" NAME="Hyperlink4"/></p>
