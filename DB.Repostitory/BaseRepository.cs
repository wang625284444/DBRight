﻿using DB.Entity;
using DB.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Repostitory
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        //数据库上下文
        public BaseDbContext ctx;
        public BaseRepository(BaseDbContext context)
        {
            ctx = context;
        }

        #region ======================＝＝＝＝＝增加＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

        public virtual bool Add(T entity)
        {
            if (entity == null)
            {
                return false;
            }
            ctx.Set<T>().Add(entity);
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            if (entity == null)
            {
                return await Task.Run(() => false);
            }
            ctx.Set<T>().Add(entity);
            return await ctx.SaveChangesAsync() > 0 ? true : await Task.Run(() => false);
        }

        public virtual bool AddList(List<T> lists)
        {
            if (lists == null || lists.Count <= 0)
            {
                return false;
            }
            ctx.Set<T>().AddRange(lists);
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public virtual async Task<bool> AddListAsync(List<T> lists)
        {
            if (lists == null || lists.Count <= 0)
            {
                return await Task.Run(() => false);
            }
            ctx.Set<T>().AddRange(lists);
            return await ctx.SaveChangesAsync() > 0 ? true : await Task.Run(() => false);
        }

        public virtual bool AddOrUpdate(T entity)
        {
            if (entity == null)
            {
                return false;
            }
            return Add(entity);
        }

        public virtual async Task<bool> AddOrUpdateAsync(T entity)
        {
            if (entity == null)
            {
                return await Task.Run(() => false);
            }
            return  await AddAsync(entity);
        }

        #endregion

        #region ======================＝＝＝＝＝修改＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

        public virtual bool Update(T entity, bool isUpdate = true, params Expression<Func<T, object>>[] propertiesToUpdate)
        {
            if (entity == null)
            {
                return false;
            }
            if (propertiesToUpdate.Length <= 0)
            {
                ctx.Set<T>().Update(entity);
            }
            else
            {
                var modify = ctx.Entry(entity);
                if (isUpdate)
                {
                    ctx.Set<T>().Attach(entity);
                }
                else
                {
                    modify.State = EntityState.Modified;
                }
                propertiesToUpdate.ToList().ForEach(p => modify.Property(p).IsModified = isUpdate);
            }

            return ctx.SaveChanges() > 0 ? true : false;
        }

        public virtual async Task<bool> UpdateAsync(T entity, bool isUpdate = true, params Expression<Func<T, object>>[] propertiesToUpdate)
        {
            if (entity == null)
            {
                return await Task.Run(() => false);
            }
            if (propertiesToUpdate.Length <= 0)
            {
                ctx.Set<T>().Update(entity);
            }
            else
            {
                var modify = ctx.Entry(entity);
                if (isUpdate)
                {
                    ctx.Set<T>().Attach(entity);
                }
                else
                {
                    modify.State = EntityState.Modified;
                }
                propertiesToUpdate.ToList().ForEach(p => modify.Property(p).IsModified = isUpdate);
            }
            return await ctx.SaveChangesAsync() > 0 ? true : await Task.Run(() => false);
        }

        public virtual bool UpdateList(List<T> lists, bool isUpdate = true, params Expression<Func<T, object>>[] propertiesToUpdate)
        {
            if (lists == null || lists.Count <= 0)
            {
                return false;
            }
            if (propertiesToUpdate.Length <= 0)
            {
                ctx.Set<T>().UpdateRange(lists);
            }
            else
            {
                if (isUpdate)
                {
                    foreach (var list in lists)
                    {
                        var modify = ctx.Entry(list);
                        ctx.Set<T>().Attach(list);
                        propertiesToUpdate.ToList().ForEach(p => modify.Property(p).IsModified = isUpdate);
                    }
                }
                else
                {
                    foreach (var list in lists)
                    {
                        var modify = ctx.Entry(list);
                        modify.State = EntityState.Modified;
                        propertiesToUpdate.ToList().ForEach(p => modify.Property(p).IsModified = isUpdate);
                    }
                }
            }

            return ctx.SaveChanges() > 0 ? true : false;
        }

        public virtual async Task<bool> UpdateListAsync(List<T> lists, bool isUpdate = true, params Expression<Func<T, object>>[] propertiesToUpdate)
        {
            if (lists == null || lists.Count <= 0)
            {
                return await Task.Run(() => false);
            }
            if (propertiesToUpdate.Length <= 0)
            {
                ctx.Set<T>().UpdateRange(lists);
            }
            else
            {
                if (isUpdate)
                {
                    foreach (var list in lists)
                    {
                        var modify = ctx.Entry(list);
                        ctx.Set<T>().Attach(list);
                        propertiesToUpdate.ToList().ForEach(p => modify.Property(p).IsModified = isUpdate);
                    }
                }
                else
                {
                    foreach (var list in lists)
                    {
                        var modify = ctx.Entry(list);
                        modify.State = EntityState.Modified;
                        propertiesToUpdate.ToList().ForEach(p => modify.Property(p).IsModified = isUpdate);
                    }
                }
            }
            return await ctx.SaveChangesAsync() > 0 ? true : await Task.Run(() => false);
        }

        #endregion

        #region ======================＝＝＝＝＝删除＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

        public virtual bool Delete(T entity)
        {
            if (entity == null)
            {
                return false;
            }
            ctx.Set<T>().Remove(entity);
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            if (entity == null)
            {
                return await Task.Run(() => false);
            }
            ctx.Set<T>().Remove(entity);
            return await ctx.SaveChangesAsync() > 0 ? true : await Task.Run(() => false);
        }

        public virtual bool DeleteList(List<T> lists)
        {
            if (lists == null || lists.Count <= 0)
            {
                return false;
            }
            ctx.Set<T>().RemoveRange(lists);
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public virtual async Task<bool> DeleteListAsync(List<T> lists)
        {
            if (lists == null || lists.Count <= 0)
            {
                return await Task.Run(() => false);
            }
            ctx.Set<T>().RemoveRange(lists);
            return await ctx.SaveChangesAsync() > 0 ? true : await Task.Run(() => false);
        }

        public virtual bool Delete(Expression<Func<T, bool>> query)
        {
            IQueryable<T> queryAble = (query == null) ? ctx.Set<T>().AsQueryable() : ctx.Set<T>().Where(query);
            List<T> lists = queryAble.ToList();

            if (lists == null || lists.Count <= 0)
            {
                return false;
            }

            ctx.Set<T>().RemoveRange(lists);
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public virtual async Task<bool> DeleteAsync(Expression<Func<T, bool>> query)
        {
            IQueryable<T> queryAble = (query == null) ? ctx.Set<T>().AsQueryable() : ctx.Set<T>().Where(query);
            List<T> lists = queryAble.ToList();

            if (lists == null || lists.Count <= 0)
            {
                return await Task.Run(() => false);
            }

            ctx.Set<T>().RemoveRange(lists);
            return await ctx.SaveChangesAsync() > 0 ? true : await Task.Run(() => false);
        }

        #endregion

        #region ======================＝＝＝＝＝单查询＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

        public virtual T Get(Expression<Func<T, bool>> query)
        {
            return query == null ? ctx.Set<T>().AsNoTracking().FirstOrDefault() : ctx.Set<T>().AsNoTracking().FirstOrDefault(query);
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> query)
        {
            return query == null ? await Task.Run(() => ctx.Set<T>().AsNoTracking().FirstOrDefaultAsync())
                : await Task.Run(() => ctx.Set<T>().AsNoTracking().FirstOrDefaultAsync(query));
        }

        public virtual int Count(Expression<Func<T, bool>> query)
        {
            return query == null ? ctx.Set<T>().AsNoTracking().Count() : ctx.Set<T>().AsNoTracking().Count(query);
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> query = null)
        {
            return query == null ? await ctx.Set<T>().AsNoTracking().CountAsync()
                : await ctx.Set<T>().AsNoTracking().CountAsync(query);
        }

        public virtual bool IsExist(Expression<Func<T, bool>> query)
        {
            return query == null ? ctx.Set<T>().Any() : ctx.Set<T>().Where(query).Any();
        }

        public virtual async Task<bool> IsExistAsync(Expression<Func<T, bool>> query)
        {
            return query == null ? await Task.Run(() => ctx.Set<T>().AnyAsync()) :
                await Task.Run(() => ctx.Set<T>().Where(query).AnyAsync());
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> query)
        {
            return query == null ? ctx.Set<T>().AsNoTracking() : ctx.Set<T>().Where(query).AsNoTracking();
        }

        public virtual async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> query)
        {
            return query == null ? await Task.Run(() => ctx.Set<T>().AsNoTracking())
                : await Task.Run(() => ctx.Set<T>().Where(query).AsNoTracking());
        }

        public virtual List<T> GetListAll(Expression<Func<T, bool>> query)
        {
            return query == null ? ctx.Set<T>().AsNoTracking().ToList()
                : ctx.Set<T>().Where(query).AsQueryable<T>().AsNoTracking().ToList();
        }

        public virtual async Task<List<T>> GetListAllAsync(Expression<Func<T, bool>> query)
        {
            return query == null ? await Task.Run(() => ctx.Set<T>().AsNoTracking().ToListAsync())
                 : await Task.Run(() => ctx.Set<T>().Where(query).AsQueryable<T>().AsNoTracking().ToListAsync());
        }

        #endregion

        #region =======================＝＝＝＝T-Sql查询＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

        public virtual bool IsExist(string sql, params DbParameter[] parameter)
        {
            return ctx.Database.ExecuteSqlCommand(sql, parameter) > 0;
        }

        public virtual async Task<bool> IsExistAsync(string sql, params DbParameter[] parameter)
        {
            return await ctx.Database.ExecuteSqlCommandAsync(sql, CancellationToken.None, parameter) > 0;
        }

        public virtual IQueryable<T> GetAllBySql(string sql, params DbParameter[] parameter)
        {
            return ctx.Set<T>().FromSql(sql, parameter);
        }

        public virtual async Task<IQueryable<T>> GetAllBySqlAsync(string sql, params DbParameter[] parameter)
        {
            return await Task.Run(() => ctx.Set<T>().FromSql(sql, parameter));
        }

        public virtual List<T> GetListAllBySql(string sql, params DbParameter[] parameter)
        {
            return ctx.Set<T>().FromSql(sql, parameter).Cast<T>().ToList();
        }

        public virtual async Task<List<T>> GetListAllBySqlAsync(string sql, params DbParameter[] parameter)
        {
            return await Task.Run(() => ctx.Set<T>().FromSql(sql, parameter).Cast<T>().ToList());
        }

        #endregion

        #region ====================＝＝＝＝＝分页查询＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

        public virtual IQueryable<TResult> GetPageAll<TEntity, TOrderBy, TResult>(int pageIndex, int pageSize,
            Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby,
            Expression<Func<TEntity, TResult>> selector, out int total, bool isAsc = true)
            where TEntity : class where TResult : class
        {
            IQueryable<TEntity> query = ctx.Set<TEntity>().AsNoTracking();

            query = where != null ? query.Where(where) : query;

            //求总数
            total = query.Count();

            if (orderby != null)
            {
                query = isAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
            }

            //分页并且返回查询需要的字段信息返回
            query = query.Skip((--pageIndex * pageSize)).Take(pageSize);
            return selector == null ? query.Cast<TResult>().AsNoTracking() : query.Select(selector).AsNoTracking();
        }

        public virtual async Task<IQueryable<TResult>> GetPageAllAsync<TEntity, TOrderBy, TResult>(int pageIndex, int pageSize,
            Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby,
            Expression<Func<TEntity, TResult>> selector, bool isAsc = true)
            where TEntity : class where TResult : class
        {
            IQueryable<TEntity> query = ctx.Set<TEntity>().AsNoTracking();

            query = where != null ? query.Where(where) : query;

            if (orderby != null)
            {
                query = isAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
            }

            //分页并且返回查询需要的字段信息返回
            query = query.Skip((--pageIndex * pageSize)).Take(pageSize);
            return selector == null ? await Task.Run(() => query.Cast<TResult>().AsNoTracking()) :
                await Task.Run(() => query.Select(selector).AsNoTracking());
        }

        public virtual List<TResult> GetPageAllList<TEntity, TOrderBy, TResult>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TOrderBy>> orderby, Expression<Func<TEntity, TResult>> selector, out int total, bool isAsc = true)
            where TEntity : class where TResult : class
        {
            IQueryable<TEntity> query = ctx.Set<TEntity>().AsNoTracking();
            query = where != null ? query.Where(where).AsQueryable() : query.AsQueryable();

            //求总数
            total = query.Count();

            if (orderby != null)
            {
                query = isAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
            }

            //分页并且返回查询需要的字段信息返回
            query = query.Skip((--pageIndex * pageSize)).Take(pageSize);
            return selector == null ? query.Cast<TResult>().AsNoTracking().ToList() : query.Select(selector).AsNoTracking().ToList();
        }

        public virtual async Task<List<TResult>> GetPageAllListAsync<TEntity, TOrderBy, TResult>(int pageIndex, int pageSize,
            Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby,
            Expression<Func<TEntity, TResult>> selector, bool isAsc = true)
            where TEntity : class where TResult : class
        {
            IQueryable<TEntity> query = ctx.Set<TEntity>().AsNoTracking();

            query = where != null ? query.Where(where) : query;

            if (orderby != null)
            {
                query = isAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
            }

            //分页并且返回查询需要的字段信息返回
            query = query.Skip((--pageIndex * pageSize)).Take(pageSize);
            return selector == null ? await Task.Run(() => query.Cast<TResult>().AsNoTracking().ToList()) :
                await Task.Run(() => query.Select(selector).AsNoTracking().ToList());
        }

        #endregion

    }
}
