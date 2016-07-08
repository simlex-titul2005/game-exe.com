﻿using GE.WebCoreExtantions;
using GE.WebCoreExtantions.Repositories;
using GE.WebUI.Models;
using System.Web.Mvc;
using GE.WebUI.Extantions.Repositories;
using System.Linq;
using SX.WebCore;
using System.Threading.Tasks;

namespace GE.WebUI.Controllers
{
    public sealed class AphorismsController : BaseController
    {
        private static RepoAphorism _repo;
        public AphorismsController()
        {
            if(_repo==null)
                _repo = new RepoAphorism();
        }

        [HttpGet]
        public ActionResult Details(string categoryId, string titleUrl)
        {
            var viewModel = (_repo as RepoAphorism).GetByTitleUrl(categoryId, titleUrl);
            
            if(viewModel.Aphorism.Author!=null)
                ViewBag.Author = viewModel.Aphorism.Author;
            else
                ViewBag.CurrentAphorismCategory = getCurrentCategory(categoryId);

            if (viewModel == null || viewModel.Aphorism == null)
                return new HttpStatusCodeResult(404);

            //update views count
            if (!Request.IsLocal)
            {
                Task.Run(() =>
                {
                    (_repo as RepoAphorism).AddUserView(viewModel.Aphorism.Id, Enums.ModelCoreType.Aphorism);
                });
            }
            return View(viewModel);
        }


        [OutputCache(Duration = 900, VaryByParam = "curCat")]
        [HttpGet, ChildActionOnly]
        public PartialViewResult Categories(string curCat = null)
        {
            var viewModel = (_repo as RepoAphorism).GetAphorismCategories(curCat);

            return PartialView("_Categories", model: viewModel);
        }

        private static int _pageSize = 20;
        [HttpGet]
        public ViewResult List(string categoryId = null, int page = 1)
        {
            var author = Request.QueryString["author"];
            if (!string.IsNullOrWhiteSpace(author))
                ViewBag.Author = Mapper.Map<AuthorAphorism, VMAuthorAphorism>(new RepoAuthorAphorism().GetByTitleUrl(author));
            if(!string.IsNullOrWhiteSpace(categoryId))
                ViewBag.CurrentAphorismCategory = getCurrentCategory(categoryId);


            var filter = new SxFilter(page, _pageSize) {
                WhereExpressionObject = new VMAphorism { CategoryId = categoryId, Author = new VMAuthorAphorism { TitleUrl = author } },
                OnlyShow = true
            };
            var totalItems = (_repo as RepoAphorism).Count(filter);
            filter.PagerInfo.TotalItems = totalItems;
            filter.PagerInfo.PagerSize = 5;
            ViewBag.PagerInfo = filter.PagerInfo;
            

            var data = _repo.Query(filter).ToArray();
            var viewModel = data.Select(x => Mapper.Map<Aphorism, VMAphorism>(x)).ToArray();
            return View(viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public RedirectToRouteResult Search(string author, string html)
        {
            return RedirectToAction("list", new { author = author, html = html });
        }

        private VMMaterialCategory getCurrentCategory(string categoryId=null)
        {
            if (categoryId == null) return null;

            var data = new RepoMaterialCategory().GetByKey(categoryId);
            return Mapper.Map<MaterialCategory, VMMaterialCategory>(data);
        }
    }
}