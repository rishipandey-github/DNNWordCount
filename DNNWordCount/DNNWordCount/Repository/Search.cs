namespace DNN.ModuleDNNWordCount.Repository
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class Search : DbContext
    {
        public Search() : base("name=Search")
        {
            Database.SetInitializer<Search>(new CreateDatabaseIfNotExists<Search>());
        }

        public virtual DbSet<SearchHistory> SearchHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
