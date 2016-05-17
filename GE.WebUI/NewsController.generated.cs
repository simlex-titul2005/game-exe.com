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
    public partial class NewsController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected NewsController(Dummy d) { }

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
        public virtual System.Web.Mvc.ViewResult List()
        {
            return new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.List);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.PartialViewResult LikeMaterials()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.LikeMaterials);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ViewResult Details()
        {
            return new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.Details);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.PartialViewResult ByDateMaterial()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.ByDateMaterial);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.PartialViewResult Popular()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Popular);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public NewsController Actions { get { return MVC.News; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "News";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "News";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string LastGamesNewsBlock = "LastGamesNewsBlock";
            public readonly string NewsCategories = "NewsCategories";
            public readonly string List = "List";
            public readonly string LikeMaterials = "LikeMaterials";
            public readonly string Details = "Details";
            public readonly string ByDateMaterial = "ByDateMaterial";
            public readonly string Popular = "Popular";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string LastGamesNewsBlock = "LastGamesNewsBlock";
            public const string NewsCategories = "NewsCategories";
            public const string List = "List";
            public const string LikeMaterials = "LikeMaterials";
            public const string Details = "Details";
            public const string ByDateMaterial = "ByDateMaterial";
            public const string Popular = "Popular";
        }


        static readonly ActionParamsClass_LastGamesNewsBlock s_params_LastGamesNewsBlock = new ActionParamsClass_LastGamesNewsBlock();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_LastGamesNewsBlock LastGamesNewsBlockParams { get { return s_params_LastGamesNewsBlock; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_LastGamesNewsBlock
        {
            public readonly string lnc = "lnc";
            public readonly string gc = "gc";
            public readonly string glnc = "glnc";
            public readonly string gtc = "gtc";
        }
        static readonly ActionParamsClass_NewsCategories s_params_NewsCategories = new ActionParamsClass_NewsCategories();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_NewsCategories NewsCategoriesParams { get { return s_params_NewsCategories; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_NewsCategories
        {
            public readonly string lnc = "lnc";
            public readonly string clnc = "clnc";
            public readonly string ctc = "ctc";
        }
        static readonly ActionParamsClass_List s_params_List = new ActionParamsClass_List();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_List ListParams { get { return s_params_List; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_List
        {
            public readonly string filter = "filter";
        }
        static readonly ActionParamsClass_LikeMaterials s_params_LikeMaterials = new ActionParamsClass_LikeMaterials();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_LikeMaterials LikeMaterialsParams { get { return s_params_LikeMaterials; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_LikeMaterials
        {
            public readonly string filter = "filter";
            public readonly string amount = "amount";
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
        static readonly ActionParamsClass_ByDateMaterial s_params_ByDateMaterial = new ActionParamsClass_ByDateMaterial();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ByDateMaterial ByDateMaterialParams { get { return s_params_ByDateMaterial; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ByDateMaterial
        {
            public readonly string mid = "mid";
            public readonly string mct = "mct";
            public readonly string dir = "dir";
            public readonly string amount = "amount";
        }
        static readonly ActionParamsClass_Popular s_params_Popular = new ActionParamsClass_Popular();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Popular PopularParams { get { return s_params_Popular; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Popular
        {
            public readonly string mct = "mct";
            public readonly string mid = "mid";
            public readonly string amount = "amount";
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
                public readonly string _LastCategoryBlock = "_LastCategoryBlock";
                public readonly string _LastNewsBlock = "_LastNewsBlock";
                public readonly string _NewsCategories = "_NewsCategories";
                public readonly string Details = "Details";
                public readonly string List = "List";
            }
            public readonly string _Collection = "~/Views/News/_Collection.cshtml";
            public readonly string _LastCategoryBlock = "~/Views/News/_LastCategoryBlock.cshtml";
            public readonly string _LastNewsBlock = "~/Views/News/_LastNewsBlock.cshtml";
            public readonly string _NewsCategories = "~/Views/News/_NewsCategories.cshtml";
            public readonly string Details = "~/Views/News/Details.cshtml";
            public readonly string List = "~/Views/News/List.cshtml";
            static readonly _DisplayTemplatesClass s_DisplayTemplates = new _DisplayTemplatesClass();
            public _DisplayTemplatesClass DisplayTemplates { get { return s_DisplayTemplates; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _DisplayTemplatesClass
            {
                public readonly string News = "News";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_NewsController : GE.WebUI.Controllers.NewsController
    {
        public T4MVC_NewsController() : base(Dummy.Instance) { }

        [NonAction]
        partial void LastGamesNewsBlockOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, int lnc, int gc, int glnc, int gtc);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult LastGamesNewsBlock(int lnc, int gc, int glnc, int gtc)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.LastGamesNewsBlock);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "lnc", lnc);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "gc", gc);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "glnc", glnc);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "gtc", gtc);
            LastGamesNewsBlockOverride(callInfo, lnc, gc, glnc, gtc);
            return callInfo;
        }

        [NonAction]
        partial void NewsCategoriesOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, int lnc, int clnc, int ctc);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult NewsCategories(int lnc, int clnc, int ctc)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.NewsCategories);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "lnc", lnc);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "clnc", clnc);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "ctc", ctc);
            NewsCategoriesOverride(callInfo, lnc, clnc, ctc);
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
        partial void LikeMaterialsOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, GE.WebCoreExtantions.Filter filter, int amount);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult LikeMaterials(GE.WebCoreExtantions.Filter filter, int amount)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.LikeMaterials);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "filter", filter);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "amount", amount);
            LikeMaterialsOverride(callInfo, filter, amount);
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

        [NonAction]
        partial void ByDateMaterialOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, int mid, SX.WebCore.Enums.ModelCoreType mct, bool dir, int amount);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult ByDateMaterial(int mid, SX.WebCore.Enums.ModelCoreType mct, bool dir, int amount)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.ByDateMaterial);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "mid", mid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "mct", mct);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "dir", dir);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "amount", amount);
            ByDateMaterialOverride(callInfo, mid, mct, dir, amount);
            return callInfo;
        }

        [NonAction]
        partial void PopularOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, SX.WebCore.Enums.ModelCoreType mct, int mid, int amount);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult Popular(SX.WebCore.Enums.ModelCoreType mct, int mid, int amount)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Popular);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "mct", mct);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "mid", mid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "amount", amount);
            PopularOverride(callInfo, mct, mid, amount);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
