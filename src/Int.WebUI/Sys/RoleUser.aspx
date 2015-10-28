<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleUser.aspx.cs" Inherits="Int.WebUI.Sys.RoleUser" %>

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
    <form id="frmRoleUser" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" BodyPadding="3px"
        Icon="feed" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <f:Panel ID="pnlDepartmentGrid" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit" runat="server">
                <Toolbars>
                    <f:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <f:TwinTriggerBox runat="server" ShowLabel="false" ID="ttbSearch" Width="200" ShowTrigger1="false"
                                OnTrigger1Click="ttbSearch_Trigger1Click" OnTrigger2Click="ttbSearch_Trigger2Click"
                                Trigger1Icon="Clear" Trigger2Icon="Search">
                            </f:TwinTriggerBox>
                            <f:ToolbarFill runat="server" />
                            <f:Button ID="btnEnter" Text="确定" runat="server" Icon="Tick" OnClick="btnEnter_Click" />
                        </Items>
                    </f:Toolbar>
                </Toolbars>
                <Items>
                    <f:Panel ID="pnlLeft" runat="server" ShowBorder="false" BoxFlex="1" Layout="HBox" ShowHeader="false"
                        BoxConfigAlign="Stretch" BoxConfigPosition="Start" BoxConfigPadding="0" BoxConfigChildMargin="0 0 0 0">
                        <Items>
                            <f:Panel ID="pnlUser" BoxFlex="1" runat="server" BodyPadding="0px"
                                ShowBorder="true" ShowHeader="false" Layout="Fit">
                                <Items>
                                    <f:Grid ID="userGrid" Title="职员信息" PageSize="20" AllowPaging="true" OnPageIndexChange="userGrid_PageIndexChange"
                                        ShowHeader="False" ShowBorder="false" runat="server" DataKeyNames="Id,Name,Code" IsDatabasePaging="true" EnableCheckBoxSelect="True"
                                        EnableRowDoubleClickEvent="true" OnRowDoubleClick="userGrid_RowDoubleClick">
                                        <Columns>
                                            <f:BoundField Width="100px" HeaderText="登录名" ColumnID="Code1" SortField="Code"
                                                DataField="Code" />
                                            <f:BoundField Width="100px" HeaderText="姓名" ColumnID="Name1" SortField="Name" DataField="Name" ExpandUnusedSpace="true" />
                                        </Columns>
                                    </f:Grid>
                                </Items>
                            </f:Panel>
                            <f:Panel ID="pnlMiddle" Width="50px" runat="server"
                                Layout="VBox" BoxConfigAlign="Center" BoxConfigPosition="Center" BodyPadding="0px"
                                ShowBorder="true" ShowHeader="False">
                                <Items>
                                    <f:Panel ID="row1" runat="server" BodyPadding="0px"
                                        Height="50px" ShowBorder="False" ShowHeader="False">
                                        <Items>
                                            <f:Button ID="btnRight" Icon="ArrowRight" runat="server" OnClick="btnRight_Click" />
                                        </Items>
                                    </f:Panel>
                                    <f:Panel ID="row2" runat="server" BodyPadding="0px"
                                        Height="50px" ShowBorder="False" ShowHeader="False">
                                        <Items>
                                            <f:Button ID="btnLeft" Icon="ArrowLeft" runat="server" OnClick="btnLeft_Click" />
                                        </Items>
                                    </f:Panel>
                                </Items>
                            </f:Panel>
                            <f:Panel ID="pnlRight" BoxFlex="1" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="False" Layout="Fit">
                                <Items>
                                    <f:Grid ID="rightGrid" Title="职员信息" ShowBorder="false" EnableCheckBoxSelect="True"
                                        ShowHeader="False" runat="server" DataKeyNames="Id,Name,Code"
                                        EnableRowDoubleClickEvent="true" OnRowDoubleClick="rightGrid_RowDoubleClick">
                                        <Columns>
                                           <f:BoundField Width="100px" HeaderText="登录名" ColumnID="Code" SortField="Code"
                                                DataField="Code" />
                                           <f:BoundField Width="100px" ColumnID="Name" SortField="Name" DataField="Name" HeaderText="姓名" ExpandUnusedSpace="true" />
                                        </Columns>
                                    </f:Grid>
                                </Items>
                            </f:Panel>
                        </Items>
                    </f:Panel>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    </form>
</body>
</html>
