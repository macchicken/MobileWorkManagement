<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePwd.aspx.cs" Inherits="Int.WebUI.Sys.ChangePwd" %>

<!DOCTYPE html>
<html>
<head id="head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmChangePwdUser" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px">
        <Toolbars>
            <f:Toolbar ID="tsMain" runat="server">
                <Items>
                    <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                    </f:Button>
                    <f:Button ID="btnSave" Text="确定" runat="server" ValidateForms="frmPwd" ValidateMessageBox="false"
                        Icon="SystemSaveNew" OnClick="btnSave_Click">
                    </f:Button>
                    <f:ToolbarFill ID="ToolbarFill1" runat="server" />
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Panel ID="pnlForm" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <f:SimpleForm ID="frmPwd" ShowBorder="false" ShowHeader="false"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <f:HiddenField ID="hiddenID" runat="server" />
                            <f:TextBox ID="txtPassword1" Label="密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码" TextMode="Password"
                                Required="true" runat="server" MinLength="6" />
                            <f:TextBox ID="txtPassword2" Label="重复密码" TextMode="Password" Required="true" runat="server"
                                CompareOperator="Equal" CompareMessage="两次密码不一致！" CompareControl="txtPassword1" />
                        </Items>
                    </f:SimpleForm>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    </form>
</body>
</html>
