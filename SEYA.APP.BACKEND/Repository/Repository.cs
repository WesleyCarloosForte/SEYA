using Microsoft.EntityFrameworkCore;
using SEYA.APP.BACKEND.Data;
using SEYA.APP.BACKEND.Interface;
using SEYA.APP.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEYA.APP.BACKEND.Repository
{
    public class Repository<T> : Shared.Interface.IRepository<T> where T : class
    {
        private readonly ServerContex _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ServerContex context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return _dbSet.Take(100).ToList();
        }

        public async Task<IEnumerable<T>> Get(Func<T, bool> where)
        {
            return _dbSet.Take(100).Where(where).ToList();
        }

        public async Task<T> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            _dbSet.Add(entity);
             await this.SaveChanges();
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
             await this.SaveChanges();
        }

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
             await this.SaveChanges();
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    


 
    }

}
