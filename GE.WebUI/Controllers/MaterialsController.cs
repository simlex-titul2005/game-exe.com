﻿using GE.WebCoreExtantions;
using GE.WebCoreExtantions.Abstract;
using GE.WebCoreExtantions.Repositories;
using GE.WebUI.Models;
using GE.WebUI.Models.Abstract;
using SX.WebCore;
using SX.WebCore.Abstract;
using SX.WebCore.HtmlHelpers;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using GE.WebUI.Extantions.Repositories;

namespace GE.WebUI.Controllers
{
    public abstract partial class MaterialsController<TKey, TModel> : BaseController where TModel : SxDbModel<TKey>, IHasGame
    {
        private SxDbRepository<TKey, TModel, DbContext> _repo;
        private SxDbRepository<int, Game, DbContext> _repoGame;
        protected MaterialsController() { }
        private Enums.ModelCoreType _modelCoreType;
        protected MaterialsController(Enums.ModelCoreType modelCoreType)
        {
            _repoGame = new RepoGame();
            _modelCoreType = modelCoreType;
            switch (_modelCoreType)
            {
                case Enums.ModelCoreType.Article:
                    _repo = new RepoArticle() as SxDbRepository<TKey, TModel, DbContext>;
                    break;
                case Enums.ModelCoreType.News:
                    _repo = new RepoNews() as SxDbRepository<TKey, TModel, DbContext>;
                    break;
                default:
                    throw new NotSupportedException("Не определен репозиторий");
            }
        }
        protected SxDbRepository<TKey, TModel, DbContext> Repository
        {
            get
            {
                return _repo;
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult List(GE.WebCoreExtantions.Filter filter)
        {
            ViewBag.GameTitle = filter.GameTitle;

            if(filter.GameTitle!=null)
            {
                var existGame = (_repoGame as RepoGame).ExistGame(filter.GameTitle);
                if(!existGame)
                {
                    Response.StatusCode = 404;
                    Response.Clear();
                    return null;
                }
            }

            var pageSize = 10;
            switch (_modelCoreType)
            {
                case Enums.ModelCoreType.Article:
                    pageSize = 9;
                    break;
                case Enums.ModelCoreType.News:
                    pageSize = 10;
                    break;
            }

            var viewModel = new SxExtantions.SxPagedCollection<TModel>();
            filter.PageSize = pageSize;
            filter.SkipCount = pageSize * (filter.Page - 1);
            viewModel.Collection = _repo.Query(filter).ToArray();
            viewModel.PagerInfo = new SxExtantions.SxPagerInfo
            {
                Page = filter.Page,
                PageSize = pageSize,
                PagerSize = 3,
                TotalItems = _repo.Count(filter)
            };

            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult Details(int year, string month, string day, string titleUrl)
        {
            VMDetailMaterial model = null;
            switch (_modelCoreType)
            {
                case Enums.ModelCoreType.Article:
                    model = (_repo as RepoArticle).GetByTitleUrl(titleUrl);
                    break;
                case Enums.ModelCoreType.News:
                    model = (_repo as RepoNews).GetByTitleUrl(titleUrl);
                    break;
            }
            if (model == null)
            {
                Response.StatusCode = 404;
                Response.Clear();
                return null;
            }
            else
            {
                if (ViewBag.Title == null)
                    ViewBag.Title = model.Title;
                if (ViewBag.H1 == null)
                    ViewBag.H1 = model.Title;
                if (model.GameTitleUrl != null)
                    ViewBag.GameName = model.GameTitleUrl.ToLowerInvariant();

                var viewsCount = model.ViewsCount;

                var breadcrumbs = (VMBreadcrumb[])ViewBag.Breadcrumbs;
                if(breadcrumbs!=null)
                {
                    var bc=breadcrumbs.ToList();
                    bc.Add(new VMBreadcrumb{Title=ViewBag.Title});
                    ViewBag.Breadcrumbs = bc.ToArray();
                }

                //update views count
                if (!Request.IsLocal)
                {
                    Task.Run(() =>
                    {
                        switch (_modelCoreType)
                        {
                            case Enums.ModelCoreType.Article:
                                (_repo as RepoArticle).Update(new Article { Id = model.Id, ModelCoreType = model.ModelCoreType, ViewsCount = viewsCount + 1 }, "ViewsCount");
                                break;
                            case Enums.ModelCoreType.News:
                                (_repo as RepoNews).Update(new News { Id = model.Id, ModelCoreType = model.ModelCoreType, ViewsCount = viewsCount + 1 }, "ViewsCount");
                                break;
                        }
                    });
                }

                model.ViewsCount = viewsCount + 1;

                return View(model);
            }
        }
    }
}