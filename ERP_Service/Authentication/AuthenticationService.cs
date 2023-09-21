using Dapper;
using ERP_Common;
using ERP_Data;
using ERP_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Service
{
    [TransientDependency(ServiceType = typeof(IAuthenticationService))]
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IDapperService _dapperService;

        public AuthenticationService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public User? GetUserByEmail(string email, string password)
        {
            DynamicParameters objdynamicParameters = new DynamicParameters();
            objdynamicParameters.Add("Email", email);
            objdynamicParameters.Add("Password", password);
            return _dapperService.QuerySP<User>(StoredProceduresNames.GetUserByEmail, objdynamicParameters).FirstOrDefault();
           
        }
    }
}
