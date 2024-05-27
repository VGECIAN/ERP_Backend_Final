using ERP_Data.Repository;
using ERP_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Service
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IRepository<ProductCategory> productCategoryRepository;

        public ProductCategoryService(IRepository<ProductCategory> productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }

        public List<ProductCategory> GetAllProductCategories()
        {
            return this.productCategoryRepository.GetAll().ToList();
        }
    }
}
