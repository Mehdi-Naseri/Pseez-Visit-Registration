using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace Pseez.VisitRegistration.DataAccessLayer.IUnitOfWork
{
    public interface IUnitOfWorkVisitRegistration
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}
