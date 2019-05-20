using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Pseez.VisitRegistration.DomainClasses.Models;
using Pseez.VisitRegistration.ViewModels.ViewModels;

namespace Pseez.VisitRegistration.Extentions.MapperConfigure.AutoMapper
{
    public class ConfigureProjectMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Registration, RegistrationViewModel>();
            Mapper.CreateMap<RegistrationViewModel, Registration>();

            //Mapper.CreateMap<Project, ProjectViewModel>()
            //    .ForMember(dest => dest.ContactListName,
            //    option => option.MapFrom(src => src.ContactList.Name));
            //Mapper.CreateMap<ProjectViewModel, Project>()
            //    .ForMember(dest => dest.ContactListId,
            //    option => option.Ignore());
        }
    }
}
