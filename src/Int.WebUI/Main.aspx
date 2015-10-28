<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Int.WebUI.Pages.Main" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="../Content/default.css" media="all" />
    <title>中谊国际内部系统</title>
    <style>
        body.f-theme-neptune .header {
            background-color: #005999;
        }

        body.f-theme-neptune .header .x-panel-body {
            background-color: transparent;
        }

        body.f-theme-neptune .header .title a {
            font-weight: bold;
            font-size: 24px;
            text-decoration: none;
            line-height: 50px;
            margin-left: 10px;
        }
    </style>
</head>
<body>
    <form id="mainForm" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" AjaxAspnetControls="linkSys,linkSz"></f:PageManager>
        <f:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
            <Regions>
                <f:Region ID="Region1" ShowBorder="false" Height="100px" ShowHeader="false" Position="Top" Layout="Fit" runat="server">
                    <Items>
                        <f:ContentPanel ShowBorder="false" ShowHeader="false" ID="ContentPanel1" runat="server">
                            <div class="top-nav">
		                        <div class="header">
			                        <div class="logo">
				                        <img src="../Content/header/syslogo.png"  />
			                        </div>
			                        <div class="mune" >
			                            <ul>
			                                <li id="liGr" runat="server" class="inhover">
                                                <asp:LinkButton ID="linkGr" runat="server" OnClick="linkMenu_Click">
					                                <em><img src="../Content/header/grsz.png" /></em>
					                                <span>个人中心</span>
                                                </asp:LinkButton>
				                            </li>
			                                <li id="liSz" runat="server" visible="false">
                                                 <asp:LinkButton ID="linkSz" runat="server" OnClick="linkMenu_Click">
                                                    <em><img src="../Content/header/szxt.png" /></em>
					                                <span>师资库</span>
                                                </asp:LinkButton>
				                            </li>
			                                <li id="liXm" runat="server">
                                                <asp:LinkButton ID="linkXm" runat="server" OnClick="linkMenu_Click">
					                                <em><img src="../Content/header/xmgl.png"  /></em>
					                                <span>项目管理</span>
                                                </asp:LinkButton>
				                            </li>
                                            <li id="liKh" runat="server">
                                                <asp:LinkButton ID="linkKh" runat="server" OnClick="linkMenu_Click">
					                                <em><img src="../Content/header/khgl.png"  /></em>
					                                <span>客户管理</span>
                                                </asp:LinkButton>
				                            </li>
			                                <li id="liWd" runat="server">
                                                <asp:LinkButton ID="linkWd" runat="server" OnClick="linkMenu_Click">
					                                <em><img src="../Content/header/wdgj.png" /></em>
					                                <span>文档归结</span>
                                                </asp:LinkButton>
				                            </li>
			                                <li id="liHw" runat="server">
                                                <asp:LinkButton ID="linkHw" runat="server" OnClick="linkMenu_Click">
					                                <em><img src="../Content/header/hwgl.png" /></em>
					                                <span>海外平台</span>
                                                </asp:LinkButton>
				                            </li>
			                                <li id="liSys" runat="server" visible="false">
                                                <asp:LinkButton ID="linkSys" runat="server" OnClick="linkMenu_Click">
                                                    <em><img src="../Content/header/xtgl.png"  /></em>
					                                <span>系统管理</span>
                                                </asp:LinkButton>
				                            </li>
			                            </ul>
		                           </div>
		                           <div class="toplogin">
				                       <em>欢迎光临：<asp:Label ID="lbUser" runat="server"></asp:Label></em> 
                                       <asp:LinkButton ID="btnExit" Text="退出" runat="server" OnClick="btnExit_Click" />
		                           </div>
		                        </div>
	                        </div>
                        </f:ContentPanel>
                    </Items>
                </f:Region>
                <f:Region ID="Region2" Split="true" Width="200px" ShowHeader="false" Layout="Fit" EnableCollapse="true" Position="Left" runat="server">
                    <Items>
                        <f:Tree ID="leftMenuTree" runat="server" ShowHeader="true" Title="菜单"></f:Tree>
                    </Items>
                </f:Region>
                <f:Region ID="mainRegion" ShowHeader="false" Layout="Fit" Position="Center" runat="server">
                    <Items>
                        <f:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                            <Tabs>
                                <f:Tab ID="Tab1" Title="首页" Layout="Fit" Icon="House" runat="server">
                                </f:Tab>
                            </Tabs>
                        </f:TabStrip>
                    </Items>
                </f:Region>
            </Regions>
            <Toolbars>
                <f:Toolbar ID="buttomToolbar" runat="server" Position="Bottom">
                    <Items>
                        <f:ToolbarFill ID="ToolbarFill1" runat="server" />
                        <f:Label runat="server" ID="lblXiaosuoOffice" Text="技术支持：" />
                        <f:LinkButton runat="server" ID="XiaosuoOffice" Text="刘衍志" EnablePostBack="false" />
                        <f:Label runat="server" ID="lblVersion" Text="" />
                        <f:ToolbarFill ID="ToolbarFill2" runat="server" />
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:RegionPanel>
    </form>
    <script>
        var menuClientID = '<%= leftMenuTree.ClientID %>';
        var tabStripClientID = '<%= mainTabStrip.ClientID %>';

        F.ready(function () {
            if (window.Ext) {
                F.Button = Ext.Button;
                F.Toolbar = Ext.Toolbar;
            }

            // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
            // mainTabStrip： 选项卡实例
            // createToolbar： 创建选项卡前的回调函数（接受tabConfig参数）
            // updateLocationHash: 切换Tab时，是否更新地址栏Hash值
            // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
            // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame
            F.util.initTreeTabStrip(F(menuClientID), F(tabStripClientID), null, true, false, false);

            // 添加示例标签页
            window.addExampleTab = function (id, url, text, icon, refreshWhenExist) {
                // 动态添加一个标签页
                // mainTabStrip： 选项卡实例
                // id： 选项卡ID
                // url: 选项卡IFrame地址 
                // text： 选项卡标题
                // icon： 选项卡图标
                // addTabCallback： 创建选项卡前的回调函数（接受tabConfig参数）
                // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
                F.util.addMainTab(F(tabStripClientID), id, url, text, icon, null, refreshWhenExist);
            };

            // 移除选中标签页
            window.removeActiveTab = function () {
                var activeTab = F(tabStripClientID).getActiveTab();
                F(tabStripClientID).removeTab(activeTab.id);
            };
        });
    </script>
</body>
</html>
