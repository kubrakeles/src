﻿using API.Core.DbModels;
using API.Core.Entities;
using API.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Infrastructure.Data
{
    public class SpecificationEvalutor<TEntity> where TEntity : class, IEntity, new()
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;

        }
    }
}
