using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ginilytics.Model.DataModel;

namespace Ginilytics.Service.Services.Contracts
{
    public interface ILogInService
    {
        Task<LogInStatus> Login(UserLoginDto model);
        Task<RegisterStatus> Register(UserRegistrationDto request);
    }
}
