﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SX.WebCore.Abstract;
using SX.WebCore;

namespace GE.WebCoreExtantions.Repositories
{
    public sealed class RepoArticle : SX.WebCore.Abstract.SxDbRepository<int, Article, DbContext>
    {
        public override IQueryable<Article> All
        {
            get
            {
                using (var conn = new SqlConnection(base.ConnectionString))
                {
                    var query = @"SELECT * FROM D_ARTICLE AS da
JOIN DV_MATERIAL AS dm ON dm.ID = da.ID AND dm.ModelCoreType = da.ModelCoreType
ORDER BY dm.DateCreate DESC";

                    return conn.Query<Article>(query).AsQueryable();
                }
            }
        }

        public override IQueryable<Article> Query(SxFilter filter)
        {
            var f = (Filter)filter;
            using (var conn = new SqlConnection(base.ConnectionString))
            {
                var query = @"SELECT da.Id,
       dm.TitleUrl,
       dm.FrontPictureId,
       dm.ShowFrontPictureOnDetailPage,
       dm.Title,
       SUBSTRING(
           CASE 
                WHEN dm.Foreword IS NOT NULL THEN dm.Foreword
                ELSE dbo.FUNC_STRIP_HTML(dm.HTML)
           END,
           0,
           400
       )                 AS Foreword,
       dm.DateCreate,
       dm.DateOfPublication,
       dm.ViewsCount,
       dm.CommentsCount,
       dm.UserId,
       anu.NikName,
       da.GameId,
       dg.Title,
       dg.TitleUrl,
       dg.BadPictureId
FROM   D_ARTICLE         AS da
       JOIN DV_MATERIAL  AS dm
            ON  dm.Id = da.ID
            AND dm.ModelCoreType = da.ModelCoreType
       LEFT JOIN AspNetUsers AS anu ON anu.Id=dm.UserId
       LEFT JOIN D_GAME  AS dg
            ON  dg.Id = da.GameId WHERE  (dg.TitleUrl = @GAME_TITLE_URL
       OR  @GAME_TITLE_URL IS NULL) AND dm.DateOfPublication <= GETDATE() AND dm.Show=1";
                query += @" ORDER BY
       dm.DateCreate DESC";
                if (f != null && f.SkipCount.HasValue && f.PageSize.HasValue)
                    query += " OFFSET " + filter.SkipCount + " ROWS FETCH NEXT " + filter.PageSize + " ROWS ONLY";

                var data = conn.Query<Article, SxAppUser, Game, Article>(query, (da, anu, dg)=> {
                    da.Game = dg;
                    da.User = anu;
                    return da;
                }, new { GAME_TITLE_URL = f.GameTitle }, splitOn:"UserId, GameId");

                return data.AsQueryable();
            }
        }

        public override int Count(SxFilter filter)
        {
            var f = (Filter)filter;
            using (var conn = new SqlConnection(base.ConnectionString))
            {
                var query = @"SELECT COUNT(1) FROM D_ARTICLE AS da
LEFT JOIN D_GAME dg ON dg.Id=da.GameId
WHERE @TITLE_URL IS NULL OR dg.TitleUrl=@TITLE_URL";
                var data = f != null && !string.IsNullOrEmpty(f.GameTitle)
                    ? conn.Query<int>(query, new { TITLE_URL = f.GameTitle }).Single()
                    : conn.Query<int>(query, new { TITLE_URL = (string)null }).Single();

                return (int)data;
            }
        }
    }
}
