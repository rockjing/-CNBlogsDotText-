<script language="JavaScript">
function Search(url,key)
		{
			if(event.keyCode==13 || event.keyCode==0)
			{
				key.focus();
				var keystr=encodeURIComponent(key.value);
				url=url+keystr;
				event.keyCode = 9;
				window.location=url;
				return;
			}
		}
</script>
