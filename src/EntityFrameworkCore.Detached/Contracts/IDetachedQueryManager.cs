﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EntityFrameworkCore.Detached.DataAnnotations;
using EntityFrameworkCore.Detached.DataAnnotations.Paged;

namespace EntityFrameworkCore.Detached.Contracts
{
    public interface IDetachedQueryManager
    {
        /// <summary>
        /// Gets a query to find a root entity by its key.
        /// </summary>
        /// <typeparam name="TEntity">The clr type of the entity.</typeparam>
        /// <param name="keyValues">One or more values for the entity key to find.</param>
        /// <returns>IQueryable filtered by key.</returns>
        Task<TEntity> FindEntityByKey<TEntity>(EntityType entityType, object[] keyValues) 
            where TEntity : class;

        /// <summary>
        /// Gets a query to find root entities filtered by the given expression.
        /// </summary>
        /// <typeparam name="TEntity">The clr type of the entity.</typeparam>
        /// <param name="filter">The expression to filter the entities.</param>
        /// <returns>IQueryable filtered by the given expression.</returns>
        Task<List<TEntity>> FindEntities<TEntity>(EntityType entityType, Expression<Func<TEntity, bool>> filter) 
            where TEntity : class;

        /// <summary>
        /// Gets a query to find root entities filtered by the given expression.
        /// </summary>
        /// <typeparam name="TEntity">The clr type of the entity.</typeparam>
        /// <param name="filter">The expression to filter the entities.</param>
        /// <param name="project">The expression to convert from TEntity to TItem</param>
        /// <param name="entityType">Entity metadata.</param>
        /// <returns>IQueryable filtered by the given expression.</returns>
        Task<List<TItem>> FindEntities<TEntity, TItem>(EntityType entityType, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TItem>> project)
            where TEntity : class
            where TItem : class;

        /// <summary>
        /// Gets a query to find entities by key values.
        /// </summary>
        /// <typeparam name="TEntity">The clr type of the entity.</typeparam>
        /// <param name="keyValues">One or more values for the entity key to find.</param>
        /// <returns>IQueryable filtered by key.</returns>
        Task<TEntity> FindPersistedEntity<TEntity>(EntityType entityType, object detachedEntity) 
            where TEntity : class;

        /// <summary>
        /// Gets a paged result containing page items and query result size.
        /// </summary>
        /// <typeparam name="TEntity">The clr type of the entity.</typeparam>
        /// <param name="entityType">Entity metadata.</param>
        /// <param name="request">The request parameters.</param>
        /// <returns>A paged result containing query size and page items.</returns>
        Task<IPagedResult<TEntity>> GetPage<TEntity>(EntityType entityType, IPagedRequest<TEntity> request) 
            where TEntity : class;

        /// <summary>
        /// Gets a paged result containing page items and query result size.
        /// </summary>
        /// <typeparam name="TEntity">The clr type of the entity.</typeparam>
        /// <param name="entityType">Entity metadata.</param>
        /// <param name="request">The request parameters.</param>
        /// <param name="project">The expression to convert from TEntity to TItem.</param>
        /// <returns>A paged result containing query size and page items.</returns>
        Task<IPagedResult<TItem>> GetPage<TEntity, TItem>(EntityType entityType, IPagedRequest<TEntity> request, Expression<Func<TEntity, TItem>> project)
            where TEntity : class
            where TItem : class;
    }
}
