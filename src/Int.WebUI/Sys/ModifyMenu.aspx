<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyMenu.aspx.cs" Inherits="Int.WebUI.Sys.ModifyMenu" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmModifyMenu" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px">
        <Toolbars>
            <f:Toolbar ID="tsMain" runat="server">
                <Items>
                    <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                    <f:Button ID="btnSave" Text="保存" runat="server" Icon="SystemSaveNew" ValidateForms="frmMenu"
                        ValidateMessageBox="false" OnClick="btnSave_Click" />
                    <f:ToolbarFill ID="ToolbarFill1" runat="server" />
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Panel ID="pnlMenu" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <f:SimpleForm ID="frmMenu" ShowBorder="false" ShowHeader="false"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <f:HiddenField ID="hiddenID" runat="server" />
                            <f:DropDownList ID="ddlPermission" Label="所需权限" runat="server"></f:DropDownList>
                            <f:TextBox ID="txtText" Label="菜单标题" Required="true" runat="server" />
                            <f:DropDownList ID="ddlMenuType" Label="菜单类型" runat="server">
                                <f:ListItem Text="All" Value="3" />
                                <f:ListItem Text="Web端菜单" Value="1" />
                                <f:ListItem Text="移动端菜单" Value="2" />
                            </f:DropDownList>
                            <f:TextBox ID="txtNavigateUrl" Label="Web地址" runat="server" />
                            <f:TextBox ID="txtMobileUrl" Label="移动地址" runat="server" />
                            <f:HiddenField ID="hiddenParentID" runat="server" />
                            <f:TriggerBox ID="txtParent" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                Label="父级菜单" runat="server" />
                            <f:TextBox ID="txtSort" Label="排&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;序" Required="true"
                                runat="server" RegexPattern="NUMBER" Text="0" />
                            <f:CheckBox ID="chkUseAble" runat="server" Checked="true" Text="" Label="是否可用" />
                        </Items>
                    </f:SimpleForm>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    <f:Window ID="wdnSelectMenu" Title="选择父级菜单" EnableMaximize="true" IsModal="true" Target="Parent" EnableResize="true" 
        runat="server" Icon="Find" Width="310px" Height="435px" EnableIFrame="true" Hidden="true">
    </f:Window>
    </form>
</body>
</html>
