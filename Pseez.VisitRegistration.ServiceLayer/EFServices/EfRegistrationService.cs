using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pseez.VisitRegistration.DomainClasses.Models;
using Pseez.VisitRegistration.DataAccessLayer.IUnitOfWork;
using Pseez.VisitRegistration.ServiceLayer.Interfaces;

namespace Pseez.VisitRegistration.ServiceLayer.EFServices
{
    public class EfRegistrationService : _EfGenericService<Registration>, IRegistrationService
    {
        public EfRegistrationService(IUnitOfWorkVisitRegistration uow)
            : base(uow)
        {

        }

        //public bool Exist(string Name)
        //{
        //    return _tEntities.Any(r => r.Name == Name);
        //}
    }
}
