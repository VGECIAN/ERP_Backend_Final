﻿using ERP_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Service
{
    public interface IAuthenticationService
    {
        User? GetUserByEmail(string UserName , string password); 
    }
}
