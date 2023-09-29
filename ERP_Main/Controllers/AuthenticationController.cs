using DtyApi.Common;
using ERP_Data;
using ERP_Domain;
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
                var encryptedPass = EncryptionDecryption.GetEncrypt(model.Password);
                var user = _authenticationService.GetUserByEmail(model.UserName, encryptedPass);
                if (user != null)
                {
                    return ApiSuccess(ERPResponseStatusCode.Ok, "Success",new
                    {
                        user.Username,
                        user.Name,
                        user.UserId,
                        user.RoleId,
                        user.Email,
                        user.PhoneNumber
                    });
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

        [HttpPost,Route("user/register",Name="Register")]
        public BaseResponse Register(User model)
        {
            return ApiSuccess(ERPResponseStatusCode.Ok, "Success", "");
        }
    }
}
