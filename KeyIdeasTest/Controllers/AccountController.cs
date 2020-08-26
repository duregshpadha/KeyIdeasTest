using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeyIdeasTest.Constants;
using KeyIdeasTest.Constants.WebsiteMessagesConstants;
using KeyIdeasTest.DAL.Models.UserManagement;
using KeyIdeasTest.Models.Account;
using KeyIdeasTest.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;

namespace KeyIdeasTest.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(IConfiguration configuration, SignInManager<ApplicationUser> signInManager,
            IGenerateID generateID)
        {
            Configuration = configuration;
            _signInManager = signInManager;
            _generateID = generateID;
        }
        public IConfiguration Configuration { get; }
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IGenerateID _generateID;


        [HttpPost]
        public async Task<JsonResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                string error = ModelState.Where(x => x.Value.ValidationState == ModelValidationState.Invalid)
                    .Select(x => x.Value.Errors.Select(e => e.ErrorMessage).FirstOrDefault()).FirstOrDefault();
                return Json(data: new { success = "fail", message = error });
            }
            var user = await _signInManager.UserManager.FindByEmailAsync(viewModel.UserName);
            if (user == null)
            {
                user = await _signInManager.UserManager.FindByNameAsync(viewModel.UserName);
            }

            if (user == null)
            {
                return Json(data: new { success = "fail", message = ErrorContants.InvalidEmailOrPassword });
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, viewModel.Password, viewModel.RememberMe, false);
            if (!result.Succeeded)
            {
                result = await _signInManager.PasswordSignInAsync(viewModel.UserName, viewModel.Password, viewModel.RememberMe, false);
            }
            if (result.Succeeded)
            {
                return Json(data: new { success = "success", message = "" });
            }
            else
            {

                return Json(data: new { success = "fail", message = ErrorContants.InvalidEmailOrPassword });
            }
        }

        [HttpPost]
        public async Task<JsonResult> Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                string error = ModelState.Where(x => x.Value.ValidationState == ModelValidationState.Invalid)
                    .Select(x => x.Value.Errors.Select(e => e.ErrorMessage).FirstOrDefault()).FirstOrDefault();
                return Json(data: new { success = "fail", message = error });
            }

            ApplicationUser user = new ApplicationUser()
            {
                Id = _generateID.GeneratID(),
                Email = viewModel.Email,
                UserName = viewModel.UserName,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
            };

            var result = await _signInManager.UserManager.CreateAsync(user: user, password: viewModel.Password);
            if (!result.Succeeded)
            {
                string error = result.Errors.Select(x => x.Description).FirstOrDefault();
                return Json(data: new { success = "fail", message = error });
            }
            else
            {
                var roleAddedResult = await _signInManager.UserManager.AddToRoleAsync(user, UserRolesConstants.User);
                if (!roleAddedResult.Succeeded)
                {
                    await _signInManager.UserManager.DeleteAsync(user);
                    return Json(data: new { success = "fail", message = ErrorContants.Techincalproblempleasetryagain });
                }
                else
                {
                    return Json(data: new { success = "success", message = "" });
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(actionName: nameof(HomeController.Index), controllerName: "Home");
        }
    }
}
