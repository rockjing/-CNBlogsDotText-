<script language="JavaScript">
function EnterPost()
{
	if(event.keyCode==13)
		{	
			
			document.Form1.submit();
		}
}

function Search(key)
{
	var url=encodeURIComponent(key);
	url="search.aspx?q="+url;
	window.location=url;
}
</script>