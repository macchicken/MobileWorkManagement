using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Autofac;
using Autofac.Integration.Web;
using ECommon.Autofac;
using ECommon.Components;
using ECommon.Configurations;
using ECommon.JsonNet;
using ECommon.Log4Net;
using ENode.Configurations;
using System.Reflection;
using ENode.Commanding;
using ENode.EQueue;
using Int.AC.ReadModel.Services;
using Int.WebUI;
using Int.AC.ReadModel;
using Int.AC.ReadModel.Departments;
using Int.AC.ReadModel.Menus;
using Int.AC.ReadModel.Modules;
using Int.AC.ReadModel.Permissions;
using Int.AC.ReadModel.Roles;
using Int.AC.ReadModel.Users;

namespace Int.WebUI
{
    public class Global : System.Web.HttpApplication, IContainerProviderAccessor
    {
        static IContainerProvider _containerProvider;

        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            InitializeENode();
        }

        private static void InitializeENode()
        {
            var assemblies = new[]
            {
                Assembly.Load("Int.AC.ReadModel"),
                Assembly.Load("Int.WebUI")
            };
            Configuration
                .Create()
                .UseAutofac()
                .RegisterCommonComponents()
                .UseLog4Net()
                .UseJsonNet()
                .CreateENode()
                .RegisterENodeComponents()
                .RegisterBusinessComponents(assemblies)
                .SetProviders()
                .UseEQueue()
                .InitializeBusinessAssemblies(assemblies)
                .StartEQueue();

            var container = (ObjectContainer.Current as AutofacObjectContainer).Container;
            _containerProvider = new ContainerProvider(container);
        }
    }
}