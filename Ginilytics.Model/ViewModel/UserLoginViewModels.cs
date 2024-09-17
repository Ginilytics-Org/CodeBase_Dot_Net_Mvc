using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Model.ViewModel
{
    [AdaptTo(typeof(LoginModel)), GenerateMapper]
    public class UserLoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }


}
