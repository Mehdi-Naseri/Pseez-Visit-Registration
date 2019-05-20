using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Pseez.VisitRegistration.DomainClasses.Models;
using Pseez.VisitRegistration.ViewModels.ViewModels;

namespace Pseez.VisitRegistration.Extentions.MapperConfigure.Extention
{
    public static class DefineExtention
    {
        #region Project
        public static RegistrationViewModel MapModelToViewModel(this Registration entity)
        {
            return Mapper.Map<Registration, RegistrationViewModel>(entity);
        }
        public static Registration MapViewModelToModel(this RegistrationViewModel entity)
        {
            return Mapper.Map<RegistrationViewModel, Registration>(entity);
        }
        public static IEnumerable<RegistrationViewModel> MapModelToViewModel(this IEnumerable<Registration> entity)
        {
            return Mapper.Map<IEnumerable<Registration>, IEnumerable<RegistrationViewModel>>(entity);
        }
        public static IEnumerable<Registration> MapViewModelToModel(this IEnumerable<RegistrationViewModel> entity)
        {
            return Mapper.Map<IEnumerable<RegistrationViewModel>, IEnumerable<Registration>>(entity);
        }
        #endregion
    }
}
