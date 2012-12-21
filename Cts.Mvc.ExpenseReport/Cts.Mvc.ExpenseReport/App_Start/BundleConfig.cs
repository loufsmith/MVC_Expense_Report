﻿using System.Web;
using System.Web.Optimization;

namespace Cts.Mvc.ExpenseReport
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.intellisense.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));
            
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*",
                        "~/Scripts/knockout-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/Site.css",
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap-datepicker.css",
                        "~/Content/bootstrap-responsive.css",
                        "~/Content/bootstrap-responsive.min.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        

            //bundles.Add(new StyleBundle("~/Content/themes/redmond/css").Include(
            //            "~/Content/themes/redmond/jquery.ui.core.css",
            //            "~/Content/themes/redmond/jquery.ui.resizable.css",
            //            "~/Content/themes/redmond/jquery.ui.selectable.css",
            //            "~/Content/themes/redmond/jquery.ui.accordion.css",
            //            "~/Content/themes/redmond/jquery.ui.autocomplete.css",
            //            "~/Content/themes/redmond/jquery.ui.button.css",
            //            "~/Content/themes/redmond/jquery.ui.dialog.css",
            //            "~/Content/themes/redmond/jquery.ui.slider.css",
            //            "~/Content/themes/redmond/jquery.ui.tabs.css",
            //            "~/Content/themes/redmond/jquery.ui.datepicker.css",
            //            "~/Content/themes/redmond/jquery.ui.progressbar.css",
            //            "~/Content/themes/redmond/jquery.ui.theme.css"));

            bundles.Add(new ScriptBundle("~/bundles/fieldfunctions").Include(
                        "~/Scripts/jquery.field.functions.js"));
        }
    }
}