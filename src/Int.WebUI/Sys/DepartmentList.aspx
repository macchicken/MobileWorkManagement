<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentList.aspx.cs" Inherits="Int.WebUI.Sys.DepartmentList" %>
<%@ Register Src="../Controls/PageAuthorityControl.ascx" TagName="PageAuthority" TagPrefix="uc1" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmDepartment" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" BodyPadding="3px"
        ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <f:Panel ID="pnlDepartment" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                runat="server">
                <Toolbars>
                    <f:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <f:Button ID="btnNew" Icon="Add" Text="新增" runat="server" />
                            <f:Button ID="btnModify" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModify_Click" />
                            <f:Button ID="btnDepartmentUser" Icon="User" Text="用户" runat="server" OnClick="btnDepartmentUser_Click" />
                        </Items>
                    </f:Toolbar>
                </Toolbars>
                <Items>
                    <f:Grid ID="departmentGrid" Title="部门信息" ShowBorder="false" ShowHeader="False" runat="server"
                        DataKeyNames="Id,Name" OnRowCommand="departmentGrid_RowCommand"  OnRowDataBound="departmentGrid_RowDataBound"
                        EnableRowDoubleClickEvent="true" OnRowDoubleClick="departmentGrid_RowDoubleClick">
                        <Columns>
                            <f:BoundField ColumnID="Name" SortField="Name" DataField="Name" DataSimulateTreeLevelField="TreeLevel"
                                HeaderText="部门名称" Width="300px" />
                            <f:BoundField ColumnID="Id" SortField="Id" DataField="Id" HeaderText="编号" Width="100px" />
                            <f:TemplateField Width="500px" HeaderText="用户">
                                <ItemTemplate>
                                    <asp:Repeater id="rptUser" runat="server">
                                        <SeparatorTemplate>,</SeparatorTemplate>
                                        <ItemTemplate>
                                           <%# Eval("Name") %>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ItemTemplate>
                            </f:TemplateField>
                            <f:WindowField ColumnID="btnModify" TextAlign="Center" WindowID="modifyDepartmentWin"
                                DataIFrameUrlFields="Id" DataIFrameUrlFormatString="ModifyDepartment.aspx?id={0}"
                                DataWindowTitleField="Name" DataWindowTitleFormatString="编辑-{0}" Icon="Pencil"
                                Width="60px" />
                            <f:LinkButtonField ColumnID="btnDelete" TextAlign="Left" Width="60px" Icon="Delete"
                                ConfirmText="确认删除吗？" CommandName="delete" ExpandUnusedSpace="true" />
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    <f:Window ID="newDepartmentWin" Title="新增" OnClose="subwin_Close" IFrameUrl="NewDepartment.aspx"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Hidden="true" EnableIFrame="true"
        Icon="Add" Width="500px" Height="200px" EnableConfirmOnClose="true">
    </f:Window>
    <f:Window ID="modifyDepartmentWin" Title="编辑" OnClose="subwin_Close" EnableIFrame="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Icon="Pencil" Hidden="true"
        Width="500px" Height="200px" EnableConfirmOnClose="true">
    </f:Window>
    <f:Window ID="viewUserWin" Title="用户" Hidden="true" EnableIFrame="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" EnableConfirmOnClose="true" 
        Icon="User" Width="800px" Height="550px" OnClose="subwin_Close">
    </f:Window>
    <uc1:PageAuthority ID="pageAuthority" PageAuthority='["btnNew","btnModify","btnDelete", "btnDepartmentUser"]'
        runat="server" />
    </form>
</body>
</html>
