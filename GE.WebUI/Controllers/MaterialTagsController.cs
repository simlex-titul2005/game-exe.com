﻿using GE.WebCoreExtantions;
using GE.WebCoreExtantions.Repositories;
using GE.WebUI.Extantions.Repositories;
using SX.WebCore;
using SX.WebCore.Abstract;
using System.Web.Mvc;
using static SX.WebCore.Enums;

namespace GE.WebUI.Controllers
{
    public partial class MaterialTagsController : BaseController
    {
        private SxDbRepository<string, SxMaterialTag, DbContext> _repo;
        public MaterialTagsController()
        {
            _repo = new RepoMaterialTag();
        }

#if !DEBUG
        [OutputCache(Duration =900, VaryByParam = "mid;mct")]
#endif
        [AcceptVerbs(HttpVerbs.Get)]
        public virtual PartialViewResult List(int mid, ModelCoreType mct, int maxFs=30, int amount=50)
        {
            var filter = new SxFilter(1, 10) { MaterialId= mid, ModelCoreType=mct };
            var viewModel = (_repo as RepoMaterialTag).GetCloud(filter);
            string url = "#";
            switch(mct)
            {
                case ModelCoreType.Article:
                    url = Url.Action("~/views/articles/list.cshtml");
                    break;
                case ModelCoreType.News:
                    url = Url.Action("~/views/news/list.cshtml");
                    break;
            }
            ViewData["TagsMaxFs"] = maxFs;
            ViewData["TagsUrl"] = url;
            ViewData["TagsShowHeader"] = true;
            return PartialView("~/views/MaterialTags/_TagsCloud.cshtml", viewModel);
        }
    }
}