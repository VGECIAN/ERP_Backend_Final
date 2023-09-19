using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ERP_Comman.Enums;

namespace ERP_Data
{
    public class BaseResponse
    {
        // request is successfull or not
        public bool IsSuccessfull { get; set; } = true;

        // request api status code
        public ERPResponseStatusCode StatusCode { get; set; }

        // request api status code as string
        public string StatusMessage { get; set; } = string.Empty;

        // add any message that regarding request api
        public string Message { get; set; } = string.Empty;

        // data that need to provide on responce of request api
        public object? Data { get; set; } = null;
    }
}
