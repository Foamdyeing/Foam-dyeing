<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BookStore.WebApp.Admins.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>图书商城后台管理登入界面</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript" src="js/jquery.js"></script>
    <script src="js/cloud.js" type="text/javascript"></script>

    <script language="javascript">
        $(function(){
            $('.loginbox').css({'position':'absolute','left':($(window).width()-692)/2});
            $(window).resize(function(){  
                $('.loginbox').css({'position':'absolute','left':($(window).width()-692)/2});
            })  
        });  
    </script> 
</head>
<body style="background-color:#1c77ac; background-image:url(images/light.png); background-repeat:no-repeat; background-position:center top; overflow:hidden;">
    <form id="form1" runat="server">
       


        <div id="mainBody">
            <div id="cloud1" class="cloud"></div>
            <div id="cloud2" class="cloud"></div>
        </div>  


        <div class="logintop">    
            <span>欢迎登录后台管理界面平台</span>    
            <ul>
                <li><a href="#">回首页</a></li>
                <li><a href="#">帮助</a></li>
                <li><a href="#">关于</a></li>
            </ul>    
        </div>
    
        <div class="loginbody">
    
            <span class="systemlogo"></span> 
       
            <div class="loginbox">
    
                <ul>
                    <li>
                        <asp:TextBox ID="txtAccount" CssClass="loginuser" runat="server"></asp:TextBox>
                    </li>
                    <li>
                        <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="loginpwd" runat="server"></asp:TextBox>
                    </li>
                    <li>
                        <asp:Button ID="btnSubmit" runat="server" Text="登录" cssClass="loginbtn" OnClick="btnSubmit_OnClick" OnClientClick="return ValidateRequired()" />
                        <label>
                            <asp:CheckBox ID="ckbRememberMe" runat="server" />记住密码</label>
                        <label><a href="#">忘记密码？</a></label>
                    </li>
                </ul>
                <script>
                    function ValidateRequired() {
                        if ($("#txtAccount").val() != "" && $("#txtPassword").val() != "") {
                            return true;
                        } else {
                            alert('账号或者密码不能为空');
                            return false;
                        }
                    }

                </script>
    
            </div>
    
        </div>
    
        <!--
            onClick 它是我们服务器控件的点击事件,能够生成后台的操作代码
            onClientClick 它是客户端的点击事件,主要做的是 js验证,需要我们手动写js方法,一般这个方法需要带有一个bool类型的返回值
        -->
    
        <div class="loginbm">版权所有 &copy; 北大青鸟所有 2020-2021
        </div>
    </form>
</body>
</html>
