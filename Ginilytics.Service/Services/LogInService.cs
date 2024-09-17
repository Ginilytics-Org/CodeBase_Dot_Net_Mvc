using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginilytics.Model.DataModel;
using Ginilytics.Service.Services.Contracts;

namespace Ginilytics.Service.Services
{
    public class LogInService : ILogInService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public LogInService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public async Task<LogInStatus> Login(UserLoginDto model)
        {
            try
            {

                var userStatus = await GetStatus(model);
                if (userStatus.Status)
                {
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
                    if (result.Succeeded)
                    {
                        //await _userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));-
                        userStatus.Status = true;
                    }
                    else if (result.IsLockedOut)
                    {
                        userStatus.Status = false;
                        userStatus.Messsage = "Account Locked";
                    }
                    else
                    {
                        userStatus.Status = false;
                        userStatus.Messsage = "Invalid login attempt";
                    }
                }

                return userStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<LogInStatus> GetStatus(UserLoginDto model)
        {
            try
            {
                var status = new LogInStatus();
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null && !user.EmailConfirmed)
                {
                    status.Messsage = "Username not found";
                    status.Status = false;
                }
                else
                {
                    status.Status = true;
                }
                if (await _userManager.CheckPasswordAsync(user, model.Password) == false)
                {
                    status.Messsage = "Password is incorrect!";
                    status.Status = false;

                }
                else
                {
                    status.Status = true;
                }
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RegisterStatus> Register(UserRegistrationDto model)
        {
            try
            {
                var registerStatus = new RegisterStatus();
                var userCheck = await _userManager.FindByNameAsync(model.UserName);
                if (userCheck == null)
                {
                    var user = new IdentityUser
                    {
                        UserName = model.UserName,
                        NormalizedUserName = model.Email,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        registerStatus.Status = true;
                    }
                    else
                    {
                        if (result.Errors.Count() > 0)
                        {
                            foreach (var error in result.Errors)
                            {
                                registerStatus.Messsage = error.Description;
                            }
                        }
                        return registerStatus;
                    }
                }
                else
                {
                    registerStatus.Messsage = "Email already exists.";
                    registerStatus.Status = false;
                    return registerStatus;
                }
                return registerStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
