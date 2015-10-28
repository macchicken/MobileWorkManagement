<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModuleList.aspx.cs" Inherits="Int.WebUI.Sys.ModuleList" %>
<%@ Register Src="../Controls/PageAuthorityControl.ascx" TagName="PageAuthority" TagPrefix="uc1" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmModule" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" BodyPadding="3px" Icon="Outline" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch"
        Title="模块管理">
        <Items>
            <f:Form ID="frmFind" ShowBorder="False" BodyPadding="5px" ShowHeader="False" runat="server">
                <Rows>
                    <f:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <f:DropDownList ID="ddlService" runat="server" Label="所属服务" Width="300px"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlService_SelectedIndexChanged"></f:DropDownList>
                        </Items>
                    </f:FormRow>
                </Rows>
            </f:Form>
            <f:Panel ID="pnlModule" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit" runat="server">
                <Toolbars>
                    <f:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <f:Button ID="btnNew" Icon="Add" Text="新增" runat="server" />
                            <f:Button ID="btnModify" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModify_Click" />
                        </Items>
                    </f:Toolbar>
                </Toolbars>
                <Items>
                    <f:Grid ID="moduleGrid" Title="模块管理" ShowBorder="false" ShowHeader="False" runat="server" DataKeyNames="Id,Text"
                        OnRowCommand="moduleGrid_RowCommand" OnRowDataBound="moduleGrid_RowDataBound">
                        <Columns>
                            <f:BoundField Width="190px" ColumnID="Text" DataField="Text" DataSimulateTreeLevelField="TreeLevel"
                                HeaderText="模块名" />
                            <f:BoundField Width="150px" ColumnID="Code" DataField="Code"
                                HeaderText="编码" />
                            <f:BoundField Width="60px" ColumnID="Sort" DataField="Sort"
                                HeaderText="排序" />
                            <f:TemplateField Width="650px" HeaderText="权限" ID="tmpCkb">
                                <ItemTemplate>
                                    <asp:Literal runat="server" ID="lbAuthority"></asp:Literal>
                                </ItemTemplate>
                            </f:TemplateField>
                            <f:WindowField TextAlign="Center" Width="60px" WindowID="modifyModuleWin" Icon="Pencil" ToolTip="编辑"
                                DataIFrameUrlFields="Id" DataIFrameUrlFormatString="ModifyModule.aspx?id={0}"
                                DataWindowTitleFormatString="编辑-{0}" DataWindowTitleField="Text" />
                            <f:LinkButtonField TextAlign="Left" Width="60px" Icon="Delete" ToolTip="删除" ConfirmText="确认删除吗？"
                                CommandName="delete" ExpandUnusedSpace="true" />
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    <f:Window ID="newModuleWin" Title="新增" OnClose="subwin_Close" EnableMaximize="true" IsModal="true"
        Target="Parent" EnableResize="true" runat="server" Icon="Add" Width="500px" Hidden="true"
        Height="280px" EnableConfirmOnClose="true" EnableIFrame="true" IFrameUrl="NewModule.aspx">
    </f:Window>
    <f:Window ID="modifyModuleWin" Title="编辑" OnClose="subwin_Close" EnableMaximize="true" IsModal="false"
        Target="Parent" EnableResize="true" runat="server" Icon="Pencil" Width="500px" Hidden="true"
        Height="280px" EnableConfirmOnClose="true" EnableIFrame="true">
    </f:Window>
    <uc1:PageAuthority ID="pageAuthority" PageAuthority='["btnNew","btnModify","btnDelete"]' runat="server" />
    </form>
</body>
</html>