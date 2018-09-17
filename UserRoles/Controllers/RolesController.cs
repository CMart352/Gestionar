using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Data;
using UserRoles.Models;
using UserRoles.Models.ViewModels;
using UserRoles.Models.ViewModels.ManageViewModels;
using UserRoles.Repositories.Interface;
using UserRoles.Services;

namespace UserRoles.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private  IEmailSender _emailSender;
        private readonly IChangeRepository _changeRepository;


        public RolesController(ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IEmailSender emailSender,
            IChangeRepository changeRepository)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _changeRepository = changeRepository;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UserList()
        {
            var sellers = await _userManager.GetUsersInRoleAsync("Seller");
            var technicals = await _userManager.GetUsersInRoleAsync("Technical");
            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            var clients = await _userManager.GetUsersInRoleAsync("Client");

           // var users = sellers.Concat(technicals).Concat(admins);

            var model = new UserListViewModel
            {
                Sellers = sellers,
                Technicals = technicals,
                Admins = admins,
                Clients = clients

            };
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SellerList()
        {
            var sellers = await _userManager.GetUsersInRoleAsync("Seller");

            var model = new UserListViewModel
            {
                Sellers = sellers
            };

            return View(model);
        }

        [HttpGet("Roles/SellerList/{userEmail}")]
        public async Task<IActionResult> SellerList(string userEmail)
        {
            var sellers = await _userManager.GetUsersInRoleAsync("Seller");

            await _changeRepository.SendEmail(userEmail);

            var model = new UserListViewModel
            {
                Sellers = sellers
            };

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> TechnicalList()
        {
            var technical = await _userManager.GetUsersInRoleAsync("technical");

            var model = new UserListViewModel
            {
                Technicals = technical
            };

            return View(model);
        }

        [HttpGet("Roles/TechnicalList/{userEmail}")]
        public async Task<IActionResult> TechnicalList(string userEmail)
        {
            var technical = await _userManager.GetUsersInRoleAsync("Technical");

            await _changeRepository.SendEmail(userEmail);

            var model = new UserListViewModel
            {
                Technicals = technical
            };

            return View(model);
        }


        public async Task<IActionResult> AdminList()
        {
            var admin = await _userManager.GetUsersInRoleAsync("admin");

            var model = new UserListViewModel
            {
                Admins = admin
            };

            return View(model);
        }

        [HttpGet("Roles/AdminList/{userEmail}")]
        public async Task<IActionResult> AdminList(string userEmail)
        {
            var admin = await _userManager.GetUsersInRoleAsync("Admin");

            await _changeRepository.SendEmail(userEmail);

            var model = new UserListViewModel
            {
                Admins = admin
            };

            return View(model);
        }

        public async Task<IActionResult> BankerList()
        {
            var banker = await _userManager.GetUsersInRoleAsync("Banker");

            var model = new UserListViewModel
            {
                Bankers = banker
            };

            return View(model);
        }

        [HttpGet("Roles/BankerList/{userEmail}")]
        public async Task<IActionResult> BankerList(string userEmail)
        {
            var banker = await _userManager.GetUsersInRoleAsync("Banker");

            await _changeRepository.SendEmail(userEmail);

            var model = new UserListViewModel
            {
                Bankers = banker
            };

            return View(model);
        }

        public async Task<IActionResult> ClientList()
        {
            var clients = await _userManager.GetUsersInRoleAsync("Client");

            var model = new UserListViewModel
            {
                Clients = clients
            };

            return View(model);
        }

        [Authorize(Roles = "Seller")]
        public IActionResult CreateClient()
        {
            return View();
        }

        public async Task<IActionResult> ClientDetails(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var roles =  _userManager.GetRolesAsync(user).Result;

            var model = new ClientDetailsViewModel
            {
                Email = email,
                Roles = roles
            };

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole(string userEmail)
        {
            var roles = GetUserIdentityRoles();

            var user = await _userManager.FindByEmailAsync(userEmail);
            var oldRole = _userManager.GetRolesAsync(user).Result;

            if (user.Equals(null))
            {
                return NotFound();
            }

            var model = new ChangeUserRoleViewModel
            {
                UserRole = "",
                OldRole = oldRole[0],
                Roles = roles,
                Email = user.Email
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveUserRole(ChangeUserRoleViewModel model)
        {
            var adminUsers = await _userManager.GetUsersInRoleAsync("Admin");
            IList<ApplicationUser> blockedAdmins = adminUsers.Where(auser => auser.IsBlocked).ToList();

            //If there is less than one admin, return error to user
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var oldRole = _userManager.GetRolesAsync(user).Result;

                //Checks if user is an admin, there will at least be one unblocked admin and if the user is not currently blocked
                if (model.OldRole == "Admin" 
                    && (_userManager.GetUsersInRoleAsync(model.OldRole).Result.Count == 1 
                        || blockedAdmins.Count >= adminUsers.Count - 1)  
                    && !user.IsBlocked)
                {
                    model.Roles = GetUserIdentityRoles();
                    throw new Exception("There Must be AT LEAST 1 unblocked Admin!");
                    //return View("ChangeRole", model);

                    //return BadRequest("There must be AT LEAST 1 Admin!");
                }
                await _userManager.RemoveFromRoleAsync(user, model.OldRole);
                await _userManager.AddToRoleAsync(user, model.UserRole);

                model.Roles = GetUserIdentityRoles();

                var viewModel = new ChangeUserRoleViewModel
                {
                    UserRole = "",
                    OldRole = oldRole[0],
                    Roles = model.Roles,
                    Email = user.Email
                };

                return View("ChangeRole", viewModel);
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel{ RequestId = e.Message });
            }

            

        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ToggleBlock(ToggleBlockViewModel viewModel)
        {
            try
            {
                await _changeRepository.ToggleBlock(viewModel.Email);

                return RedirectToAction(viewModel.Type + "List");
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel { RequestId = e.Message });
            }

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SendCredentials(string userEmail)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userEmail);

                if (user == null)
                {
                    throw new Exception("User does not exist!");
                }

                var model = new UserCredentialViewModel
                {
                    Email = userEmail
                };

                return View(model);
            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel { RequestId = e.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SendEmail(string userEmail)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userEmail);

                if (user == null)
                {
                    throw new Exception("User cannot be found!");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme);
                await _emailSender.SendEmailAsync(userEmail, "CRM Credentials",
                    "Your email is: " + userEmail + $"\nPlease create your password by clicking here: <a href='{callbackUrl}'>link</a>");


                var viewModel = new UserCredentialViewModel
                {
                    Email = ""
                };

                return View("SendCredentials", viewModel);

            }
            catch (Exception e)
            {
                return View("Error", new ErrorViewModel { RequestId = e.Message });
            }
        }

        /* Helper Functions */
        public List<IdentityRole> GetUserIdentityRoles()
        {
            var roles = _roleManager.Roles
                .Where(r => r.Name == "Seller" || r.Name == "Admin" || r.Name == "Technical" || r.Name == "Banker")
                .ToList();

            return roles;
        }
    }
}