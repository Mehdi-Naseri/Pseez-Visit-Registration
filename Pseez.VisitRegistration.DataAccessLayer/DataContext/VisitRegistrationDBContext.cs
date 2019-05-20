using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pseez.VisitRegistration.DomainClasses.Models;
using Pseez.VisitRegistration.DataAccessLayer.IUnitOfWork;
using Microsoft.AspNet.Identity.EntityFramework;
using Identity.Models.Models;
using System.Data.Entity;

namespace Pseez.VisitRegistration.DataAccessLayer.DataContext
{
    public class VisitRegistrationDBContext : IdentityDbContext<ApplicationUser>, IUnitOfWorkVisitRegistration
    {
        public VisitRegistrationDBContext()
            : base("name=VisitRegistrationConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //جهت ذخیره تاریخ در پایگاه داده اضافه شده است.
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            //جهت ذخیره جداول در شمای "پورتال" اضافه شده است.
            //modelBuilder.HasDefaultSchema("VisitRegistration");

            //جهت ذخیره جداول ایدنتیتی در شمای "آیدنتیتی" اضافه شده است.
            modelBuilder.HasDefaultSchema("Identity");
            base.OnModelCreating(modelBuilder);
        }

        public static VisitRegistrationDBContext Create()
        {
            return new VisitRegistrationDBContext();
        }

        #region IUnitOfWork Members
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        #endregion

        public System.Data.Entity.DbSet<Registration> Registrations { get; set; }
        public System.Data.Entity.DbSet<Log> Logs { get; set; }
    }
}
