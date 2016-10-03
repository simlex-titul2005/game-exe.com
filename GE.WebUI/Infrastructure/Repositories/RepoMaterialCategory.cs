﻿using Dapper;
using GE.WebUI.Models;
using GE.WebUI.ViewModels;
using SX.WebCore;
using SX.WebCore.Repositories;
using SX.WebCore.ViewModels;
using System.Data.SqlClient;
using System.Linq;
using System;
using System.Text;

namespace GE.WebUI.Infrastructure.Repositories
{
    public sealed class RepoMaterialCategory : SxRepoMaterialCategory<VMMaterialCategory>
    {
        public sealed override VMMaterialCategory Create(VMMaterialCategory model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var data = connection.Query<VMMaterialCategory, SxVMPicture, VMMaterialCategory, VMMaterialCategory>("dbo.add_material_category @categoryId, @title, @mct, @pcid, @pictureId, @gameId", (c, p, pc) => {
                    c.FrontPicture = p;
                    c.ParentCategory = pc;
                    return c;
                }, new
                {
                    categoryId = (string)model.Id,
                    title = model.Title,
                    mct = model.ModelCoreType,
                    pcid = (string)model.ParentId,
                    pictureId = model.FrontPictureId,
                    gameId=model.GameId
                }, splitOn: "Id").SingleOrDefault();

                return data;
            }
        }

        public new MaterialCategory GetByKey(params object[] id)
        {
            var query = @"SELECT *
FROM   D_MATERIAL_CATEGORY  AS dmc
       LEFT JOIN D_GAME     AS dg
            ON  dg.Id = dmc.GameId
       LEFT JOIN D_PICTURE  AS dp
            ON  dp.Id = dmc.FrontPictureId
WHERE  dmc.Id = @id";

            using (var conn = new SqlConnection(ConnectionString))
            {
                var data = conn.Query<MaterialCategory, Game, SxPicture, MaterialCategory>(query, (c, g, p)=> {
                    c.Game = g;
                    c.FrontPicture = p;
                    return c;
                }, new { id = id[0] }, splitOn: "Id").SingleOrDefault();
                return data;
            }
        }

        public MaterialCategory Update(MaterialCategory model, bool changeDateUpdate = true, params string[] propertiesForChange)
        {
            var query = @"UPDATE D_MATERIAL_CATEGORY
SET    Title              = @title,
       FrontPictureId     = @pictureId,
       GameId             = @gameId
WHERE  Id                 = @id";
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Execute(query, new
                {
                    id = model.Id,
                    title = model.Title,
                    pictureId = model.FrontPictureId,
                    gameId=model.GameId
                });
            }

            var data=GetByKey(model.Id);
            return data;
        }

        public MaterialCategory Update(MaterialCategory model, object[] additionalData, bool changeDateUpdate = true, params string[] propertiesForChange)
        {
            var exist = GetByKey(model.Id);
            var isRedactedId = exist == null;
            if (isRedactedId)
            {
                var oldId = additionalData[0];
                var query = @"BEGIN TRANSACTION

ALTER TABLE DV_MATERIAL NOCHECK CONSTRAINT [FK_dbo.DV_MATERIAL_dbo.D_MATERIAL_CATEGORY_CategoryId]
UPDATE DV_MATERIAL
SET CategoryId = @id
WHERE CategoryId = @oldid
ALTER TABLE [dbo].[DV_MATERIAL] CHECK CONSTRAINT [FK_dbo.DV_MATERIAL_dbo.D_MATERIAL_CATEGORY_CategoryId]

ALTER TABLE D_MATERIAL_CATEGORY NOCHECK CONSTRAINT [FK_dbo.D_MATERIAL_CATEGORY_dbo.D_MATERIAL_CATEGORY_ParentCategoryId]

UPDATE D_MATERIAL_CATEGORY
SET    Id = @id
WHERE  Id = @oldid

UPDATE D_MATERIAL_CATEGORY
SET    ParentCategoryId = @id
WHERE  ParentCategoryId = @oldid

ALTER TABLE [dbo].[D_MATERIAL_CATEGORY] CHECK CONSTRAINT [FK_dbo.D_MATERIAL_CATEGORY_dbo.D_MATERIAL_CATEGORY_ParentCategoryId]

COMMIT TRANSACTION";

                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Execute(query, new
                    {
                        id = model.Id,
                        oldid = oldId,
                        title = model.Title,
                        mct = model.ModelCoreType,
                        fpid = model.FrontPictureId
                    });
                }

                return GetByKey(model.Id);
            }
            else
                return Update(model, changeDateUpdate, propertiesForChange);
        }

        protected override Action<StringBuilder> BeforeDeleteCategoryAction
        {
            get
            {
                return beforeDeleteCategory;
            }
        }
        private void beforeDeleteCategory(StringBuilder query)
        {
            query.AppendLine(@"DELETE FROM D_APHORISM WHERE  Id IN (SELECT dm.Id FROM DV_MATERIAL AS dm JOIN D_APHORISM  AS da ON  da.Id = dm.Id AND da.ModelCoreType = dm.ModelCoreType WHERE dm.CategoryId IN (SELECT fd.Id FROM @idForDel fd))");

            query.AppendLine(@"DELETE FROM DV_MATERIAL WHERE TitleUrl IN (SELECT dm.TitleUrl FROM DV_MATERIAL AS dm JOIN D_APHORISM AS da ON da.Id = dm.Id AND da.ModelCoreType = dm.ModelCoreType WHERE dm.CategoryId IN (SELECT fd.Id FROM @idForDel fd))");
        }

        public override VMMaterialCategory Update(VMMaterialCategory model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var data = connection.Query<VMMaterialCategory, SxVMPicture, VMMaterialCategory, VMMaterialCategory>("dbo.update_material_category @oldCategoryId, @categoryId, @title, @mct, @pcid, @pictureId, @gameId", (c, p, pc) =>
                {
                    c.FrontPicture = p;
                    c.ParentCategory = pc;
                    return c;
                }, new
                {
                    oldCategoryId = model.OldId,
                    categoryId = (string)model.Id,
                    title = model.Title,
                    mct = model.ModelCoreType,
                    pcid = (string)model.ParentId,
                    pictureId = model.FrontPictureId,
                    gameId=model.GameId
                }, splitOn: "Id").SingleOrDefault();

                return data;
            }
        }
    }
}
