using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace DataAccess.Repository
{
    public class EfRepository<T> : IRpository<T> where T : BaseEntity
    {
        private DbContext _dbContext;
        private IDbSet<T> _entities;

        protected virtual IDbSet<T> Entities => _entities ?? (_entities = _dbContext.Set<T>());

        public EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    Entities.Add(entity);

                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = dbEx.EntityValidationErrors.Aggregate(string.Empty,
                    (current1, validationErrors) => validationErrors.ValidationErrors.Aggregate(current1,
                        (current, validationError) => current + ($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}" + Environment.NewLine)));

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public void Add(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Add(entity);

                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = dbEx.EntityValidationErrors.Aggregate(string.Empty, (current1, validationErrors) =>
                    validationErrors.ValidationErrors.Aggregate(current1, (current, validationError) =>
                        current + ($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}" + Environment.NewLine)));

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    Entities.Remove(entity);

                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = dbEx.EntityValidationErrors.Aggregate(string.Empty, (current1, validationErrors) =>
                    validationErrors.ValidationErrors.Aggregate(current1, (current, validationError) =>
                        current + (Environment.NewLine +
                                   $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}")));

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Remove(entity);

                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = dbEx.EntityValidationErrors.Aggregate(string.Empty, (current1, validationErrors) =>
                    validationErrors.ValidationErrors.Aggregate(current1, (current, validationError) =>
                        current + (Environment.NewLine +
                                   $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}")));

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public T Get(T entity)
        {
            return Entities.Find(entity.Id);
        }

        public void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = dbEx.EntityValidationErrors.Aggregate(string.Empty, (current1, validationErrors) =>
                    validationErrors.ValidationErrors.Aggregate(current1, (current, validationError) =>
                        current + (Environment.NewLine +
                                   $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}")));

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = dbEx.EntityValidationErrors.Aggregate(string.Empty, (current1, validationErrors) =>
                    validationErrors.ValidationErrors.Aggregate(current1, (current, validationError) =>
                        current + (Environment.NewLine +
                                   $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}")));

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }
    }
}
