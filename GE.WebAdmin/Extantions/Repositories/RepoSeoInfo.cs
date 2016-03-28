﻿using GE.WebCoreExtantions;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using GE.WebAdmin.Models;
using SX.WebCore;
using SX.WebCore.HtmlHelpers;
using SX.WebCore.Providers;

namespace GE.WebAdmin.Extantions.Repositories
{
    public static partial class RepositoryExtantions
    {
        public static IQueryable<VMSeoInfo> QueryForAdmin(this GE.WebCoreExtantions.Repositories.RepoSeoInfo repo, Filter filter)
        {
            string rawUrl = null;
            using (var conn = new SqlConnection(repo.ConnectionString))
            {
                var query = @"SELECT
	dsi.Id,
	dsi.RawUrl
FROM D_SEO_INFO AS dsi
WHERE @RAW_URL IS NULL OR dsi.RawUrl LIKE '%'+@RAW_URL+'%'
ORDER BY dsi.RawUrl";

                if (filter != null && filter.WhereExpressionObject != null && filter.WhereExpressionObject.RawUrl != null)
                    rawUrl = filter.WhereExpressionObject.RawUrl;

                query += QueryProvider.GetOrderString("dsi.RawUrl", SxExtantions.SortDirection.Asc, filter.Orders);
                
                if (filter != null && filter.SkipCount.HasValue && filter.PageSize.HasValue)
                    query += " OFFSET " + filter.SkipCount + " ROWS FETCH NEXT " + filter.PageSize + " ROWS ONLY";

                var data = conn.Query<VMSeoInfo>(query, new { RAW_URL = rawUrl });

                return data.AsQueryable();
            }
        }

        //найти страницу по rawUrl
        public static SxSeoInfo GetByRawUrl(this GE.WebCoreExtantions.Repositories.RepoSeoInfo repo, string rawUrl)
        {
            using (var conn = new SqlConnection(repo.ConnectionString))
            {
                var query = @"SELECT dsi.Id FROM D_SEO_INFO AS dsi WHERE dsi.RawUrl=@RAW_URL";
                var data = conn.Query<SxSeoInfo>(query, new { @RAW_URL = rawUrl });
                return data.SingleOrDefault();
            }
        }

        public static int FilterCount(this GE.WebCoreExtantions.Repositories.RepoSeoInfo repo, Filter filter)
        {
            using (var conn = new SqlConnection(repo.ConnectionString))
            {
                var query = @"SELECT COUNT(1) FROM D_SEO_INFO as dsi";
                string rawUrl = null;
                if (filter != null && filter.WhereExpressionObject != null && filter.WhereExpressionObject.RawUrl != null)
                    rawUrl = filter.WhereExpressionObject.RawUrl;
                query += " WHERE @RAW_URL IS NULL OR dsi.RawUrl LIKE '%'+@RAW_URL+'%'";

                var data = conn.Query<int>(query, new { RAW_URL = rawUrl }).Single();
                return (int)data;
            }
        }
    }
}