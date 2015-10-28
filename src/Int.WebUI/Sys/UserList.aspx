<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Int.WebUI.Sys.UserList" %>
<%@ Register Src="../Controls/PageAuthorityControl.ascx" TagName="PageAuthority" TagPrefix="uc1" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Content/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmUser" runat="server">
    <f:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <f:Panel ID="pnlMain" runat="server" BodyPadding="3px"
        ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <f:Form ID="frmFind" ShowBorder="False" BodyPadding="5px"
                ShowHeader="False" runat="server">
                <Rows>
                    <f:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <f:TwinTriggerBox runat="server" ShowLabel="false" ID="ttbSearch" Width="200" ShowTrigger1="false"
                                OnTrigger1Click="ttbSearch_Trigger1Click" OnTrigger2Click="ttbSearch_Trigger2Click"
                                Trigger1Icon="Clear" Trigger2Icon="Search">
                            </f:TwinTriggerBox>
                        </Items>
                    </f:FormRow>
                </Rows>
            </f:Form>
            <f:Panel ID="pnlUserGrid" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                runat="server">
                <Toolbars>
                    <f:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <f:FileUpload runat="server" ID="btnUpload" ShowRedStar="false" ButtonIcon="DiskUpload"
                                ButtonText="上传" ButtonOnly="true" Required="false" ShowLabel="true"
                                AutoPostBack="true" OnFileSelected="btnUpload_FileSelected">
                            </f:FileUpload>
                            <f:Button ID="btnDownload" Icon="DiskDownload" Text="下载" runat="server" OnClick="btnDownload_Click" />
                            <f:Button ID="btnAdd" Icon="Add" Text="新增" runat="server" />
                            <f:Button ID="btnModify" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModify_Click" />
                            <f:Button ID="btnRole" Icon="Feed" Text="分配角色" runat="server" OnClick="btnRole_Click" />
                            <f:Button ID="btnChangePwd" Icon="overlays" Text="修改密码" runat="server" OnClick="btnChangePwd_Click" />
                        </Items>
                    </f:Toolbar>
                </Toolbars>
                <Items>
                    <f:Grid ID="userGrid" Title="用户" ShowBorder="false" ShowHeader="False" runat="server" DataKeyNames="Id,LoginId" 
                        PageSize="50" AllowPaging="true" OnPageIndexChange="userGrid_PageIndexChange" IsDatabasePaging ="true">
                        <Columns>
                            <f:BoundField Width="100px" HeaderText="登录名" ColumnID="Code" SortField="Code" DataField="Code" />
                            <f:BoundField Width="100px" HeaderText="姓名" ColumnID="Name" SortField="Name" DataField="Name" />
                            <f:BoundField Width="100px" HeaderText="英文名" ColumnID="NameEn" SortField="NameEn" DataField="NameEn" />
                            <f:BoundField Width="100px" HeaderText="上司" DataField="LeaderName" ColumnID="LeaderName"
                                SortField="LeaderName" />
                            <f:BoundField Width="160px" HeaderText="职位" ColumnID="JobName" SortField="JobName" DataField="JobName" />
                            <f:BoundField Width="120px" HeaderText="电话" ColumnID="Phone" SortField="Phone"
                                DataField="Phone" />
                            <f:BoundField Width="180px" HeaderText="电子邮箱" ColumnID="Email" SortField="Email"
                                DataField="Email" />
                            <f:CheckBoxField Width="80px" ColumnID="UseAble" SortField="UseAble" TextAlign="Center"
                                RenderAsStaticField="true" DataField="UseAble" HeaderText="是否可用" />
                            <f:WindowField TextAlign="Left" Width="60px" WindowID="modifyUserWin" Icon="Pencil"
                                ColumnID="btnModify" ToolTip="编辑" DataIFrameUrlFields="Id" DataIFrameUrlFormatString="ModifyUser.aspx?id={0}"
                                DataWindowTitleField="LoginId" DataWindowTitleFormatString="编辑-{0}" ExpandUnusedSpace="true" />
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    <f:Window ID="newUserWin" Title="新增" OnClose="subwin_Close" EnableMaximize="false" IsModal="true"
       Target="Parent" EnableResize="false" runat="server" Icon="Add" Width="700px" Hidden="true"
        Height="350px" EnableConfirmOnClose="true" EnableIFrame="true" IFrameUrl="NewUser.aspx">
    </f:Window>
    <f:Window ID="modifyUserWin" Title="编辑" OnClose="subwin_Close" EnableMaximize="true" IsModal="true"
       Target="Parent" EnableResize="true" runat="server" Icon="Pencil" Width="700px" Hidden="true"
        Height="350px" EnableConfirmOnClose="true" EnableIFrame="true">
    </f:Window>
    <f:Window ID="awardRoleWin" Title="分配角色" OnClose="subwin_Close" EnableMaximize="true" IsModal="true"
       Target="Parent" EnableResize="true" runat="server" Icon="Feed" Width="500px" Hidden="true"
        Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </f:Window>
    <f:Window ID="ChangePwdWin" Title="修改密码" OnClose="subwin_Close" EnableMaximize="true" IsModal="true"
       Target="Parent" EnableResize="true" runat="server" Icon="overlays" Width="500px" Hidden="true"
        Height="150px" EnableConfirmOnClose="true" EnableIFrame="true">
    </f:Window>
    <uc1:PageAuthority ID="pageAuthority" PageAuthority='["btnNew","btnModify","btnRole","btnChangePwd"]'
        runat="server" />
    </form>
</body>
</html>
