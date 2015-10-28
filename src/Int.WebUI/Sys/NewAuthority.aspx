﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewAuthority.aspx.cs" Inherits="Int.WebUI.Sys.NewAuthority" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmNewAuthority" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px">
        <Toolbars>
            <f:Toolbar ID="tsMain" runat="server">
                <Items>
                    <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                    <f:Button ID="btnSave" Text="保存" runat="server" Icon="SystemSaveNew" ValidateForms="frmAuthority"
                        ValidateMessageBox="false" OnClick="btnSave_Click" />
                    <f:ToolbarFill ID="ToolbarFill1" runat="server" />
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Panel ID="pnlModule" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <f:SimpleForm ID="frmAuthority" ShowBorder="false" ShowHeader="false"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <f:TextBox ID="txtCode" Label="编码" Required="true" runat="server" />
                            <f:TextBox ID="txtName" Label="权限名" Required="true" runat="server" />
                            <f:HiddenField ID="hiddenModuleID" Text="0" runat="server" />
                            <f:TriggerBox ID="txtModule" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                Label="系统模组" runat="server" Required="true" />
                        </Items>
                    </f:SimpleForm>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    <f:Window ID="wdnSelectModule" Title="选择模组" OnClose="subwin_Close" EnableMaximize="true" IsModal="true" Hidden="true"
       Target="Parent" EnableResize="true" runat="server" Icon="Find" Width="310px" Height="435px" EnableIFrame="true">
    </f:Window>
    </form>
</body>
</html>
