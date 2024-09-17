using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ginilytics.Model.DataModel;
using Ginilytics.Service.Services;
using Ginilytics.Service.Services.Contracts;

namespace Ginilytics.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogInService _accountService;
        public AccountController(SignInManager<IdentityUser> signInManager, ILogInService accountService)
        {
            this.signInManager = signInManager;
            this._accountService = accountService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Register()
        {
            UserRegistrationDto model = new UserRegistrationDto();
            return View(model);
        }


        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(UserRegistrationDto request)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Register(request);
                if (result.Status)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("message", result.Messsage);
                    return View(request);
                }
            }
            return View(request);

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            UserLoginDto model = new UserLoginDto();
            return View(model);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Login(model);
                if (result.Status)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("message", result.Messsage);
                    return View(model);
                }
            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }


        [HttpGet, AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            ForgotPassword model = new ForgotPassword();
            return View(model);
        }

        [HttpPost, AllowAnonymous]
        public IActionResult ForgotPassword(ForgotPassword forgotPassword)
        {
            //ForgotPassword model = new ForgotPassword();
            //return View(model);
            if (ModelState.IsValid)
            {
                //var result = await _accountService.Login(model);
                //if (result.Status)
                //{
                //    return RedirectToAction("Index", "Dashboard");
                //}
                //else
                //{
                //    ModelState.AddModelError("message", result.Messsage);
                //    return View(model);
                //}
            }
            return View(forgotPassword);
        }

    }
}
