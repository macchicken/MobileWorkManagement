<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="Int.WebUI.Sys.RoleList" %>
<%@ Register Src="../Controls/PageAuthorityControl.ascx" TagName="PageAuthority" TagPrefix="uc1" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmRole" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" BodyPadding="3px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <f:Form ID="frmFind" ShowBorder="False" BodyPadding="5px" ShowHeader="False" runat="server">
                <Rows>
                    <f:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <f:TwinTriggerBox runat="server" ShowLabel="false" ID="ttbSearch" Width="200" ShowTrigger1="false"
                                OnTrigger1Click="ttbSearch_Trigger1Click" OnTrigger2Click="ttbSearch_Trigger2Click"
                                Trigger1Icon="Clear" Trigger2Icon="Search">
                            </f:TwinTriggerBox>
                        </Items>
                    </f:FormRow>
                </Rows>
            </f:Form>
            <f:Panel ID="pnlRoleList" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit" runat="server">
                <Toolbars>
                    <f:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <f:Button ID="btnNew" Icon="Add" Text="新增" runat="server" />
                            <f:Button ID="btnModify" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModify_Click" />
                            <f:Button ID="btnPermissionRole" Icon="UserTick" Text="授权" runat="server" OnClick="btnPermissionRole_Click" />
                            <f:Button ID="btnUserRole" Icon="User" Text="分配用户" runat="server" OnClick="btnUserRole_Click" />
                        </Items>
                    </f:Toolbar>
                </Toolbars>
                <Items>
                    <f:Grid ID="roleGrid" Title="角色" ShowBorder="false" ShowHeader="False" runat="server" OnRowCommand="roleGrid_RowCommand"
                        PageSize="50" AllowPaging="true" OnPageIndexChange="roleGrid_PageIndexChange" IsDatabasePaging ="true" DataKeyNames="Id,Name,IsSystem">
                        <Columns>
                            <f:BoundField Width="200px" ColumnID="Name" SortField="Name" DataField="Name"
                                HeaderText="角色名称" />
                            <f:BoundField Width="100px" ColumnID="Sort" SortField="Sort" DataField="Sort"
                                HeaderText="排序" />
                            <f:CheckBoxField Width="100px" ColumnID="UseAble" SortField="UseAble" TextAlign="Center"
                                RenderAsStaticField="true" DataField="UseAble" HeaderText="是否可用" />
                            <f:WindowField TextAlign="Center" Width="60px" WindowID="modifyRoleWin" Icon="Pencil"
                                ColumnID="btnModify" DataIFrameUrlFields="Id" DataIFrameUrlFormatString="ModifyRole.aspx?id={0}"
                                DataWindowTitleField="Name" DataWindowTitleFormatString="编辑-{0}" />
                            <f:LinkButtonField TextAlign="Left" Width="60px" Icon="Delete" ColumnID="btnDelete"
                                ConfirmText="确认删除吗？" CommandName="delete" ExpandUnusedSpace="true" />
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    <f:Window ID="newRoleWin" Title="新增" IFrameUrl="NewRole.aspx" Hidden="true" EnableIFrame="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" EnableConfirmOnClose="true" 
        Icon="Add" Width="500px" Height="200px" OnClose="subwin_Close">
    </f:Window>
    <f:Window ID="modifyRoleWin" Title="编辑" IsModal="true" Hidden="true" EnableConfirmOnClose="true" EnableIFrame="true"
        Target="Parent" EnableResize="true" runat="server" Icon="ApplicationEdit" Width="500px" Height="200px" OnClose="subwin_Close">
    </f:Window>
    <f:Window ID="modifyPermissionRoleWin" Title="授权" Hidden="true" EnableIFrame="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" EnableConfirmOnClose="true" 
        Icon="UserTick" Width="800px" Height="550px" OnClose="subwin_Close">
    </f:Window>
    <f:Window ID="viewUserWin" Title="用户" Hidden="true" EnableIFrame="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" EnableConfirmOnClose="true" 
        Icon="User" Width="800px" Height="550px" OnClose="subwin_Close">
    </f:Window>
    <uc1:PageAuthority ID="pageAuthority" PageAuthority='["btnNew","btnModify","btnPermissionRole","btnUserRole"]'
        runat="server" />
    </form>
</body>
</html>
