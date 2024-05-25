using static ERP_Comman.Enums;

namespace ERP_Main.ViewModels
{
    public class BaseResponseVM
    {
        public ERPResponseStatusCode StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public bool IsSuccessfull { get; set; }
    }
}
