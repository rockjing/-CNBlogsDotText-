<script language="JavaScript">
NS4 = (document.layers) ? true : false;
function checkEnter(event,element)
{     
    var code = 0;
    if (NS4)
        code = event.which;
    else
        code = event.keyCode;
    if (code==13)
	{
       	if(element.name=='tbUserName')//tbUserName-用户名文本框的Name
		{
			document.frmLogin.tbPassword.focus();//frmLogin-表单名称,tbPassword-密码文本杠的Name
		}
		if(element.name=='tbPassword')
		{
			//document.frmLogin.submit();用这种方式提交,Asp.net页面会闪一下,但实际并未提交
			//用下面的代码才能提交,我是从asp.net生成的页面中查看源文件然后复制出来的
			if (typeof(Page_ClientValidate) != 'function' ||  Page_ClientValidate()) __doPostBack('lblLogin','');
		}
	}
}

</script>
