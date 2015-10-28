<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Int.WebUI.Pages.Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
 <head>
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <meta name="author" content="Chomo" />
  <title>中谊系统登陆介面</title>
  <style type="text/css">
ul { list-style:none; }
li { vertical-align:top; }
a { text-decoration:none; color:#6e6e6e; }
html,body{
    height: 100%;/*设置html和body的width和height为100%，可使全屏生效*/
    width: 100%;
    font-size: 16px;
    font-family: 微软雅黑, 宋体, 黑体;
    color: #535353;
    margin: 0px; /*设置上下左右的相对位置为0，可避免超出范围出现滚动条*/
    background-image: url(../content/login/bg.jpg);}

body {
    white-space: nowrap;/*设置white-space:nowrap，同时在相对参照元素中线居中时设定display:inline-block，可避免浏览器缩放时，垂直居中的容器换行*/
    text-align: center;/*设置text-align: center，可使子容器水平对齐*/
}

div {
    display: inline-block;/*div内联不换行，ie8和ie9不识别带*的样式，只执行第一个display，ie6和ie7识别带*的样式，执行第二个display和zoom*/
 *display:inline;/*ie6和ie7兼容display: inline-block，以【*display:inline;*zoom:1;】代替*/
 *zoom:1;
}

.verticalAlign {
    vertical-align: middle;/*设置vertical-align: middle，可使此和同一级别元素中线对齐*/
    height: 100%;
    width: 0px;    /*设置width:0px，可使此元素不显示，只为页面容器整体垂直对齐作参照*/
    border: none;
    padding: 0px;
    margin: 0px 0px 0px -5px;/*设置mrgin-right:-5px，避免容器横向超出*/
}


.divAll {
    width: 100%;
    height: auto;
    vertical-align: middle;/*设置vertical-align: middle，相对同一级别元素中线对齐*/
    margin: 0px;
    border: none;
    padding: 0px;
}


/*以上为父级垂直居中，以下为子级上中下排列*/

.divBody {
    width: 100%;
    width: 980px;
	height:480px;
    background-image: url(../content/login/loginbg.png);
    vertical-align: middle;/*设置vertical-align: middle，相对同一级别元素中线对齐*/
    margin: 0px;
    border: none;
    padding: 0px;
}
.divBody ul{ 
	 margin-top:140px;float:left; width:300px;
}
.divBody ul li{ height:50px; line-height:50px; text-align:left;}
.divBody ul li input { height:30px; width:240px; border:#a2d8eb solid 1px; line-height:30px; padding-left:10px; color:#12a4ea;}
.divBody ul li a{ background-image: url(../content/login/loginbut.png); width:70px; height:29px; display:block; line-height:29px; font-size:14px; color:#fff;text-align:center; margin-top:10px;}
.divBody ul li a:hover{ background-image: url(../content/login/loginbut2.png); }

.divTop {
   
    background-repeat: no-repeat;
    height: 61px;
    width: 80%;
    min-width: 980px;
    margin-left: auto;/*设置高度，并设置margin的left和right为auto，在非absolute情况下可水平居中*/
    margin-right: auto;
    vertical-align: top;/*设置vertical-align: top，相对同一级别元顶端对齐*/
    display: block;/*div内联换行*/
}


.divBottom {
    width: 100%;
    min-width: 980px;
    height: 100px;
    margin: 0px;
    vertical-align: bottom;/*设置vertical-align: bottom，相对同一级别元素底端对齐*/
    display: block;
}
.divleft{ width:450px; height:400px; float:left;}
  </style>
 </head>
 <body> 
 <div class="verticalAlign"></div><!--定位元素，页面不显示，只为页面容器整体垂直对齐作参照-->
  <div class="divAll"><!--父级垂直居中-->
    <form id="Form1" runat="server">
<!--子级上中下排列-->
        <div id='divTop' class="divTop">
        </div>
        <div id='divBody' class="divBody">
			<div class="divleft"></div>
			<ul>
				<li><asp:TextBox ID="txtUserName" Label="用户名" Required="true" runat="server" /></li>
				<li><asp:TextBox ID="txtPassword" Label="密&nbsp;&nbsp;&nbsp;码" TextMode="Password" Required="true" runat="server" onkeypress="enterLogin(event);" /></li>
				<li><asp:LinkButton ID="btnLogin" Text="登录" OnClick="btnLogin_Click" runat="server" Style="float:left"></asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbMsg" runat="server" Text="用户名或密码错误" Font-Size="Small" ForeColor="Red" Visible="false"></asp:Label></li>
			</ul>
		
        </div>
        <div id='divBottom' class="divBottom">
           
        </div>
    </form>
  </div>
    <script type="text/javascript">
        function enterLogin(e) {
            var keyCode = e.keyCode ? e.keyCode : e.which ? e.which : e.charCode;
            if (keyCode == 13) {
                __doPostBack('btnLogin', '')
            }
        }
    </script>
 </body>
</html>

