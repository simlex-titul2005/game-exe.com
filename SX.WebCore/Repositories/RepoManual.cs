﻿using System.Linq;
using SX.WebCore.Abstract;
using SX.WebCore.Providers;
using System.Data.SqlClient;
using Dapper;
using static SX.WebCore.HtmlHelpers.SxExtantions;

namespace SX.WebCore.Repositories
{
    public sealed class RepoManual<TDbContext> : SxDbRepository<int, SxManual, TDbContext> where TDbContext: SxDbContext
    {
        public override IQueryable<SxManual> Query(SxFilter filter)
        {
            var query = QueryProvider.GetSelectString(new string[] { "da.Id", "dm.Title", "dm.CategoryId" });
            query += " FROM D_MANUAL AS da JOIN DV_MATERIAL AS dm ON dm.ID = da.ID AND dm.ModelCoreType = da.ModelCoreType LEFT JOIN D_MATERIAL_CATEGORY as dmc on dmc.Id=dm.CategoryId ";

            object param = null;
            query += getManualWhereString(filter, out param);

            query += QueryProvider.GetOrderString("dm.DateCreate", SortDirection.Desc, filter.Orders);

            query += " OFFSET " + filter.PagerInfo.SkipCount + " ROWS FETCH NEXT " + filter.PagerInfo.PageSize + " ROWS ONLY";

            using (var conn = new SqlConnection(ConnectionString))
            {
                var data = conn.Query<SxManual>(query, param: param);
                return data.AsQueryable();
            }
        }

        public override int Count(SxFilter filter)
        {
            var query = @"SELECT COUNT(1) FROM D_MANUAL AS da JOIN DV_MATERIAL AS dm ON dm.ID = da.ID AND dm.ModelCoreType = da.ModelCoreType ";

            object param = null;
            query += getManualWhereString(filter, out param);

            using (var conn = new SqlConnection(ConnectionString))
            {
                var data = conn.Query<int>(query, param: param).Single();
                return data;
            }
        }

        private static string getManualWhereString(SxFilter filter, out object param)
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