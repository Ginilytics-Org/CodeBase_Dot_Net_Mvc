﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ginilytics.StartUp.ApplicationBuilders.Contracts
{
    public interface IBuilder
    {
        void AddBuilder(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration);
    }
}
