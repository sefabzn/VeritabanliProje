using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext Context = new NorthwindContext())
            {

                var addedEntity =Context.Entry(entity);
                addedEntity.State = EntityState.Added;
                Context.SaveChanges();

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext Context = new NorthwindContext())
            {

                var deletedEntity = Context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                Context.SaveChanges();

            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext Context = new NorthwindContext())
            {

                return Context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext Context = new NorthwindContext())
            {
                return filter == null ? Context.Set<Product>().ToList() : Context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext Context = new NorthwindContext())
            {

                var updatedEntity = Context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                Context.SaveChanges();

            }
        }
    }
}
