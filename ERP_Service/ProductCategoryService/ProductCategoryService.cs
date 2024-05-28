using ERP_Data.Repository;
using ERP_Domain;
using System.Collections.Generic;
using System.Linq;

namespace ERP_Service
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IRepository<ProductCategory> _productCategoryRepository;

        public ProductCategoryService(IRepository<ProductCategory> productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public List<ProductCategory> GetAllProductCategories()
        {
            return _productCategoryRepository.GetAll().ToList();
        }
    }
}
