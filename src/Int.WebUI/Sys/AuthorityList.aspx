<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthorityList.aspx.cs" Inherits="Int.WebUI.Sys.AuthorityList" %>
<%@ Register Src="../Controls/PageAuthorityControl.ascx" TagName="PageAuthority" TagPrefix="uc1" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmAuthority" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:RegionPanel ID="pnlMain" ShowBorder="false" runat="server">
        <Regions>
            <f:Region ID="pnlLeft" Split="true"
                Width="200px" ShowHeader="true" Title="系统模组"
                Icon="Outline" EnableCollapse="true" Layout="Fit" Position="Left" runat="server">
                <Toolbars>
                    <f:Toolbar ID="toolbar" Position="Top" runat="server">
                        <Items>
                            <f:Button ID="btnExpandAll" Icon="FolderAdd" Text="展开" runat="server" OnClick="btnExpandAll_Click" />
                            <f:Button ID="btnCollapseAll" Icon="FolderEdit" Text="收起" runat="server" OnClick="btnCollapseAll_Click" />
                        </Items>
                    </f:Toolbar>
                </Toolbars>
                <Items>
                    <f:Tree runat="server" ID="tvwModule" EnableArrows="false" AutoScroll="true" EnableIcons="false" ShowBorder="false"
                        Title="模组" OnNodeCommand="tvwModule_NodeCommand" Expanded="true" ShowHeader="false">
                    </f:Tree>
                </Items>
            </f:Region>
            <f:Region ID="pnlRight" ShowHeader="true" Layout="Fit" Position="Center"
                Icon="Outline" Title="权限信息" runat="server">
                <Items>
                    <f:Panel ID="pnlAuthority" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                        runat="server">
                        <Toolbars>
                            <f:Toolbar ID="tsbMain" runat="server">
                                <Items>
                                    <f:Button ID="btnNew" Icon="Add" Text="新增" runat="server" />
                                    <f:Button ID="btnModify" Icon="ApplicationEdit" OnClick="btnModify_Click" Text="编辑"
                                        runat="server" />
                                </Items>
                            </f:Toolbar>
                        </Toolbars>
                        <Items>
                            <f:Grid ID="authorityGrid" Title="权限信息" ShowBorder="false" ShowHeader="False" runat="server" DataKeyNames="Id,Name">
                                <Columns>
                                    <f:BoundField Width="200px" ColumnID="ModuleText" SortField="ModuleText" DataField="ModuleText" HeaderText="系统模组" />
                                    <f:BoundField Width="150px" ColumnID="Code" SortField="Code" DataField="Code"
                                        HeaderText="编码" />
                                    <f:BoundField Width="200px" ColumnID="Name" SortField="Name" DataField="Name"
                                        HeaderText="权限名" />
                                    <f:WindowField TextAlign="Left" Width="60px" WindowID="modifyAuthorityWin" Icon="Pencil"
                                        ToolTip="编辑" DataIFrameUrlFields="Id" DataIFrameUrlFormatString="ModifyAuthority.aspx?id={0}"
                                        DataWindowTitleFormatString="编辑-{0}" DataWindowTitleField="Name" ExpandUnusedSpace="true" />
                                </Columns>
                            </f:Grid>
                        </Items>
                    </f:Panel>
                </Items>
            </f:Region>
        </Regions>
    </f:RegionPanel>
    <f:Window ID="newAuthorityWin" Title="新增" OnClose="subwin_Close" EnableMaximize="false" IsModal="true"
       Target="Parent" EnableResize="false" runat="server" Icon="Add" Width="500px" Hidden="true" 
        Height="200px" EnableConfirmOnClose="true" EnableIFrame="true" IFrameUrl="NewAuthority.aspx">
    </f:Window>
    <f:Window ID="modifyAuthorityWin" Title="编辑" OnClose="subwin_Close" EnableMaximize="true" IsModal="false"
       Target="Parent" EnableResize="true" runat="server" Icon="Pencil" Width="500px" Hidden="true"
        Height="200px" EnableConfirmOnClose="true" EnableIFrame="true">
    </f:Window>
    <uc1:PageAuthority ID="pageAuthority" PageAuthority='["btnNew","btnModify","btnDelete"]' runat="server" />
    </form>
</body>
</html>
