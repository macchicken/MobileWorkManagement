<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectUser.aspx.cs" Inherits="Int.WebUI.Sys.SelectUser" %>

<!DOCTYPE html>
<html>
<head id="head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmNotNeedCheck" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        Title="Panel" ShowBorder="false" ShowHeader="false"
        Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <f:Toolbar ID="tsMain" runat="server">
                <Items>
                    <f:Button ID="btnEnter" Text="确定" runat="server" Icon="Tick" OnClick="btnEnter_Click" />
                    <f:ToolbarFill ID="ToolbarFill1" runat="server" />
                </Items>
            </f:Toolbar>
            <f:Panel ID="pnlUser" EnableBackgroundColor="true" BoxFlex="1" runat="server" BodyPadding="0px"
                ShowBorder="true" ShowHeader="false" Layout="Fit">
                <Items>
                    <f:Grid ID="userGrid" Title="职员信息" ShowBorder="false" ShowHeader="False" runat="server"
                        DataKeyNames="Id,Name" EnableRowNumber="True">
                        <Columns>
                            <f:BoundField Width="100px" HeaderText="登录帐号" ColumnID="Code" SortField="Code"
                                DataField="Code" />
                            <f:BoundField Width="100px" HeaderText="职员姓名" ColumnID="Name" SortField="Name" DataField="Name" />
                            <f:BoundField Width="100px" HeaderText="英文名" ColumnID="NameEn" SortField="NameEn" DataField="NameEn" />
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    </form>
</body>
</html>
