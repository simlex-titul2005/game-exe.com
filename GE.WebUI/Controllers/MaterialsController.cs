﻿using SX.WebCore;
using System.Web.Mvc;
using SX.WebCore.MvcControllers;
using GE.WebUI.ViewModels.Abstracts;
using SX.WebCore.ViewModels;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using SX.WebCore.DbModels.Abstract;
using SX.WebCore.DbModels;
using GE.WebUI.Infrastructure.Repositories;

namespace GE.WebUI.Controllers
{
    public abstract class MaterialsController<TModel, TViewModel> : SxMaterialsController<TModel, TViewModel>
        where TModel : SxMaterial, new()
        where TViewModel : VMMaterial, new()
    {
        protected MaterialsController(byte mct) : base(mct)
        {
            BeforeSelectListFunction = BeforeSelectListAction;
        }

        private bool BeforeSelectListAction(SxFilter filter)
        {
            var routeDataValues = Request.RequestContext.RouteData.Values;
            var gameTitle = (string)routeDataValues["gameTitle"];
            ViewBag.GameTitle = gameTitle;
            filter.AddintionalInfo = new object[] { null, gameTitle };
            if (gameTitle != null)
            {
                var existGame = GamesController.Repo.ExistGame(gameTitle);
                if (!existGame)
                {
                    return false;
                }
            }


            switch (ModelCoreType)
            {
                case 1://article
                    filter.PagerInfo.PageSize = 9;
                    break;
                case 2://news
                    filter.PagerInfo.PageSize = 10;
                    break;
                //TODO: убрать 7
                case 7://humor
                    filter.PagerInfo.PageSize = 12;
                    break;
            }

            return true;
        }

#if !DEBUG
        [OutputCache(Duration =900, VaryByParam ="MaterialId;ModelCoreType")]
#endif
        [HttpGet]
        public virtual async Task<ActionResult> Details(int year, string month, string day, string titleUrl)
        {
            VMMaterial model = null;
            switch (ModelCoreType)
            {
                case 1://article
                    model = await Repo.GetByTitleUrlAsync(year, month, day, titleUrl);
                    break;
                case 2://news
                    model = await Repo.GetByTitleUrlAsync(year, month, day, titleUrl);
                    break;
                case 7://humor
                    model = await Repo.GetByTitleUrlAsync(year, month, day, titleUrl);
                    break;
            }

            if (model == null) return new HttpNotFoundResult();

            SxBBCodeParser.Replace(
                material: model,
                pictureUrl: x => Url.Action("Picture", "Pictures", new { id = x.Id }),
                videoUrl: x=>Url.Action("Details", "YoutubeVideos", new { videoId=x.VideoId }),
                replaceOtherAction: replaceInfographics
            );

            var seoTags = await SxSeoTagsController.Repo.GetSeoTagsAsync(model.Id, model.ModelCoreType);
            var matSeoInfo = Mapper.Map<SxSeoTags, SxVMSeoTags>(seoTags);

            ViewBag.Title = ViewBag.Title ?? matSeoInfo?.SeoTitle ?? model.Title;
            ViewBag.Description = ViewBag.Description ?? matSeoInfo?.SeoDescription ?? model.Foreword;
            ViewBag.Keywords = ViewBag.Keywords ?? matSeoInfo?.KeywordsString;
            ViewBag.H1 = ViewBag.H1 ?? matSeoInfo?.H1 ?? model.Title;
            ViewBag.PageImage = ViewBag.PageImage ?? matSeoInfo?.PageImageId;

            CultureInfo ci = new CultureInfo("en-US");
            ViewBag.LastModified = model.DateUpdate.ToString("ddd, dd MMM yyyy HH:mm:ss 'GMT'", ci);

            if (model.Game != null)
                ViewBag.GameName = model.Game.TitleUrl.ToLower();

            var breadcrumbs = (SxVMBreadcrumb[])ViewBag.Breadcrumbs;
            if (breadcrumbs != null)
            {
                var bc = breadcrumbs.ToList();
                if(model.Category!=null)
                    bc.Add(new SxVMBreadcrumb { Title = model.Category.Title, Url=Url.Action("Index", new { cat=model.Category.Id }) });

                bc.Add(new SxVMBreadcrumb { Title = ViewBag.Title });
                ViewBag.Breadcrumbs = bc.ToArray();
            }

            if (!Request.IsLocal)
            {
                //update views count
                await Repo.AddUserViewAsync(model.Id, model.ModelCoreType, ()=> {
                    model.ViewsCount++;
                });
            }

            return View(model);
        }

        private void replaceInfographics(SxVMMaterial model)
        {
            BBCodeParserConfig.ReplaceInfographics(Url, model);
        }

#if !DEBUG
        [OutputCache(Duration =900, VaryByParam ="mct;lmc;gc;lgmc;gtc")]
#endif
        [ChildActionOnly]
        public virtual ActionResult LastMaterialsBlock(int lmc = 5, int gc = 4, int lgmc = 3, int gtc = 20, string bh=null)
        {
            ViewBag.BlockHeader = bh;
            var viewModel = (Repo as RepoMaterial<TModel, TViewModel>).GetLastMaterialBlock(lmc, gc, lgmc, gtc);
            return PartialView("_LastMaterialsBlock", viewModel);
        }
    }
}