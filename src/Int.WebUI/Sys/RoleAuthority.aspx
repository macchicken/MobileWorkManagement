<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleAuthority.aspx.cs" Inherits="Int.WebUI.Sys.RoleAuthority" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
    <style>
        .f-grid-tpl .hobby input
        {
            vertical-align: middle;
        }
        .f-grid-tpl .hobby label
        {
            margin-left: 5px;
            margin-right: 10px;
        }
    </style>
</head>
<body>
    <form id="frmPermissionRole" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" BodyPadding="3px"
        Icon="feed" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <f:Panel ID="pnlRoleGrid" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit" runat="server">
                <Toolbars>
                    <f:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <f:Button ID="btnSelectAll" Icon="ArrowIn" Text="全选" runat="server" OnClick="btnSelectAll_Click" />
                            <f:Button ID="btnPermission" Icon="SystemSaveNew" Text="授权" runat="server" OnClick="btnAwardRole_Click" />
                            <f:Button ID="btnRefresh" Icon="ArrowRefresh" OnClick="btnRefresh_Click" Text="刷新" runat="server" />
                        </Items>
                    </f:Toolbar>
                </Toolbars>
                <Items>
                    <f:Grid ID="authorityGrid" Title="功能权限" ShowBorder="false" ShowHeader="False" EnableMultiSelect="True" AllowPaging="false" 
                        AllowSorting="false" runat="server" DataKeyNames="Id" OnRowDataBound="authorityGrid_RowDataBound">
                        <Columns>
                            <f:BoundField Width="250px" ColumnID="Text" SortField="Text" DataField="Text" HeaderText="模块名" DataSimulateTreeLevelField="TreeLevel" />
                            <f:TemplateField Width="500px" HeaderText="权限">
                                <ItemTemplate>
                                    <asp:CheckBoxList runat="server" CssClass="hobby" RepeatLayout="Flow" RepeatColumns="5"  RepeatDirection="Horizontal" ID="chkAuthority">
                                    </asp:CheckBoxList>
                                </ItemTemplate>
                            </f:TemplateField>
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    </form>
</body>
</html>
