using ERP_Common;
using ERP_Data;
using ERP_Main.ViewModels;
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

        protected BaseResponseVM ApiMessage(ERPResponseStatusCode statusCode, string message, object? data = null, bool isSuccessfull = false)
        {
            var response = new BaseResponseVM()
            {
                StatusCode = statusCode,
                StatusMessage = GetStatusCodeString(statusCode),
                Message = message,
                Data = data,
                IsSuccessfull = isSuccessfull
            };
            return response;
        }

        protected BaseResponseVM ApiSuccess(ERPResponseStatusCode statusCode, string message, object? data = null)
        {
            var response = new BaseResponseVM()
            {
                IsSuccessfull = true,
                StatusCode = statusCode,
                StatusMessage = GetStatusCodeString(statusCode),
                Message = message,
                Data = data
            };

            return response;
        }

        protected BaseResponseVM ApiException(ERPResponseStatusCode statusCode, string exceptionIn, Exception ex, string? message = null)
        {
            //var _logger = EngineContext.Resolve<ILogger<BaseController>>();
            //_logger.LogError($"Exception in {exceptionIn}", ex);

            var response = new BaseResponseVM()
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
