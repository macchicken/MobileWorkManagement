<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyDepartment.aspx.cs" Inherits="Int.WebUI.Sys.ModifyDepartment" %>

<!DOCTYPE html>
<html>
<head id="head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmModifyDepartment" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px">
        <Toolbars>
            <f:Toolbar ID="tsMain" runat="server">
                <Items>
                    <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose"/>
                    <f:Button ID="btnSave" Text="保存" runat="server" Icon="SystemSaveNew" ValidateForms="frmDepartment"
                        ValidateMessageBox="false" OnClick="btnSave_Click"/>
                    <f:ToolbarFill ID="ToolbarFill1" runat="server" />
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Panel ID="pnlForm" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <f:SimpleForm ID="frmDepartment" ShowBorder="false" ShowHeader="false"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <f:HiddenField ID="txtID" runat="server" />
                            <f:TextBox ID="txtName" Label="部门名称" Required="true" runat="server" />
                            <f:HiddenField ID="hiddenParentID" runat="server" />
                            <f:TriggerBox ID="txtParent" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                Label="所属部门" runat="server" />
                        </Items>
                    </f:SimpleForm>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    <f:Window ID="selectDepartmentWin" Title="选择部门" Hidden="true" EnableIFrame="true" IsModal="true" Target="Parent" 
        EnableResize="true" runat="server" EnableConfirmOnClose="true" Icon="Add" Width="400px" Height="500px">
    </f:Window>
    </form>
</body>
</html>
