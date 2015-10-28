<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceList.aspx.cs" Inherits="Int.WebUI.Sys.ServiceList" %>
<%@ Register Src="../Controls/PageAuthorityControl.ascx" TagName="PageAuthority" TagPrefix="uc1" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmService" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" BodyPadding="3px" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <f:Panel ID="pnlService" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                runat="server">
                <Toolbars>
                    <f:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <f:Button ID="btnNew" Icon="Add" Text="新增" runat="server" />
                            <f:Button ID="btnModify" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModify_Click" />
                        </Items>
                    </f:Toolbar>
                </Toolbars>
                <Items>
                    <f:Grid ID="serviceGrid" Title="服务信息" EnableFrame="false" EnableCollapse="true" ShowBorder="false" ShowHeader="False"
                        runat="server" EnableCheckBoxSelect="false" DataKeyNames="Id,Name"
                        EnableRowDoubleClickEvent="true" OnRowDoubleClick="serviceGrid_RowDoubleClick">
                        <Columns>
                            <f:BoundField ColumnID="Id" SortField="Id" DataField="Id" HeaderText="编号" Width="60px" />
                            <f:BoundField ColumnID="Name" SortField="Name" DataField="Name" HeaderText="名称" Width="300px" />
                            <f:BoundField ColumnID="Sort" SortField="Sort" DataField="Sort" HeaderText="排序值" Width="60px" />
                            <f:BoundField ColumnID="Url" SortField="Url" DataField="Url" HeaderText="Url" Width="300px" />
                            <f:BoundField ColumnID="FilePath" SortField="FilePath" DataField="FilePath" HeaderText="文件路径" Width="200px" />
                            <f:WindowField ColumnID="btnModify" TextAlign="Left" WindowID="modifyServiceWin"
                                DataIFrameUrlFields="Id" DataIFrameUrlFormatString="ModifyService.aspx?id={0}"
                                DataWindowTitleField="Name" DataWindowTitleFormatString="编辑-{0}" Icon="Pencil"
                                width="60px" ExpandUnusedSpace="true" />
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    <f:Window ID="newServiceWin" Title="新增" IFrameUrl="NewService.aspx" Hidden="true" WindowPosition="GoldenSection"
        EnableMaximize="true" IsModal="true" Target="Parent" EnableResize="true" runat="server" 
        Icon="Add" Width="500px" Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </f:Window>
    <f:Window ID="modifyServiceWin" Title="编辑" EnableMaximize="true" Hidden="true" WindowPosition="GoldenSection"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Icon="Pencil"
        Width="500px" Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </f:Window>
    <uc1:PageAuthority ID="pageAuthority" PageAuthority='["btnNew","btnModify","btnDelete"]'
        runat="server" />
    </form>
</body>
</html>
