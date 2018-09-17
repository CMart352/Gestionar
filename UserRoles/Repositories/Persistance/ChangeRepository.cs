using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UserRoles.Data;
using UserRoles.Models;
using UserRoles.Repositories.Interface;
using UserRoles.Services;

namespace UserRoles.Repositories.Persistance
{
    public class ChangeRepository : IChangeRepository
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IActionContextAccessor _actionContextAccessor;

        public ChangeRepository(ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IEmailSender emailSender,
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _urlHelperFactory = urlHelperFactory;
            _actionContextAccessor = actionContextAccessor;
        }

        [Authorize(Roles = "Admin")]
        public Task SendEmail(string userEmail)
        {
            try
            {
                var user = _userManager.FindByEmailAsync(userEmail).Result;

                if (user == null)
                {
                    throw new Exception("User cannot be found!");
                }

                var url = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);
                var code = _userManager.GeneratePasswordResetTokenAsync(user).Result;
                var callbackUrl = url.ResetPasswordCallbackLink(user.Id, code, _actionContextAccessor.ActionContext.HttpContext.Request.Scheme);
                _emailSender.SendEmailAsync(userEmail, "CRM Credentials",
                    "Your email is: " + userEmail + $"\nPlease create your password by clicking here: <a href='{callbackUrl}'>link</a>");


                return Task.CompletedTask;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        public Task ToggleBlock(string userEmail)
        {
            try
            {
                var user = _userManager.FindByEmailAsync(userEmail).Result;
                var adminUsers = _userManager.GetUsersInRoleAsync("Admin").Result;
                IList<ApplicationUser> blockedAdmins = adminUsers.Where(auser => auser.IsBlocked).ToList();

                if (user == null)
                {
                    throw new Exception("User does not exist");
                }

                if (adminUsers.Contains(user) && blockedAdmins.Count >= adminUsers.Count - 1
                    && !user.IsBlocked)
                {
                    throw new Exception("You cannot block the ONLY admin");
                }

                user.IsBlocked = !user.IsBlocked;
                _context.SaveChanges();

                return Task.CompletedTask;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
