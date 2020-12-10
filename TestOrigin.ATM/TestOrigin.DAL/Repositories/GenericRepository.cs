using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace TestOrigin.DAL.Repositories
{
    
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal DbContext db;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(DbContext context)
        {
            this.db = context;
            this.dbSet = context.Set<TEntity>();
        }


        public void Delete(Expression<Func<TEntity, bool>> filter)
        {
            var listToDelete = List(filter);
            db.Set<TEntity>().RemoveRange(listToDelete);
        }

        public void Delete(TEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.Set<TEntity>().Remove(item);
        }

        public TEntity Get(int id) {
            return dbSet.Find(id);
        }

        /// <summary>
        /// No incluye las entidades hijas en el load
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public virtual List<TEntity> LazyList(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = db.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// Incluye las entidades hijas en el load
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public virtual List<TEntity> List(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = db.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty.Trim());
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual IPagedList<TEntity> ListPaged(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            int pageIndex, int itemsPerPage,
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "")

        {
            IQueryable<TEntity> query = db.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty.Trim());
            }

            return orderBy(query).ToPagedList<TEntity>(pageIndex, itemsPerPage);
        }

        public virtual void Save(TEntity item)
        {
            var PKs = GetPrimaryKeyPropertyNames(item);
            if (PKs.Count > 1)
                throw new Exception("Error from Save DataManagerBase, more than one PK was found, method Save must be rewrite into parent class");

            string PK = PKs.FirstOrDefault();
            if ((int)db.Entry(item).Property(PK).CurrentValue == 0)
                item = db.Set<TEntity>().Add(item).Entity;
            else
                db.Entry<TEntity>(item).State = EntityState.Modified;
        }

        protected List<string> GetPrimaryKeyPropertyNames(TEntity item)
        {
            var entry = db.Entry(item);
            return entry.Metadata.FindPrimaryKey()
                         .Properties
                         .Select(p => p.Name)
                         .ToList();
        }
        
    }
}
