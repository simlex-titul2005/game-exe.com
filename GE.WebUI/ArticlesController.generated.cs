// <auto-generated />
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
namespace GE.WebUI.Controllers
{
    public partial class ArticlesController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ArticlesController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Preview()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Preview);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ViewResult List()
        {
            return new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.List);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ViewResult Details()
        {
            return new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.Details);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ArticlesController Actions { get { return MVC.Articles; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Articles";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Articles";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string ForGamersBlock = "ForGamersBlock";
            public readonly string Preview = "Preview";
            public readonly string Last = "Last";
            public readonly string List = "List";
            public readonly string Details = "Details";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string ForGamersBlock = "ForGamersBlock";
            public const string Preview = "Preview";
            public const string Last = "Last";
            public const string List = "List";
            public const string Details = "Details";
        }


        static readonly ActionParamsClass_Preview s_params_Preview = new ActionParamsClass_Preview();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Preview PreviewParams { get { return s_params_Preview; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Preview
        {
            public readonly string gameId = "gameId";
            public readonly string articleType = "articleType";
            public readonly string lettersCount = "lettersCount";
        }
        static readonly ActionParamsClass_Last s_params_Last = new ActionParamsClass_Last();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Last LastParams { get { return s_params_Last; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Last
        {
            public readonly string amount = "amount";
        }
        static readonly ActionParamsClass_List s_params_List = new ActionParamsClass_List();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_List ListParams { get { return s_params_List; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_List
        {
            public readonly string filter = "filter";
        }
        static readonly ActionParamsClass_Details s_params_Details = new ActionParamsClass_Details();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Details DetailsParams { get { return s_params_Details; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Details
        {
            public readonly string year = "year";
            public readonly string month = "month";
            public readonly string day = "day";
            public readonly string titleUrl = "titleUrl";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string _Collection = "_Collection";
                public readonly string _ForGamersBlock = "_ForGamersBlock";
                public readonly string _Last = "_Last";
                public readonly string _Preview = "_Preview";
                public readonly string Details = "Details";
                public readonly string List = "List";
            }
            public readonly string _Collection = "~/Views/Articles/_Collection.cshtml";
            public readonly string _ForGamersBlock = "~/Views/Articles/_ForGamersBlock.cshtml";
            public readonly string _Last = "~/Views/Articles/_Last.cshtml";
            public readonly string _Preview = "~/Views/Articles/_Preview.cshtml";
            public readonly string Details = "~/Views/Articles/Details.cshtml";
            public readonly string List = "~/Views/Articles/List.cshtml";
            static readonly _DisplayTemplatesClass s_DisplayTemplates = new _DisplayTemplatesClass();
            public _DisplayTemplatesClass DisplayTemplates { get { return s_DisplayTemplates; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _DisplayTemplatesClass
            {
                public readonly string Article = "Article";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_ArticlesController : GE.WebUI.Controllers.ArticlesController
    {
        public T4MVC_ArticlesController() : base(Dummy.Instance) { }

        [NonAction]
        partial void ForGamersBlockOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult ForGamersBlock()
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.ForGamersBlock);
            ForGamersBlockOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void PreviewOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int gameId, string articleType, int lettersCount);

        [NonAction]
        public override System.Web.Mvc.ActionResult Preview(int gameId, string articleType, int lettersCount)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Preview);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "gameId", gameId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "articleType", articleType);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "lettersCount", lettersCount);
            PreviewOverride(callInfo, gameId, articleType, lettersCount);
            return callInfo;
        }

        [NonAction]
        partial void LastOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, int amount);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult Last(int amount)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Last);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "amount", amount);
            LastOverride(callInfo, amount);
            return callInfo;
        }

        [NonAction]
        partial void ListOverride(T4MVC_System_Web_Mvc_ViewResult callInfo, GE.WebCoreExtantions.Filter filter);

        [NonAction]
        public override System.Web.Mvc.ViewResult List(GE.WebCoreExtantions.Filter filter)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.List);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "filter", filter);
            ListOverride(callInfo, filter);
            return callInfo;
        }

        [NonAction]
        partial void DetailsOverride(T4MVC_System_Web_Mvc_ViewResult callInfo, int year, string month, string day, string titleUrl);

        [NonAction]
        public override System.Web.Mvc.ViewResult Details(int year, string month, string day, string titleUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.Details);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "year", year);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "month", month);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "day", day);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "titleUrl", titleUrl);
            DetailsOverride(callInfo, year, month, day, titleUrl);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
