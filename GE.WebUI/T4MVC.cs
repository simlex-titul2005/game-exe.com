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
    public static GE.WebUI.Controllers.ArticlesController Articles = new GE.WebUI.Controllers.T4MVC_ArticlesController();
    public static GE.WebUI.Controllers.ClicksController Clicks = new GE.WebUI.Controllers.T4MVC_ClicksController();
    public static GE.WebUI.Controllers.ErrorController Error = new GE.WebUI.Controllers.T4MVC_ErrorController();
    public static GE.WebUI.Controllers.ForumController Forum = new GE.WebUI.Controllers.T4MVC_ForumController();
    public static GE.WebUI.Controllers.GamesController Games = new GE.WebUI.Controllers.T4MVC_GamesController();
    public static GE.WebUI.Controllers.HomeController Home = new GE.WebUI.Controllers.T4MVC_HomeController();
    public static GE.WebUI.Controllers.LikesController Likes = new GE.WebUI.Controllers.T4MVC_LikesController();
    public static GE.WebUI.Controllers.MenuesController Menues = new GE.WebUI.Controllers.T4MVC_MenuesController();
    public static GE.WebUI.Controllers.NewsController News = new GE.WebUI.Controllers.T4MVC_NewsController();
    public static GE.WebUI.Controllers.PicturesController Pictures = new GE.WebUI.Controllers.T4MVC_PicturesController();
    public static GE.WebUI.Controllers.SearchController Search = new GE.WebUI.Controllers.T4MVC_SearchController();
    public static GE.WebUI.Controllers.SeoController Seo = new GE.WebUI.Controllers.T4MVC_SeoController();
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
internal partial class T4MVC_System_Web_Mvc_EmptyResult : System.Web.Mvc.EmptyResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_EmptyResult(string area, string controller, string action, string protocol = null): base()
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
[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_ContentResult : System.Web.Mvc.ContentResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_ContentResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
    
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
        public static readonly string _references_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/_references.min.js") ? Url("_references.min.js") : Url("_references.js");
        public static readonly string click_stat_handler_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/click-stat-handler.min.js") ? Url("click-stat-handler.min.js") : Url("click-stat-handler.js");
        public static readonly string find_engine_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/find-engine.min.js") ? Url("find-engine.min.js") : Url("find-engine.js");
        public static readonly string ge_for_gamers_block_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/ge-for-gamers-block.min.js") ? Url("ge-for-gamers-block.min.js") : Url("ge-for-gamers-block.js");
        public static readonly string ge_game_menu_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/ge-game-menu.min.js") ? Url("ge-game-menu.min.js") : Url("ge-game-menu.js");
        public static readonly string ge_last_news_block_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/ge-last-news-block.min.js") ? Url("ge-last-news-block.min.js") : Url("ge-last-news-block.js");
        public static readonly string like_engine_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(URLPATH + "/like-engine.min.js") ? Url("like-engine.min.js") : Url("like-engine.js");
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
            public static class i {
                private const string URLPATH = "~/Content/dist/i";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string article_empty_png = Url("article-empty.png");
                public static readonly string faveicon_png = Url("faveicon.png");
                public static readonly string footer_bg_lg_jpg = Url("footer-bg-lg.jpg");
                public static readonly string footer_bg_md_jpg = Url("footer-bg-md.jpg");
                public static readonly string footer_bg_sm_jpg = Url("footer-bg-sm.jpg");
                public static readonly string footer_bg_xs_jpg = Url("footer-bg-xs.jpg");
            }
        
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public static class js {
                private const string URLPATH = "~/Content/dist/js";
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath(URLPATH); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(URLPATH + "/" + fileName); }
                public static readonly string ge_for_gamers_block_min_js = Url("ge-for-gamers-block.min.js");
                public static readonly string ge_last_news_block_min_js = Url("ge-last-news-block.min.js");
                public static readonly string site_min_js = Url("site.min.js");
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
                public const string _references_js = "~/Scripts/_references.js"; 
                public const string click_stat_handler_js = "~/Scripts/click-stat-handler.js"; 
                public const string find_engine_js = "~/Scripts/find-engine.js"; 
                public const string ge_for_gamers_block_js = "~/Scripts/ge-for-gamers-block.js"; 
                public const string ge_game_menu_js = "~/Scripts/ge-game-menu.js"; 
                public const string ge_last_news_block_js = "~/Scripts/ge-last-news-block.js"; 
                public const string like_engine_js = "~/Scripts/like-engine.js"; 
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
                        public const string site_min_css = "~/Content/dist/css/site.min.css";
                    }
                }
                public static partial class fonts 
                {
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
                public static partial class js 
                {
                    public static class Assets
                    {
                        public const string ge_for_gamers_block_min_js = "~/Content/dist/js/ge-for-gamers-block.min.js"; 
                        public const string ge_last_news_block_min_js = "~/Content/dist/js/ge-last-news-block.min.js"; 
                        public const string site_min_js = "~/Content/dist/js/site.min.js"; 
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


