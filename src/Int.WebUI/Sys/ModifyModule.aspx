<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyModule.aspx.cs" Inherits="Int.WebUI.Sys.ModifyModule" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmModifyModule" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px">
        <Toolbars>
            <f:Toolbar ID="tsMain" runat="server">
                <Items>
                    <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                    <f:Button ID="btnSave" Text="保存" runat="server" Icon="SystemSaveNew" ValidateForms="frmModule"
                        ValidateMessageBox="false" OnClick="btnSave_Click" />
                    <f:ToolbarFill ID="ToolbarFill1" runat="server" />
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Panel ID="pnlModule" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <f:SimpleForm ID="frmModule" ShowBorder="false" ShowHeader="false"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <f:HiddenField ID="hiddenID" runat="server" />
                            <f:DropDownList ID="ddlService" Label="所属服务" Required="true" runat="server" />
                            <f:TextBox ID="txtCode" Label="编码" Required="true" runat="server" />
                            <f:TextBox ID="txtText" Label="模块名" Required="true" runat="server" />
                            <f:HiddenField ID="hiddenParentID" runat="server" />
                            <f:TriggerBox ID="txtParent" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                Label="父级模块" runat="server" />
                            <f:TextBox ID="txtSort" Label="排&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;序" Required="true"
                                runat="server" RegexPattern="NUMBER" Text="0" />
                            <f:CheckBox ID="chkUseAble" runat="server" Checked="true" Text="" Label="是否可用" />
                        </Items>
                    </f:SimpleForm>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    <f:Window ID="wdnSelectModule" Title="选择父级模块"  EnableMaximize="true" IsModal="true" Hidden="true"
       Target="Parent" EnableResize="true" runat="server" Icon="Find" Width="310px" EnableConfirmOnClose="true"
        Height="435px" EnableIFrame="true">
    </f:Window>
    </form>
</body>
</html>
