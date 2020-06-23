using CrudProcess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudProcess.Storage
{
    public class CrudRepository<T> where T : CrudBase
    {
        private readonly CrudContext _ctx;

        public CrudRepository()
        {
            _ctx = new CrudContext();
        }

        public CrudRepository(string connectionString)
        {
            _ctx = new CrudContext(connectionString);
        }

        public bool CreateDb()
        {
            bool result;
            try
            {
                _ctx.Database.Migrate();
                result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public async Task<T> GetById(Guid id)
        {
           return await _ctx.Set<T>().Where(f => f.Id == id).FirstOrDefaultAsync();
        }
        public async Task<bool> Insert(T entity)
        {
            _ctx.Set<T>().Add(entity);

            return await _ctx.Save();
        }

        public  async Task<bool> Update(T entity)
        {
            _ctx.Attach(entity);
            _ctx.Entry(entity).State = EntityState.Modified;

            return await _ctx.Save();
        }

        public async Task<bool> Delete(T entity)
        {
            entity.IsDeleted = true;
            _ctx.Attach(entity);
            _ctx.Entry(entity).State = EntityState.Modified;

            return await _ctx.Save();
        }
    }
}
