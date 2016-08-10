<?xml version="1.0" encoding="GB2312"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html"/>
<xsl:template match="Logs">
<style type="text/css">

 A:link {text-decoration: underline; color: "green";font-size: 9pt}
        A:visited {text-decoration:underline; color: "green"}
        A:active {text-decoration: underline}
        A:hover {text-decoration: underline; color: "f00000"}
table {  font-family: "Arial"; font-size: 9pt}
</style>
<table width="100%" align="center">
<tr>
<td align="center">博客园日志</td> 
</tr>
</table>

<table width="100%" border="0" bgcolor="#8EBDF0" cellpadding="0" cellspacing="1" align="center">
 
  <tr align="center" bgcolor="#3399CC">
    <td width="20%" height="20">标题</td>
    <td >内容</td>
     <td width="15%">开始时间</td>
    <td width="15%">结束时间</td>
  </tr>
<xsl:for-each select="Log">
 <tr> 
    
    <td bgcolor="#FFFFFF" height="20"><xsl:value-of select='Title'/></td>
    <td bgcolor="#FFFFFF" ><xsl:value-of select="Message"/></td>
     <td bgcolor="#FFFFFF" align="center"><xsl:value-of select="substring(StartDate,1,19)"/></td>
    <td bgcolor="#FFFFFF" align="center"><xsl:value-of select="substring(EndDate,1,19)"/></td>
  </tr>
</xsl:for-each> 

 </table>
</xsl:template>
</xsl:stylesheet>