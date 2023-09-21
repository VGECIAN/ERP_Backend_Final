using ERP_Common;
using ERP_Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebGrease;

namespace ERP_Service
{
    public class ServiceRegistry
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //services.AddScoped<ITempDataDictionary, TempDataDictionary>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton<ICacheManager, MemoryCacheManager>();
            
            //services.AddDependencyScanning().ScanAssembly();
            services.AddScoped<IDapperService, DapperService>();
            // scan all dependency of solution
            services.AddDependencyScanning().ScanAssembly();
        }
    }
}
