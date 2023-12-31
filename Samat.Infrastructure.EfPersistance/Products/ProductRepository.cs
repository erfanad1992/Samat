﻿using Microsoft.EntityFrameworkCore;
using Samat.Domains.Products;
using Samat.Framework.Presistance.EF;
using System.Linq.Expressions;

namespace Samat.Infrastructure.EfPersistance.Products
{
    public class ProductRepository : RepositoryBase<Product, long>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }

        protected override IList<Expression<Func<Product, object?>>> GetIncludes()
        {
            return new List<Expression<Func<Product, object?>>>();
        }
    }
}
