﻿using System.Collections.Generic;
using System.Web.Optimization;

namespace Notus.Hub
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            var jquery = new ScriptBundle("~/bundles/jquery").Include(
                //  "~/Content/js/bootstrap.js",
                "~/Content/js/fullcalendar.js",
                "~/Content/js/custom.js");
            jquery.Orderer = new AsDefinedBundleOrderer();
            bundles.Add(jquery);

            var css = new StyleBundle("~/Content/css").Include(
                "~/Content/styles/bootstrap.css",
                "~/Content/styles/material.css",
                "~/Content/styles/ripples.css",
                "~/Content/styles/gsdk-base.css",
                "~/Content/styles/fullcalendar.css",
                "~/Content/styles/fullcalendar.print.css",
                //Font awesome css
                "~/Content/styles/font-awesome.css",
                "~/Content/styles/timeline.css",
                "~/Content/styles/select.css");
            css.Orderer = new AsDefinedBundleOrderer();
            bundles.Add(css);

            var angular = new ScriptBundle("~/bundles/angular").Include(
                "~/Content/js/jquery-2.1.4.min.js",
                "~/Content/js/d3.js",
                "~/Content/js/topojson.min.js",
                "~/Scripts/charts/datamaps.all.js",
                "~/Content/js/angular.min.js",
                "~/Content/js/angular-sanitize.min.js",
                "~/Content/js/angular-animate.min.js",
                "~/Content/js/select.min.js",
                "~/Content/js/angular-ui-router.min.js",
                "~/Content/js/angular-strap.js",
                "~/Content/js/angular-strap.tpl.js",
                "~/Content/js/bindonce.js",
                "~/Content/js/ui-bootstrap-tpls-0.13.0.js",
                "~/Content/js/slider.js",
                "~/Scripts/App/app.js",
                "~/Scripts/App/controllers.js",
                "~/Content/js/material.js",
                "~/Content/js/ripples.js",
                "~/Content/js/moment.js",
                "~/Content/js/angular-moment.js"
                );
            angular.Orderer = new AsDefinedBundleOrderer();
            bundles.Add(angular);
        }

        public class AsDefinedBundleOrderer : IBundleOrderer
        {
            public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
            {
                return files;
            }
        }
    }
}