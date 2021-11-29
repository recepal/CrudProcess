using CrudProcess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CrudProcess.Storage
{
    partial class CrudContext : DbContext
    {
        private readonly string _connectionString = "..................";
        public CrudContext() { }

        public CrudContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CrudContext(DbContextOptions<CrudContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public async Task<bool> Save()
        {
            var entities = ChangeTracker.Entries<CrudBase>();
            foreach (var entity in entities)
            {
                EntityState state = entity.State;
                if (state == EntityState.Added)
                {
                    entity.Entity.CreatedDate = DateTime.Now;
                }
                else if (state == EntityState.Modified)
                {
                    entity.Entity.ModifiedDate = DateTime.Now;
                }
                entity.Entity.Counter++;
            }
            return await SaveChangesAsync() > 0;
        }
    }
}
