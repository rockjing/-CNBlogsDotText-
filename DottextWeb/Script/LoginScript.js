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
       	if(element.name=='tbUserName')//tbUserName-�û����ı����Name
		{
			document.frmLogin.tbPassword.focus();//frmLogin-������,tbPassword-�����ı��ܵ�Name
		}
		if(element.name=='tbPassword')
		{
			//document.frmLogin.submit();�����ַ�ʽ�ύ,Asp.netҳ�����һ��,��ʵ�ʲ�δ�ύ
			//������Ĵ�������ύ,���Ǵ�asp.net���ɵ�ҳ���в鿴Դ�ļ�Ȼ���Ƴ�����
			if (typeof(Page_ClientValidate) != 'function' ||  Page_ClientValidate()) __doPostBack('lblLogin','');
		}
	}
}

</script>
