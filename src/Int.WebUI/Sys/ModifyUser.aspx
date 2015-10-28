<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyUser.aspx.cs" Inherits="Int.WebUI.Sys.ModifyUser" %>

<!DOCTYPE html>
<html>
<head id="head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmModifyUser" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px">
        <Toolbars>
            <f:Toolbar ID="tsMain" runat="server">
                <Items>
                    <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                    </f:Button>
                    <f:Button ID="btnSave" Text="保存" runat="server" ValidateForms="frmUser" ValidateMessageBox="false"
                        Icon="SystemSaveNew" OnClick="btnSave_Click">
                    </f:Button>
                    <f:ToolbarFill ID="ToolbarFill1" runat="server" />
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Panel ID="pnlForm" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <f:Form ID="frmPerson" ShowBorder="false" ShowHeader="false" AutoScroll="true" BodyPadding="5px"
                        runat="server" EnableCollapse="True">
                        <Rows>
                            <f:FormRow ID="FormRow4" runat="server">
                                <Items>
                                    <f:TextBox ID="txtCode" Label="登录帐号" runat="server" Width="300px" Required="true" />
                                    <f:TextBox ID="txtEmail" runat="server" Label="电子邮箱" RegexPattern="EMAIL" Required="true" Width="300px" />
                                </Items>
                            </f:FormRow>
                        </Rows>
                        <Rows>
                            <f:FormRow ID="FormRow1" runat="server">
                                <Items>
                                    <f:TextBox ID="txtName" Label="职员姓名" runat="server" Width="300px" Required="true" />
                                    <f:TextBox ID="txtNameEn" Label="英&nbsp;&nbsp;文&nbsp;名" runat="server" Width="300px" />
                                </Items>
                            </f:FormRow>
                        </Rows>
                        <Rows>
                            <f:FormRow ID="FormRow2" runat="server">
                                <Items>
                                    <f:TextBox ID="txtJob" runat="server" Label="职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;位" Width="300px" />
                                    <f:TriggerBox ID="txtLeader" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                        Required="true" Label="上&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;司" runat="server" Width="300px" />
                                </Items>
                            </f:FormRow>
                        </Rows>
                        <Rows>
                            <f:FormRow ID="FormRow3" runat="server">
                                <Items>
                                    <f:TextBox ID="txtPhone" runat="server" Label="电&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;话" Width="300px" />
                                    <f:CheckBox ID="chkUseAble" runat="server" Checked="true" Text="" Label="是否启用" />
                                </Items>
                            </f:FormRow>
                        </Rows>
                    </f:Form>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    <f:HiddenField ID="hiddenID" runat="server" />
    <f:HiddenField ID="hiddenLeader" runat="server" />
    <f:Window ID="selectLeaderWin" Title="选择上司" EnableMaximize="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Icon="Find" Hidden="true"
        Width="710px" Height="420px" EnableIFrame="true">
    </f:Window>
    </form>
</body>
</html>
