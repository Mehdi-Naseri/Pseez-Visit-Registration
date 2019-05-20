using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pseez.VisitRegistration.DomainClasses.Models;

namespace Pseez.VisitRegistration.ServiceLayer.Interfaces
{
    public interface IRegistrationService : _IGenericService<Registration>
    {
        //bool Exist(string Name);
    }
}
