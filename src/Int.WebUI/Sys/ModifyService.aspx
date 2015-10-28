<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyService.aspx.cs" Inherits="Int.WebUI.Sys.ModifyService" %>

<!DOCTYPE html>
<html>
<head id="head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmModifyService" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px">
        <Toolbars>
            <f:Toolbar ID="tsMain" runat="server">
                <Items>
                    <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose"/>
                    <f:Button ID="btnSave" Text="保存" runat="server" Icon="SystemSaveNew" ValidateForms="frmService"
                        ValidateMessageBox="false" OnClick="btnSave_Click"/>
                    <f:ToolbarFill ID="ToolbarFill1" runat="server" />
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Panel ID="pnlForm" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <f:SimpleForm ID="frmService" ShowBorder="false" ShowHeader="false" AutoScroll="true" 
                        BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <f:Label ID="txtId" Label="服务编号" runat="server"  />
                            <f:TextBox ID="txtName" Label="服务名称" Required="true" runat="server" />
                            <f:TextBox ID="txtSort" Label="排序值" Required="true" runat="server" />
                            <f:TextBox ID="txtUrl" Label="Url" Required="true" runat="server" />
                        </Items>
                    </f:SimpleForm>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    </form>
</body>
</html>
