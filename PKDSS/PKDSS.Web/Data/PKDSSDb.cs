using Microsoft.EntityFrameworkCore;
using PKDSS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PKDSS.Web.Data
{
    public class PKDSSSDb : DbContext
    {

        public PKDSSSDb(DbContextOptions<PKDSSSDb> options) : base(options)
        { }

        public DbSet<SensorData> SensorDatas { get; set; }

        public DbSet<UpdateInfo> UpdateInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*
            builder.Entity<DataEventRecord>().HasKey(m => m.DataEventRecordId);
            builder.Entity<SourceInfo>().HasKey(m => m.SourceInfoId);

            // shadow properties
            builder.Entity<DataEventRecord>().Property<DateTime>("UpdatedTimestamp");
            builder.Entity<SourceInfo>().Property<DateTime>("UpdatedTimestamp");
            */
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            /*
            ChangeTracker.DetectChanges();

            updateUpdatedProperty<SourceInfo>();
            updateUpdatedProperty<DataEventRecord>();
            */
            return base.SaveChanges();
        }

        private void updateUpdatedProperty<T>() where T : class
        {
            /*
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
            }
            */
        }

    }
}
