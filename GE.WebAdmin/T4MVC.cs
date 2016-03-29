﻿// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
public static partial class MVC
{
    public static GE.WebAdmin.Controllers.AccountController Account = new GE.WebAdmin.Controllers.T4MVC_AccountController();
    public static GE.WebAdmin.Controllers.ArticlesController Articles = new GE.WebAdmin.Controllers.T4MVC_ArticlesController();
    public static GE.WebAdmin.Controllers.ArticleTypesController ArticleTypes = new GE.WebAdmin.Controllers.T4MVC_ArticleTypesController();
    public static GE.WebAdmin.Controllers.ClicksController Clicks = new GE.WebAdmin.Controllers.T4MVC_ClicksController();
    public static GE.WebAdmin.Controllers.ClickTypesController ClickTypes = new GE.WebAdmin.Controllers.T4MVC_ClickTypesController();
    public static GE.WebAdmin.Controllers.ForumPartsController ForumParts = new GE.WebAdmin.Controllers.T4MVC_ForumPartsController();
    public static GE.WebAdmin.Controllers.GamesController Games = new GE.WebAdmin.Controllers.T4MVC_GamesController();
    public static GE.WebAdmin.Controllers.HomeController Home = new GE.WebAdmin.Controllers.T4MVC_HomeController();
    public static GE.WebAdmin.Controllers.ManualsController Manuals = new GE.WebAdmin.Controllers.T4MVC_ManualsController();
    public static GE.WebAdmin.Controllers.MaterialTagsController MaterialTags = new GE.WebAdmin.Controllers.T4MVC_MaterialTagsController();
    public static GE.WebAdmin.Controllers.MenuesController Menues = new GE.WebAdmin.Controllers.T4MVC_MenuesController();
    public static GE.WebAdmin.Controllers.MenuItemsController MenuItems = new GE.WebAdmin.Controllers.T4MVC_MenuItemsController();
    public static GE.WebAdmin.Controllers.NewsController News = new GE.WebAdmin.Controllers.T4MVC_NewsController();
    public static GE.WebAdmin.Controllers.PicturesController Pictures = new GE.WebAdmin.Controllers.T4MVC_PicturesController();
    public static GE.WebAdmin.Controllers.RedirectsController Redirects = new GE.WebAdmin.Controllers.T4MVC_RedirectsController();
    public static GE.WebAdmin.Controllers.RequestController Request = new GE.WebAdmin.Controllers.T4MVC_RequestController();
    public static GE.WebAdmin.Controllers.RolesController Roles = new GE.WebAdmin.Controllers.T4MVC_RolesController();
    public static GE.WebAdmin.Controllers.RoutesController Routes = new GE.WebAdmin.Controllers.T4MVC_RoutesController();
    public static GE.WebAdmin.Controllers.RouteValuesController RouteValues = new GE.WebAdmin.Controllers.T4MVC_RouteValuesController();
    public static GE.WebAdmin.Controllers.SeoInfoController SeoInfo = new GE.WebAdmin.Controllers.T4MVC_SeoInfoController();
    public static GE.WebAdmin.Controllers.SeoKeywordsController SeoKeywords = new GE.WebAdmin.Controllers.T4MVC_SeoKeywordsController();
    public static GE.WebAdmin.Controllers.SettingsController Settings = new GE.WebAdmin.Controllers.T4MVC_SettingsController();
    public static T4MVC.SharedController Shared = new T4MVC.SharedController();
}

namespace T4MVC
{
}

namespace T4MVC
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class Dummy
    {
        private Dummy() { }
        public static Dummy Instance = new Dummy();
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_ActionResult : System.Web.Mvc.ActionResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_ActionResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
     
    public override void ExecuteResult(System.Web.Mvc.ControllerContext context) { }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}
[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_ViewResult : System.Web.Mvc.ViewResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_ViewResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}
[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_PartialViewResult : System.Web.Mvc.PartialViewResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_PartialViewResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}
[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_RedirectToRouteResult : System.Web.Mvc.RedirectToRouteResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_RedirectToRouteResult(string area, string controller, string action, string protocol = null): base(default(System.Web.Routing.RouteValueDictionary))
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}
[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_FileResult : System.Web.Mvc.FileResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_FileResult(string area, string controller, string action, string protocol = null): base(" ")
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
     
    protected override void WriteFile(System.Web.HttpResponseBase response) { }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}



namespace Links
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Scripts {
        private const string URLPATH = "~/Scripts";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
        public static readonly string menues_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/menues.min.js") ? Url("menues.min.js") : Url("menues.js");
        public static readonly string routes_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/routes.min.js") ? Url("routes.min.js") : Url("routes.js");
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Content {
        private const string URLPATH = "~/Content";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class dist {
            private const string URLPATH = "~/Content/dist";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class css {
                private const string URLPATH = "~/Content/dist/css";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string bootstrap_datepicker_min_css = Url("bootstrap-datepicker.min.css");
                public static readonly string colorpicker_min_css = Url("colorpicker.min.css");
                public static readonly string site_min_css = Url("site.min.css");
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class fonts {
                private const string URLPATH = "~/Content/dist/fonts";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string fontawesome_webfont_eot = Url("fontawesome-webfont.eot");
                public static readonly string fontawesome_webfont_svg = Url("fontawesome-webfont.svg");
                public static readonly string fontawesome_webfont_ttf = Url("fontawesome-webfont.ttf");
                public static readonly string fontawesome_webfont_woff = Url("fontawesome-webfont.woff");
                public static readonly string fontawesome_webfont_woff2 = Url("fontawesome-webfont.woff2");
                public static readonly string FontAwesome_otf = Url("FontAwesome.otf");
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class js {
                private const string URLPATH = "~/Content/dist/js";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string bootstrap_colorpicker_min_js = Url("bootstrap-colorpicker.min.js");
                public static readonly string bootstrap_datepicker_min_js = Url("bootstrap-datepicker.min.js");
                public static readonly string ckeditor_min_js = Url("ckeditor.min.js");
                public static readonly string menues_min_js = Url("menues.min.js");
                public static readonly string routes_min_js = Url("routes.min.js");
                public static readonly string site_min_js = Url("site.min.js");
            }
        
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class i {
            private const string URLPATH = "~/Content/i";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class sx {
            private const string URLPATH = "~/Content/sx";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class js {
                private const string URLPATH = "~/Content/sx/js";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string sx_find_table_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/sx-find-table.min.js") ? Url("sx-find-table.min.js") : Url("sx-find-table.js");
                public static readonly string sx_grid_view_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/sx-grid-view.min.js") ? Url("sx-grid-view.min.js") : Url("sx-grid-view.js");
            }
        
        }
    
    }

    
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static partial class Bundles
    {
        public static partial class Scripts 
        {
            public static class Assets
            {
                public const string menues_js = "~/Scripts/menues.js"; 
                public const string routes_js = "~/Scripts/routes.js"; 
            }
        }
        public static partial class Content 
        {
            public static partial class dist 
            {
                public static partial class css 
                {
                    public static class Assets
                    {
                        public const string bootstrap_datepicker_min_css = "~/Content/dist/css/bootstrap-datepicker.min.css";
                        public const string colorpicker_min_css = "~/Content/dist/css/colorpicker.min.css";
                        public const string site_min_css = "~/Content/dist/css/site.min.css";
                    }
                }
                public static partial class fonts 
                {
                    public static class Assets
                    {
                    }
                }
                public static partial class js 
                {
                    public static class Assets
                    {
                        public const string bootstrap_colorpicker_min_js = "~/Content/dist/js/bootstrap-colorpicker.min.js"; 
                        public const string bootstrap_datepicker_min_js = "~/Content/dist/js/bootstrap-datepicker.min.js"; 
                        public const string ckeditor_min_js = "~/Content/dist/js/ckeditor.min.js"; 
                        public const string menues_min_js = "~/Content/dist/js/menues.min.js"; 
                        public const string routes_min_js = "~/Content/dist/js/routes.min.js"; 
                        public const string site_min_js = "~/Content/dist/js/site.min.js"; 
                    }
                }
                public static class Assets
                {
                }
            }
            public static partial class i 
            {
                public static class Assets
                {
                }
            }
            public static partial class sx 
            {
                public static partial class js 
                {
                    public static class Assets
                    {
                        public const string sx_find_table_js = "~/Content/sx/js/sx-find-table.js"; 
                        public const string sx_grid_view_js = "~/Content/sx/js/sx-grid-view.js"; 
                    }
                }
                public static class Assets
                {
                }
            }
            public static class Assets
            {
            }
        }
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal static class T4MVCHelpers {
    // You can change the ProcessVirtualPath method to modify the path that gets returned to the client.
    // e.g. you can prepend a domain, or append a query string:
    //      return "http://localhost" + path + "?foo=bar";
    private static string ProcessVirtualPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and must first be made absolute
        string path = VirtualPathUtility.ToAbsolute(virtualPath);
        
        // Add your own modifications here before returning the path
        return path;
    }

    // Calling ProcessVirtualPath through delegate to allow it to be replaced for unit testing
    public static Func<string, string> ProcessVirtualPath = ProcessVirtualPathDefault;

    // Calling T4Extension.TimestampString through delegate to allow it to be replaced for unit testing and other purposes
    public static Func<string, string> TimestampString = System.Web.Mvc.T4Extensions.TimestampString;

    // Logic to determine if the app is running in production or dev environment
    public static bool IsProduction() { 
        return (HttpContext.Current != null && !HttpContext.Current.IsDebuggingEnabled); 
    }
}





#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114


