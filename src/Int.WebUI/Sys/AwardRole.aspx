<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AwardRole.aspx.cs" Inherits="Int.WebUI.Sys.AwardRole" %>

<!DOCTYPE html>
<html>
<head id="head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmPermissionRole" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px">
        <Toolbars>
            <f:Toolbar ID="tsMain" runat="server">
                <Items>
                    <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                    </f:Button>
                    <f:Button ID="btnSave" Text="保存" runat="server" ValidateForms="frmUser" ValidateMessageBox="false"
                        Icon="SystemSaveNew" OnClick="btnSave_Click">
                    </f:Button>
                    <f:ToolbarFill ID="ToolbarFill1" runat="server" />
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Panel ID="pnlForm" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <f:SimpleForm ID="frmUser" ShowBorder="false" ShowHeader="false"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <f:HiddenField ID="hiddenID" runat="server" />
                            <f:CheckBoxList ID="chkRole" runat="server" ColumnNumber="2" Label="系统角色" />
                        </Items>
                    </f:SimpleForm>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    </form>
</body>
</html>
