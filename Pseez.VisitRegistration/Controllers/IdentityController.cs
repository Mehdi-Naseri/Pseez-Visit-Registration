﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Identity.ServiceLayer.Interfaces;
using Microsoft.AspNet.Identity;
using Identity.ViewModels.ViewModels;
using Identity.Models.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Pseez.VisitRegistration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IdentityController : Controller
    {
        private IIdentityUserService _identityUserService;
        private IIdentityRoleService _identityRoleService;
        private IIdentityUserRoleService _identityUserRoleService;
        //private Task<IdentityResult> _createUserAsync;

        public IdentityController(IIdentityUserService identityUserService,
            IIdentityRoleService identityRoleService,
            IIdentityUserRoleService identityUserRoleService)
        {
            _identityUserService = identityUserService;
            _identityRoleService = identityRoleService;
            _identityUserRoleService = identityUserRoleService;
        }

        //
        // GET: /Admin/Admin/
        public ActionResult Index()
        {
            return View();
        }



        #region Users
        //===========================================================================================
        //                Users
        //===========================================================================================
        public ActionResult AllUsers()
        {
            return View(_identityUserService.GetAllUsers().OrderBy(r => r.UserName));
        }

        public ActionResult AllUsersRead()
        {
            IEnumerable<ApplicationUser> a = _identityUserService.GetAllUsers().ToList();
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        // GET: /Admin/CreateUser
        public ActionResult CreateUser()
        {
            return PartialView("_CreateUser");
        }

        // POST: /Admin/CreateUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(RegisterViewModelwithName registerViewModelwithName)
        {
            if (ModelState.IsValid)
            {
                var result = await _identityUserService.CreateUserAsync(userName: registerViewModelwithName.UserName, email: registerViewModelwithName.Email, password: registerViewModelwithName.Password);
                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }
                else
                {
                    AddErrors(result);
                }
            }
            return PartialView("_CreateUser", registerViewModelwithName);
        }

        // GET: /Admin/EditUser/5
        public async Task<ActionResult> EditUser(string id = null)
        {
            ApplicationUser user = await _identityUserService.FindUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return PartialView("_EditUser", user);
        }

        // POST: /Admin/EditUser/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                var result = await _identityUserService.UpdateUserAsync(user);
                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }
                else
                {
                    AddErrors(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "Uncorrect Input.");
            }
            return PartialView("_EditUser", user);
        }

        // GET: /Admin/DeleteUser/5
        public async Task<ActionResult> DeleteUser(string id = null)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ApplicationUser user = await _identityUserService.FindUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            else
            {
                return PartialView("_DeleteUser", user);
            }
        }
        // POST: /Admin/DeleteUser/5
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteUserConfirmed(string id = null)
        {
            try
            {
                var result = await _identityUserService.DeleteUserByIdAsync(id);
                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }
                else
                {
                    AddErrors(result);
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            ApplicationUser user = await _identityUserService.FindUserById(id);
            return PartialView("_DeleteUser", user);
        }
        #endregion




        #region Roles
        //===========================================================================================
        //                Roles
        //===========================================================================================
        public ActionResult AllRoles()
        {
            //IEnumerable<IdentityRole> allRoles = _identityRoleService.GetAllRoles().OrderBy(r => r.Name);
            //return View("AllRoles", allRoles);
            return View();
        }

        public ActionResult AllRolesRead()
        {
            //IEnumerable<IdentityRole> a = _identityRoleService.GetAllRoles();
            var a = _identityRoleService.GetAllRoles().ToList();
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        // GET: /Admin/CreateRole
        public ActionResult CreateRole()
        {
            return PartialView("_CreateRole");
        }

        // POST: /Admin/CreateRole
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRole(string roleName)
        {
            if (ModelState.IsValid)
            {
                var result = await _identityRoleService.CreateRoleByNameAsync(roleName);
                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }
                else
                {
                    AddErrors(result);
                }
            }
            return PartialView("_CreateRole", roleName);
        }

        // GET: /Admin/EditRole/5
        public async Task<ActionResult> EditRole(string id = null)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            IdentityRole identityRole = await _identityRoleService.FindRoleByIdAsync(id);
            return PartialView("_EditRole", identityRole);
        }

        // POST: /Admin/EditRole/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditRole(string id, string name)
        {
            IdentityRole identityRole = await _identityRoleService.FindRoleByIdAsync(id);
            identityRole.Name = name;
            if (ModelState.IsValid)
            {
                var result = await _identityRoleService.UpdateRoleAsync(identityRole);
                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }
                else
                {
                    AddErrors(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "Uncorrect Input.");
            }
            return PartialView("_EditRole", identityRole);
        }

        // GET: /Admin/DeleteRole/5
        public async Task<ActionResult> DeleteRole(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                IdentityRole role = await _identityRoleService.FindRoleByIdAsync(id);
                return PartialView("_DeleteRole", role);
            }
        }
        // POST: /Admin/DeleteRole/5
        [HttpPost, ActionName("DeleteRole")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteRoleConfirmed(string id)
        {
            try
            {
                var result = await _identityRoleService.DeleteRoleByIdAsync(id);
                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }
                else
                {
                    AddErrors(result);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            IdentityRole role = await _identityRoleService.FindRoleByIdAsync(id);
            return PartialView("_DeleteRole", role);
        }
        #endregion Roles




        #region Users in Roles
        //===========================================================================================
        //                Users Roles
        //===========================================================================================
        public ActionResult AllUsersRoles()
        {
            IEnumerable<UserRoleViewModel> userRoles = _identityUserRoleService.GetAllUsersRoles().OrderBy(r => r.UserName);
            return View(userRoles);
        }

        public ActionResult AllUsersRolesRead()
        {
            IEnumerable<UserRoleViewModel> userRoleViewModel = _identityUserRoleService.GetAllUsersRoles().OrderBy(r => r.UserName).ToList();
            return Json(userRoleViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddUserRole()
        {
            //ساخت لیستی از نام یوزرها
            ViewBag.UserNames = _identityUserService.GetAllUserNames();
            //ساخت لیستی از نام رولها
            ViewBag.RoleNames = _identityRoleService.GetAllRoleNames();
            return PartialView("_AddUserRole");
        }

        [HttpPost]
        public async Task<ActionResult> AddUserRole(string userName, string roleName)
        {
            try
            {
                var result = await _identityUserRoleService.AddUserRole(userName, roleName);
                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }
                else
                {
                    AddErrors(result);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            //ساخت لیستی از نام یوزرها
            ViewBag.UserNames = _identityUserService.GetAllUserNames();
            //ساخت لیستی از نام رولها
            ViewBag.RoleNames = _identityRoleService.GetAllRoleNames();
            return PartialView("_AddUserRole");
        }


        [HttpGet]
        public ActionResult DeleteUserRole(string userName, string roleName)
        {
            if (userName == null || roleName == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.RoleName1 = roleName;
                ViewBag.UserName1 = userName;
                return PartialView("_DeleteUserRole");
            }
        }

        // POST: /Admin/DeleteRole/5
        [HttpPost, ActionName("DeleteUserRole")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteUserRoleConfirmed(string userName, string roleName)
        {
            try
            {
                var result = await _identityUserRoleService.DeleteUserRole(userName, roleName);
                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }
                else
                {
                    AddErrors(result);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

            }
            ViewBag.RoleName1 = roleName;
            ViewBag.UserName1 = userName;
            return PartialView("_DeleteUserRole");
        }
        #endregion



        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

    }
}