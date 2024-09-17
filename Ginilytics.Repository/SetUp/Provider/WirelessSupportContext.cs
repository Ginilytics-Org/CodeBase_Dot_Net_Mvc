using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Ginilytics.Model.DataModel;

namespace Ginilytics.Repository.SetUp.Provider
{
    public class WirelessSupportContext : DbContext
    {
        private string conn = "";

        #region "DbSet User"
        public DbSet<NLog> NLogs { get; set; }
        #endregion

        public WirelessSupportContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conn, x => x.MigrationsAssembly("Ginilytics"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //User
            #region "user Map"
           
            #endregion
        }
    }
}
