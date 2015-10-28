﻿using System.Web;
using System.Web.Optimization;

namespace Int.MobileUI
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            //bundles.Add(new ScriptBundle("~/content/jquery/t").Include(
            //    "~/content/jquery/jquery-1.10.2.min.js"));
            //bundles.Add(new ScriptBundle("~/content/bootstrap/js/t").Include(
            //    "~/content/bootstrap/js/bootstrap.min.js"));
            //bundles.Add(new StyleBundle("~/content/bootstrap/css/t").Include(
            //    "~/content/bootstrap/css/bootstrap.min.css",
            //    "~/content/bootstrap/css/bootstrap-theme.min.css"));
            //bundles.Add(new ScriptBundle("~/content/angularjs/t").Include(
            //    "~/content/angularjs/angular.min.js"));
            //bundles.Add(new ScriptBundle("~/content/bootbox/t").Include(
            //    "~/content/bootbox/bootbox.js"));
            //bundles.Add(new ScriptBundle("~/content/js/t").Include(
            //    "~/content/js/site.js"));
            //bundles.Add(new StyleBundle("~/content/css/t").Include(
            //    "~/content/css/site.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}
