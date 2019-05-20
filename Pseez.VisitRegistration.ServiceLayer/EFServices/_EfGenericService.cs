using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pseez.VisitRegistration.ServiceLayer.Interfaces;
using Pseez.VisitRegistration.DataAccessLayer.IUnitOfWork;
using System.Data.Entity;

namespace Pseez.VisitRegistration.ServiceLayer.EFServices
{
    public class _EfGenericService<TEntity> : _IGenericService<TEntity> where TEntity : class
    {

        protected IUnitOfWorkVisitRegistration _uow;
        protected IDbSet<TEntity> _tEntities;

        public _EfGenericService(IUnitOfWorkVisitRegistration uow)
        {
            _uow = uow;
            _tEntities = _uow.Set<TEntity>();
        }


        public virtual void Add(TEntity entity)
        {
            _tEntities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _tEntities.Remove(entity);
        }

        public TEntity Find(Func<TEntity, bool> predicate)
        {
            return _tEntities.Where(predicate).FirstOrDefault();
        }

        public IList<TEntity> GetAll()
        {
            return _tEntities.ToList();
        }

        public IList<TEntity> GetAll(Func<TEntity, bool> predicate)
        {
            return _tEntities.Where(predicate).ToList();
        }

        #region IDisposable Members
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion

        //بخشهای تکمیلی
        public TEntity FindById(int id)
        {
            return _tEntities.Find(id);
        }
        public void DeleteById(int id)
        {
            var entity = _tEntities.Find(id);
            _tEntities.Remove(entity);

        }
    }
}
