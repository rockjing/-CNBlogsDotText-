<script language="javascript">
function setCookie(name, value, expires, path, domain, secure) 
{
  var today = new Date();
  var expiry = new Date(today.getTime() + 7 * 24 * 60 * 60 * 1000);
  if(expires==''||expires==null)
  {
	expires=expiry;
  }
   
  var curCookie = name + "=" + escape(value) +
      ((expires) ? "; expires=" + expires.toGMTString() : "") +
      ((path) ? "; path=" + path : "") +
      ((domain) ? "; domain=" + domain : "") +
      ((secure) ? "; secure" : "");
  document.cookie = curCookie;
  
}

function getCookie(name) 
{
  var dc = document.cookie;
  var prefix = name + "=";
  var begin = dc.indexOf("; " + prefix);
  if (begin == -1) 
  {
    begin = dc.indexOf(prefix);
    if (begin != 0) return null;
  } else
    begin += 2;
  var end = document.cookie.indexOf(";", begin);
  if (end == -1)
    end = dc.length;
  return unescape(dc.substring(begin + prefix.length, end));
}

</script>

