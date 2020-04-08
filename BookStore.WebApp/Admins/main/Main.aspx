<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="BookStore.WebApp.Admins.main.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<frameset rows="88,*" cols="*" frameborder="no" border="0" framespacing="0">
    <frame src="Top.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" title="topFrame" />
    <frameset cols="187,*" frameborder="no" border="0" framespacing="0">
        <frame src="Left.aspx" name="leftFrame" scrolling="No" noresize="noresize" id="leftFrame" title="leftFrame" />
        <frame src="Index.aspx" name="rightFrame" id="rightFrame" title="rightFrame" />
    </frameset>
</frameset>
<noframes><body>
    </body></noframes>
</html>
