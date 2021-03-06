﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using GE.WebUI.Models;
using GE.WebUI.ViewModels;
using SX.WebCore;
using SX.WebCore.SxRepositories.Abstract;
using SX.WebCore.ViewModels;

namespace GE.WebUI.Infrastructure.Repositories
{
    public sealed class RepoPopularYoutubeVideo : SxDbRepository<string, PopularYoutubeVideo, SxVMVideo>
    {
        public async Task CreateAsync(SxVMVideo[] videos)
        {
            if (videos == null || !videos.Any()) return;

            var table = GetVideosTable(videos);
            var @params = new DynamicParameters();
            @params.Add("videos", table.AsTableValuedParameter("dbo.PopularYoutubeVideos"));

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync("dbo.save_popular_youtube_videos", @params, commandType: CommandType.StoredProcedure);
            }
        }
        private static DataTable GetVideosTable(IReadOnlyList<SxVMVideo> videos)
        {
            var table = new DataTable();
            table.Columns.AddRange(new DataColumn[] {
                new DataColumn { ColumnName="Id", DataType=typeof(string)},
                new DataColumn { ColumnName="Title", DataType=typeof(string)},
                new DataColumn { ColumnName="ChannelId", DataType=typeof(string)},
                new DataColumn { ColumnName="ChannelTitle", DataType=typeof(string)}
            });

            SxVMVideo item = null;
            for (var i = 0; i < videos.Count; i++)
            {
                item = videos[i];
                table.Rows.Add(item.VideoId, item.Title, item.ChannelId, item.ChannelTitle);
            }

            return table;
        }

        public async Task<VMPopularYoutubeVideoArchiveItem[]> GetArchiveItemsAsync()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var data = await connection.QueryAsync<VMPopularYoutubeVideoArchiveItem>("dbo.get_popular_youtube_videos_archive");
                return data.ToArray();
            }
        }

        public async Task<PopularYoutubeVideo[]> GetArchiveList(SxFilter filter)
        {
            var year = (int?)filter.AddintionalInfo[0];
            var month = (int?)filter.AddintionalInfo[1];
            var day = (int?)filter.AddintionalInfo[2];

            using (var connection = new SqlConnection(ConnectionString))
            {
                var data = await connection.QueryAsync<PopularYoutubeVideo>("dbo.get_popular_youtube_video_archive_list @year, @month, @day, @amount", new { year = year, month = month, day = day, amount = filter.PagerInfo.PageSize });
                return data.ToArray();
            }
        }
    }
}