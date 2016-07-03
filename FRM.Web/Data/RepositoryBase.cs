using FRM.Web.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Web.Data
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        internal ApplicationDbContext context;
        internal DbSet<TEntity> dbSet;

        public RepositoryBase(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual TEntity GetById(int? id)
        {
            Object entity = context.Families.FirstOrDefault(e => e.Id == id);
            return (TEntity)entity;
        }

        public virtual TEntity GetById(string id)
        {
            Object entity = context.Users.FirstOrDefault(e => e.Id == id);
            return (TEntity)entity;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public IQueryable<TEntity> GetPaged(int top = 20, int skip = 0, object orderBy = null, object filter = null)
        {
            return null; //need to override in order to implement specific filtering and ordering
        }

        public virtual IQueryable<TEntity> GetAll(object filter)
        {
            return null; //need to override in order to implement specific filtering and ordering
        }

        public virtual TEntity GetFullObject(object id)
        {
            return null;
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);

            dbSet.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            //TEntity entity = dbSet.Find(id);
            throw new NotImplementedException();
        }

        public virtual void Commit()
        {
            context.SaveChanges();
        }

        public virtual void Dispose()
        {
            context.Dispose();
        }

    }
}
