<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="Int.WebUI.Sys.MenuList" %>
<%@ Register Src="../Controls/PageAuthorityControl.ascx" TagName="PageAuthority" TagPrefix="uc1" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmMenu" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" BodyPadding="3px"
        Icon="Outline" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch"
        Title="系统菜单">
        <Items>
            <f:Panel ID="pnlMenu" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit" runat="server">
                <Toolbars>
                    <f:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <f:Button ID="btnNew" Icon="Add" Text="新增" runat="server" />
                            <f:Button ID="btnModify" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModify_Click" />
                        </Items>
                    </f:Toolbar>
                </Toolbars>
                <Items>
                    <f:Grid ID="menuGrid" Title="系统菜单" ShowBorder="false" ShowHeader="False" runat="server" DataKeyNames="Id,Text"
                        OnRowCommand="menuGrid_RowCommand">
                        <Columns>
                            <f:BoundField Width="190px" ColumnID="Text" DataField="Text" DataSimulateTreeLevelField="TreeLevel"
                                HeaderText="菜单标题" />
                            <f:CheckBoxField Width="120px" ColumnID="IsWebMenu" SortField="IsWebMenu" TextAlign="Center"
                                RenderAsStaticField="true" DataField="IsWebMenu" HeaderText="是否Web端菜单" />
                            <f:BoundField Width="200px" ColumnID="NavigateUrl" DataField="NavigateUrl"
                                HeaderText="Web地址" />
                            <f:CheckBoxField Width="120px" ColumnID="IsMobileMenu" SortField="IsMobileMenu" TextAlign="Center"
                                RenderAsStaticField="true" DataField="IsMobileMenu" HeaderText="是否移动端菜单" />
                            <f:BoundField Width="200px" ColumnID="MobileUrl" DataField="MobileUrl"
                                HeaderText="移动地址" />
                            <f:BoundField Width="60px" ColumnID="Sort" DataField="Sort"
                                HeaderText="排序" />
                            <f:CheckBoxField Width="80px" ColumnID="UseAble" SortField="UseAble" TextAlign="Center"
                                RenderAsStaticField="true" DataField="UseAble" HeaderText="是否可用" />
                            <f:WindowField TextAlign="Center" Width="60px" WindowID="modifyMenuWin" Icon="Pencil" ToolTip="编辑"
                                DataIFrameUrlFields="Id" DataIFrameUrlFormatString="ModifyMenu.aspx?id={0}"
                                DataWindowTitleFormatString="编辑-{0}" DataWindowTitleField="Text" />
                            <f:LinkButtonField TextAlign="Left" Width="60px" Icon="Delete" ToolTip="删除" ConfirmText="确认删除吗？"
                                CommandName="delete" ExpandUnusedSpace="true" />
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    <f:Window ID="newMenuWin" Title="新增" OnClose="subwin_Close" EnableMaximize="true" IsModal="true"
       Target="Parent" EnableResize="true" runat="server" Icon="Add" Width="500px" Hidden="true"
        Height="350px" EnableConfirmOnClose="true" EnableIFrame="true" IFrameUrl="NewMenu.aspx">
    </f:Window>
    <f:Window ID="modifyMenuWin" Title="编辑" OnClose="subwin_Close" EnableMaximize="true" IsModal="false"
       Target="Parent" EnableResize="true" runat="server" Icon="Pencil" Width="500px" Hidden="true"
        Height="350px" EnableConfirmOnClose="true" EnableIFrame="true">
    </f:Window>
    <uc1:PageAuthority ID="pageAuthority" PageAuthority='["btnNew","btnModify","btnDelete"]' runat="server" />
    </form>
</body>
</html>
