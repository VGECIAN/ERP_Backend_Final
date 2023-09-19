using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Common
{
    public class ConfigItems
    {
        public static IConfiguration Configuration { get; set; } = null!;

        public static string ConnectionString => Configuration["ConnectionStrings:DefaultConnection"] ?? "";
        public static string GUIDKey => Configuration["Date:GUIDKey"] ?? "";
    }
}
