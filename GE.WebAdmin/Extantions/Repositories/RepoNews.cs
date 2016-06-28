﻿using Dapper;
using GE.WebAdmin.Models;
using GE.WebCoreExtantions;
using GE.WebCoreExtantions.Repositories;
using SX.WebCore;
using SX.WebCore.Providers;
using System.Data.SqlClient;
using System.Linq;
using static SX.WebCore.HtmlHelpers.SxExtantions;

namespace GE.WebAdmin.Extantions.Repositories
{
    public static partial class RepositoryExtantions
    {
        public static News GetByTitleUrl(this RepoNews repo, string titleUrl)
        {
            using (var conn = new SqlConnection(repo.ConnectionString))
            {
                var query = @"SELECT*FROM D_ARTICLE AS da
JOIN DV_MATERIAL AS dm ON dm.ID = da.ID AND dm.ModelCoreType = da.ModelCoreType
WHERE dm.TitleUrl=@TITLE_URL";

                return conn.Query<News>(query, new { TITLE_URL = titleUrl }).FirstOrDefault();
            }
        }

        public static VMNews[] QueryForAdmin(this RepoNews repo, SxFilter filter)
        {
            var query = SxQueryProvider.GetSelectString(new string[] { "da.Id", "dm.DateCreate", "dm.DateOfPublication", "dm.Title", "dm.SeoTagsId", "dm.Show" });
            query += " FROM D_NEWS AS da JOIN DV_MATERIAL AS dm ON dm.ID = da.ID AND dm.ModelCoreType = da.ModelCoreType LEFT JOIN D_GAME AS dg ON dg.ID = da.GameId ";

            object param = null;
            query += getNewsWhereString(filter, out param);

            var defaultOrder = new SxOrder { FieldName = "dm.DateCreate", Direction = SortDirection.Desc };
            query += SxQueryProvider.GetOrderString(defaultOrder, filter.Order);

            query += " OFFSET " + filter.PagerInfo.SkipCount + " ROWS FETCH NEXT " + filter.PagerInfo.PageSize + " ROWS ONLY";

            using (var conn = new SqlConnection(repo.ConnectionString))
            {
                var data = conn.Query<VMNews>(query, param: param);
                return data.ToArray();
            }
        }

        public static int FilterCount(this RepoNews repo, SxFilter filter)
        {
            var query = @"SELECT COUNT(1) FROM D_NEWS AS da JOIN DV_MATERIAL AS dm ON dm.ID = da.ID AND dm.ModelCoreType = da.ModelCoreType ";

            object param = null;
            query += getNewsWhereString(filter, out param);

            using (var conn = new SqlConnection(repo.ConnectionString))
            {
                var data = conn.Query<int>(query, param: param).Single();
                return data;
            }
        }

        private static string getNewsWhereString(SxFilter filter, out object param)
        {
            param = null;
            string query = null;
            query += " WHERE (dm.Title LIKE '%'+@title+'%' OR @title IS NULL) ";

            var title = filter.WhereExpressionObject != null && filter.WhereExpressionObject.Title != null ? (string)filter.WhereExpressionObject.Title : null;

            param = new
            {
                title = title
            };

            return query;
        }
    }
}