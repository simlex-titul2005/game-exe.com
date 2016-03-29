﻿using GE.WebCoreExtantions;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using GE.WebCoreExtantions.Repositories;
using SX.WebCore.HtmlHelpers;
using SX.WebCore.Providers;
using GE.WebAdmin.Models;
using static SX.WebCore.Enums;

namespace GE.WebAdmin.Extantions.Repositories
{
    public static partial class RepositoryExtantions
    {
        public static VMMaterialTag[] QueryForAdmin(this RepoMaterialTag repo, int mid, ModelCoreType mct, Filter filter)
        {
            var query = QueryProvider.GetSelectString(new string[] { "dmt.Id", "dmt.DateCreate", "dmt.MaterialId", "dmt.ModelCoreType" });
            query += " FROM D_MATERIAL_TAG AS dmt";

            object param = null;
            query += getMaterialTagWhereString(mid, mct, filter, out param);

            query += QueryProvider.GetOrderString("dmt.DateCreate", SxExtantions.SortDirection.Desc, filter.Orders);

            if (filter != null && filter.SkipCount.HasValue && filter.PageSize.HasValue)
                query += " OFFSET " + filter.SkipCount + " ROWS FETCH NEXT " + filter.PageSize + " ROWS ONLY";

            using (var conn = new SqlConnection(repo.ConnectionString))
            {
                var data = conn.Query<VMMaterialTag>(query, param: param);
                return data.ToArray();
            }
        }

        public static int FilterCount(this RepoMaterialTag repo, int mid, ModelCoreType mct, Filter filter)
        {
            var query = @"SELECT COUNT(1) FROM D_MATERIAL_TAG AS dmt";

            object param = null;
            query += getMaterialTagWhereString(mid, mct, filter, out param);

            using (var conn = new SqlConnection(repo.ConnectionString))
            {
                var data = conn.Query<int>(query, param: param).Single();
                return data;
            }
        }

        private static string getMaterialTagWhereString(int mid, ModelCoreType mct, Filter filter, out object param)
        {
            param = null;
            string query = null;
            query += " WHERE (dmt.Id LIKE '%'+@id+'%' OR @id IS NULL)";
            query += " AND (dmt.MaterialId=@mid AND dmt.ModelCoreType=@mct)";

            var id = filter.WhereExpressionObject != null && filter.WhereExpressionObject.Id != null ? (string)filter.WhereExpressionObject.Id : null;

            param = new
            {
                id = id,
                mid = mid,
                mct = mct
            };

            return query;
        }
    }
}