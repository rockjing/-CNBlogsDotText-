<script language="javascript">

function returnCode() 
{	
	str=document.Form1.CodeTextBox.Value;
	if(str=='')
	{
	str='null';
	}
	window.parent.returnValue = str;
	window.parent.close();	
}		
</script>		

