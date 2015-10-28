<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectMenu.aspx.cs" Inherits="Int.WebUI.Sys.SelectMenu" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmNotNeedCheck" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" ShowBorder="false" Layout="Fit" BoxConfigAlign="Stretch"
        BoxConfigPosition="Start" BoxConfigPadding="0" ShowHeader="false">
        <Toolbars>
            <f:Toolbar ID="tsbMain" runat="server">
                <Items>
                    <f:Button ID="btnEnter" Icon="SystemSaveNew" Text="确定" OnClick="btnEnter_Click" runat="server" />
                    <f:Button ID="btnCancel" Icon="SystemClose" Text="取消选择" runat="server" OnClick="btnCancel_Click" />
                    <f:Button ID="btnExpandAll" Icon="Folder" Text="展开" OnClick="btnExpandAll_Click"
                        runat="server" />
                    <f:Button ID="btnCollapseAll" Icon="FolderUp" Text="收起" OnClick="btnCollapseAll_Click"
                        runat="server" />
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Tree runat="server" ID="tvwMenu" AutoScroll="true" EnableIcons="false" Expanded="true"
                Title="系统菜单" ShowHeader="false" ShowBorder="false">
            </f:Tree>
        </Items>
    </f:Panel>
    </form>
</body>
</html>
