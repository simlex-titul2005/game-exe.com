﻿using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web.Mvc;
using Dapper;
using System.Linq;
using static SX.WebCore.Enums;
using SX.WebCore;
using SX.WebCore.Abstract;
using GE.WebUI.Infrastructure;

namespace GE.WebUI.Controllers
{
    public partial class SeoController : Controller
    {
        private static ISxSiteMapProvider _smProvider;
        static SeoController()
        {
            _smProvider = SiteMapProvider.Create();
        }

        [OutputCache(Duration = 900)]
        public virtual ContentResult Robotstxt()
        {
            var fileContent = SiteSettings.Get(SX.WebCore.Resources.Settings.robotsFileSetting);
            if (fileContent != null)
                return Content(fileContent.Value, "text/plain", Encoding.UTF8);
            else return null;
        }

#if !DEBUG
        [OutputCache(Duration = 3600)]
#endif
        public virtual ContentResult Sitemap()
        {
            var query = @"SELECT
	dm.TitleUrl,
	dm.DateCreate,
	dm.DateUpdate,
	dm.ModelCoreType
FROM DV_MATERIAL AS dm
ORDER BY dm.DateUpdate DESC";

            SxSiteMapUrl[] data = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString))
            {
                data = connection.Query<dynamic>(query)
                    .Select(x => new SxSiteMapUrl(getSiteMapLoc(Url, x))
                    {
                        LasMod = x.DateCreate
                    }).ToArray();
            }

            return Content(_smProvider.GenerateSiteMap(data), "text/xml");
        }

        private static string getSiteMapLoc(UrlHelper helper, dynamic model)
        {
            var au = helper.RequestContext.HttpContext.Request.Url.AbsoluteUri;
            var vu = helper.RequestContext.HttpContext.Request.RawUrl;
            var hu = au.Substring(0, au.Length - vu.Length);
            var mct = (ModelCoreType)model.ModelCoreType;
            switch (mct)
            {
                case ModelCoreType.Article:
                    return hu + helper.Action(MVC.Articles.Details(
                        (int)model.DateCreate.Year,
                        (string)model.DateCreate.Month.ToString("00"),
                        (string)model.DateCreate.Day.ToString("00"),
                        (string)model.TitleUrl
                        ));
                case ModelCoreType.News:
                    return hu + helper.Action(MVC.News.Details(
                        (int)model.DateCreate.Year,
                        (string)model.DateCreate.Month.ToString("00"),
                        (string)model.DateCreate.Day.ToString("00"),
                        (string)model.TitleUrl
                        ));
                default: return null;
            }
        }
    }
}