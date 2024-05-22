﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using MiraShop.DAL.Filters;
using MiraShop.DAL.Models;
using MiraShop.DAL.Repositories.Interfaces;
using MiraShop.DAL;
using MiraShop.DAL.Exceptions;

namespace GrocifyApp.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MiraShopAppContext _dbContext;
        protected readonly ILogger<Repository<T>> _logger;
        private DbSet<T> entities;

        public Repository(MiraShopAppContext dbContext)
        {
            _dbContext = dbContext;

            entities = _dbContext.Set<T>();
        }

        public async Task Delete(T? entity, CancellationTokenSource? token = null)
        {
            if (entity == null)
            {
                throw new NotFoundException();
            }

            entities.Remove(entity);

            await SaveChangesAsync(token);
        }

        public async Task DeleteById(Guid id, CancellationTokenSource? token = null)
        {
            var entity = await Get(id);

            await Delete(entity, token);
        }

        public virtual async Task<T?> Get(Guid id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<T?> GetSingleWhere(Expression<Func<T, bool>> filter, CancellationTokenSource? token = null)
        {
            T? result;

            result = await entities.SingleOrDefaultAsync(filter);

            return result;
        }

        public async Task<TSelector?> GetSingleWhere<TSelector>(Expression<Func<T, bool>> filter,
            Expression<Func<T, TSelector>> selector)
        {
            TSelector? result;

            result = await entities.Where(filter).Select(selector).SingleOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<T>> GetAll(CancellationTokenSource? token = null)
        {
            return await entities.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<List<T>> GetWhere(Expression<Func<T, bool>> filter, CancellationTokenSource? token = null)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            var s = entities.Where(filter);

            return await ToListAsync(s, token);
        }

        public async Task<List<TSelector>> GetWhere<TSelector>(Expression<Func<T, bool>> filter,
            Expression<Func<T, TSelector>> selector, CancellationTokenSource? token = null)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            var s = entities.Where(filter).Select(selector);

            return await ToListAsync(s, token);
        }

        public async Task<bool> AnyWhere(Expression<Func<T, bool>> filter, CancellationTokenSource? token = null)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            if (token != null)
            {
                return await entities.AnyAsync(filter, token.Token);
            }
            else
            {
                return await entities.AnyAsync(filter);
            }
        }

        public async Task<IEnumerable<T>> GetBySearchModel<TFilter>(TFilter filter, CancellationTokenSource? token = null) where TFilter : BaseSearchModel<T>
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            Expression<Func<T, bool>> expressions = filter.BuildExpression();

            var s = entities.Where(expressions)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            return await ToListAsync(s, token);
        }

        public async Task Insert(T entity, CancellationTokenSource? token = null)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);

            await SaveChangesAsync(token);
        }

        public async Task InsertMultiple(IEnumerable<T> entitiesToAdd, bool saveChanges = true, CancellationTokenSource? token = null)
        {
            if (entitiesToAdd == null)
            {
                throw new ArgumentNullException(nameof(entitiesToAdd));
            }

            entities.AddRange(entitiesToAdd);

            if (saveChanges)
            {
                await SaveChangesAsync(token);
            }
        }

        public async Task Update(T entity, bool saveChanges = true, CancellationTokenSource? token = null)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Update(entity);

            if (saveChanges)
            {
                await SaveChangesAsync(token);
            }
        }

        public async Task<int> UpdateMultipleLeafType(Expression<Func<T, bool>> expression,
            Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyExpression,
            CancellationTokenSource? token = null)
        {
            return await entities.Where(expression).ExecuteUpdateAsync(setPropertyExpression);
        }

        public async Task<int> DeleteMultipleLeafType(Expression<Func<T, bool>> expression,
            CancellationTokenSource? token = null)
        {
            return await entities.Where(expression).ExecuteDeleteAsync();
        }

        private async Task<List<W>> ToListAsync<W>(IQueryable<W> query,
            CancellationTokenSource? token = null)
        {
            if (token != null)
            {
                try
                {
                    return await query.ToListAsync(token.Token);
                }
                catch (SqlException e) when (token.IsCancellationRequested)
                {
                    _logger.LogInformation(e.Message);

                    throw;
                }
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task SaveChangesAsync(CancellationTokenSource? token = null)
        {
            if (token != null)
            {
                try
                {
                    await _dbContext.SaveChangesAsync(token.Token);
                }
                catch (SqlException e) when (token.IsCancellationRequested)
                {
                    _logger.LogInformation(e.Message);

                    throw;
                }
            }
            else
            {
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
