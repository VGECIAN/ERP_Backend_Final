using ERP_Data;
using ERP_Main.Models;
using ERP_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ERP_Comman.Enums;

namespace ERP_Main.Controllers
{
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost,Route("user/login",Name="Login")]
        public BaseResponse Login(LoginRequestModel model)
        {
            if(!ModelState.IsValid)
            {
                return ApiMessage(ERPResponseStatusCode.UnAuthorized, "Invalid");
            }
            try
            {
                var User = _authenticationService.GetUserByEmail(model.Email, model.Password);
                if (User != null)
                {
                    return ApiSuccess(ERPResponseStatusCode.Ok, "Success",User);
                }
                else
                {
                    return ApiMessage(ERPResponseStatusCode.NotFound, "");
                }
            }
            catch(Exception e)
            {
                return ApiException(ERPResponseStatusCode.ServerError, "Login", e);
            }
            
        }
    }
}
