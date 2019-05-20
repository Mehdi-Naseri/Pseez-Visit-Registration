using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//جهت فعال سازی و دسترسی به بخش اکانت
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
//using Pseez.VisitRegistration.DomainClasses.Models.Identity;

//جهت ارتباط با پایگاه داده
using Pseez.VisitRegistration.DataAccessLayer.DataContext;
using Pseez.VisitRegistration.DataAccessLayer.Migrations;
using Identity.Models.Models;
using System.Data.Entity;

namespace Pseez.VisitRegistration.DataAccessLayer.Migrations
{
    public class SeedIdentity
    {

        public void CreateAdminUserAndRole()
        {
            //Initialzie Admin user and Password
            //IdentityContext IdentityContext1 = new IdentityContext();

            VisitRegistrationDBContext visitRegistrationDBContext = new VisitRegistrationDBContext();
            UserManager<ApplicationUser> UserManager1 = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(visitRegistrationDBContext));
            //Create User "Admin" if it is not existed.
            if (UserManager1.FindByName("Admin") == null)
            {
                var user = new ApplicationUser() { UserName = "Admin" , Email = "Admin@Pseez.ir" };
                UserManager1.Create(user, "Visit-Pseez#1");
            }

            //Create Role "Admin" if it is not existed.
            RoleManager<IdentityRole> RoleManager1 = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(visitRegistrationDBContext));
            if (RoleManager1.FindByName("Admin") == null)
            {
                IdentityRole IdentityRole1 = new IdentityRole("Admin");
                RoleManager1.Create(IdentityRole1);
            }
            //Add Admin user to Admin Role
            string IdentityUserId = visitRegistrationDBContext.Users.First(x => x.UserName == "Admin").Id;
            UserManager1.AddToRole(IdentityUserId, "Admin");
        }

        public void AddRoles()
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new VisitRegistrationDBContext()));
            //string[] RoleNames = { "ScammerAdmin", "ScammerCreator" };
            string[] RoleNames = {"RegistrationAdmin" , "RegistrationRead"};
            foreach (string RoleName in RoleNames)
            {
                if (roleManager.FindByName(RoleName) == null)
                {
                    IdentityRole IdentityRole1 = new IdentityRole(RoleName);
                    roleManager.Create(IdentityRole1);
                }
            }

        }

        public void AddUsersandRoles()
        {
            VisitRegistrationDBContext visitRegistrationDBContext = new VisitRegistrationDBContext();
            UserManager<ApplicationUser> UserManager1 = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(visitRegistrationDBContext));
            //Create User "Admin" if it is not existed.
            if (UserManager1.FindByName("Pseez") == null)
            {
                var user = new ApplicationUser() { UserName = "Pseez", Email = "Pseez@Pseez.ir" };
                UserManager1.Create(user, "Pseez@#2015");
            }

            //Add Admin user to Admin Role
            string IdentityUserId = visitRegistrationDBContext.Users.First(x => x.UserName == "Pseez").Id;
            UserManager1.AddToRole(IdentityUserId, "RegistrationRead");

        }
    }
}
