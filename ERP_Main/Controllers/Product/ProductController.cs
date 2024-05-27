using Microsoft.AspNetCore.Mvc;

namespace ERP_Main.Controllers.Product
{
    public class ProductController : BaseController
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
