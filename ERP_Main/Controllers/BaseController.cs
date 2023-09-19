using ERP_Common;
using ERP_Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using static ERP_Comman.Enums;

namespace ERP_Main.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected List<string> GetModelStateErrors(ModelStateDictionary modelState)
        {
            List<string> modelErrors = new List<string>();
            modelState.Values.AsEnumerable().ToList().ForEach(d =>
            {
                if (d.Errors.Count > 0)
                {
                    modelErrors.Add(d.Errors[0].ErrorMessage);
                }
            });

            return modelErrors;
        }

        protected BaseResponse ApiMessage(ERPResponseStatusCode statusCode, string message, object? data = null, bool isSuccessfull = false)
        {
            var response = new BaseResponse()
            {
                StatusCode = statusCode,
                StatusMessage = GetStatusCodeString(statusCode),
                Message = message,
                Data = data,
                IsSuccessfull = isSuccessfull
            };
            return response;
        }

        protected BaseResponse ApiSuccess(ERPResponseStatusCode statusCode, string message, object? data = null)
        {
            var response = new BaseResponse()
            {
                IsSuccessfull = true,
                StatusCode = statusCode,
                StatusMessage = GetStatusCodeString(statusCode),
                Message = message,
                Data = data
            };

            return response;
        }

        protected BaseResponse ApiException(ERPResponseStatusCode statusCode, string exceptionIn, Exception ex, string? message = null)
        {
            //var _logger = EngineContext.Resolve<ILogger<BaseController>>();
            //_logger.LogError($"Exception in {exceptionIn}", ex);

            var response = new BaseResponse()
            {
                IsSuccessfull = false,
                StatusCode = statusCode,
                StatusMessage = GetStatusCodeString(statusCode),
                Message = string.IsNullOrEmpty(message) ? "Something goes wrong, please try again later." : message
            };

            return response;
        }
    }
}
