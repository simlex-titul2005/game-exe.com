﻿using System.Data.Entity;

namespace GE.WebCoreExtantions
{
    public class DbContext : SX.WebCore.SxDbContext
    {
        public DbContext() : base("DbContext") { }

        public new DbSet<Article> Articles { get; set; }

        public DbSet<Aphorism> Aphorisms { get; set; }

        public DbSet<AuthorAphorism> AuthorAphorisms { get; set; }

        public DbSet<Contest> Contests { get; set; }

        public DbSet<Game> Games { get; set; }

        public new DbSet<News> News { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContestPrize>()
                .HasRequired(x => x.Contest)
                .WithMany(x=>x.Prizes)
                .HasForeignKey(x => new { x.ContestId, x.MaterialCoreType });

            modelBuilder.Entity<Aphorism>().HasOptional(x => x.Author).WithMany(x => x.Aphorisms).HasForeignKey(x => new { x.AuthorId }).WillCascadeOnDelete(true);
        }
    }
}
