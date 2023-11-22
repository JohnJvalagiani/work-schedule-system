using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using service.server.Profiles;
using service.server.Services;
using Task_Managment_System.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Managment_System.Abstraction;
using Task_Managment_System.Implementation;
using Application.Services.Abstraction;
using Server.Services.Abstraction;

namespace Task_Managment_System.Server.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallerService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<UserValidation>();

            services.AddScoped<JWTTokenService>();

            services.AddScoped<CurrentUserSupplier>();

            services.AddScoped<IIdentityService, IdentityService>();

            services.AddScoped<ISchedulerRepo, SchedulerRepo>();

            services.AddScoped <IRoleManagerService,RoleManagerService> ();


        }
    }
}
