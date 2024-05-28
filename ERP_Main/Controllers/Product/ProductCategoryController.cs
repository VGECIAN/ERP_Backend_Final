using ERP_Comman;
using ERP_Main.ViewModels;
using ERP_Service;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Main.Controllers.Product
{
    public class ProductCategoryController : BaseController
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpPost,Route("productcategory/get-all",Name ="GetAllProductCategory")]
        public BaseResponseVM GetAllProductCategory()
        {
            try
            {
                var productCategories = _productCategoryService.GetAllProductCategories();
                return ApiSuccess(Enums.ERPResponseStatusCode.Ok, "Success", productCategories);
            }
            catch(Exception ex)
            {
                return ApiException(Enums.ERPResponseStatusCode.ServerError, ex.Message, ex);
            }
        }
    }
}
