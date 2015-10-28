<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyRole.aspx.cs" Inherits="Int.WebUI.Sys.ModifyRole" %>

<!DOCTYPE html>
<html>
<head id="head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmModifyRole" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px">
        <Toolbars>
            <f:Toolbar ID="tsMain" runat="server">
                <Items>
                    <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                    </f:Button>
                    <f:Button ID="btnSave" Text="保存" runat="server" ValidateForms="frmRole" ValidateMessageBox="false"
                        Icon="SystemSaveNew" OnClick="btnSave_Click">
                    </f:Button>
                    <f:ToolbarFill ID="ToolbarFill1" runat="server" />
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Panel ID="pnlForm" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <f:SimpleForm ID="frmRole" ShowBorder="false" ShowHeader="false"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <f:HiddenField ID="hiddenID" runat="server" />
                            <f:TextBox ID="txtName" Label="角色名称" Required="true" runat="server" />
                            <f:TextBox ID="txtSort" Label="排&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;序" Required="true"
                                Text="0" runat="server" RegexPattern="NUMBER" />
                            <f:CheckBox ID="chkUseAble" runat="server" Checked="true" Text="" Label="是否可用">
                            </f:CheckBox>
                        </Items>
                    </f:SimpleForm>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    </form>
</body>
</html>
