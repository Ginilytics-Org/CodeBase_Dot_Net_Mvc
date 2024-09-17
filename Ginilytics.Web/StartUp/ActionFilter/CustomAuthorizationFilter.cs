using Microsoft.AspNetCore.Mvc.Filters;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ginilytics.StartUp.ActionFilter
{
    //public class CustomAuthorizationFilter : IAuthorizationFilter
    //{
    //    private ILoginService _loginService;
    //    public CustomAuthorizationFilter(ILoginService loginService)
    //    {
    //        _loginService = loginService;
    //    }

    //    public void OnAuthorization(AuthorizationFilterContext context)
    //    {
    //        var user = context.HttpContext.User.FindFirstValue(ClaimTypes.UserData);
    //        if (user != null)
    //        {
    //            var userSessionInformation = (LoginUserResponseModel)JsonConvert.DeserializeObject(user, typeof(LoginUserResponseModel));
    //            var tokenWithUpdatedExpiry = _loginService.GenerateToken(userSessionInformation);

    //            context.HttpContext.Response.Headers.Add("set_authentication", tokenWithUpdatedExpiry);
    //        }
    //    }
    //}
}
