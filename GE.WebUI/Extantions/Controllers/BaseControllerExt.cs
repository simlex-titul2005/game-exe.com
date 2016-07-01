﻿using GE.WebCoreExtantions;
using GE.WebUI.Models;
using SX.WebCore.MvcControllers;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace GE.WebUI.Extantions.Controllers
{
    public static class BaseControllerExt
    {
        private static CacheItemPolicy _defaultPolicy
        {
            get
            {
                return new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(15)
                };
            }
        }

        public static void WriteBreadcrumbs(this SxBaseController<DbContext> controller)
        {
            var routes = controller.ControllerContext.RequestContext.RouteData.Values;
            var gameName = routes["game"] != null && !string.IsNullOrEmpty(routes["game"].ToString()) ? routes["game"].ToString() : null;

            var breadcrumbs = new List<VMBreadcrumb>();
            breadcrumbs.Add(new VMBreadcrumb { Title = "Главная", Url = "/" });
            if(controller.SxControllerName=="aphorisms")
            {
                if (controller.SxActionName == "list" || controller.SxActionName == "details")
                {
                    breadcrumbs.Add(new VMBreadcrumb { Title = "Афоризмы", Url = controller.Url.Action("list", new { controller= "Aphorisms" }) });
                }
            }
            else if (controller.SxControllerName == "articles")
            {
                if (controller.SxActionName == "list")
                {
                    breadcrumbs.Add(new VMBreadcrumb { Title = "Статьи", Url = controller.Url.Action("list", new { controller= "Articles" }) });
                    if (gameName != null)
                        breadcrumbs.Add(new VMBreadcrumb { Title = gameName });
                }
                else if (controller.SxActionName == "details")
                {
                    breadcrumbs.Add(new VMBreadcrumb { Title = "Статьи", Url = controller.Url.Action("list", new { controller= "Articles" }) });
                }
            }
            else if (controller.SxControllerName == "news")
            {
                if (controller.SxActionName == "list")
                {
                    breadcrumbs.Add(new VMBreadcrumb { Title = "Новости", Url = controller.Url.Action("list", new { controller= "News" }) });
                    if (gameName != null)
                        breadcrumbs.Add(new VMBreadcrumb { Title = gameName });
                }
                else if (controller.SxActionName == "details")
                {
                    breadcrumbs.Add(new VMBreadcrumb { Title = "Новости", Url = controller.Url.Action("list", new { controller = "News" }) });
                }
            }
            else if (controller.SxControllerName == "forum")
            {
                if (controller.SxActionName == "list")
                {
                    breadcrumbs.Add(new VMBreadcrumb { Title = "Форум", Url = controller.Url.Action("list", new { controller = "Forum" }) });
                    if (gameName != null)
                        breadcrumbs.Add(new VMBreadcrumb { Title = gameName });
                }
            }
            else if (controller.SxControllerName == "sitetests")
            {
                if (controller.SxActionName == "list" || controller.SxActionName == "details")
                    breadcrumbs.Add(new VMBreadcrumb { Title = "Тесты", Url = controller.Url.Action("list", "sitetests") });
            }

            controller.ViewBag.Breadcrumbs = breadcrumbs.ToArray();
        }
    }
}