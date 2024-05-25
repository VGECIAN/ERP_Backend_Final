using System;
using System.Collections.Generic;

namespace ERP_Data
{
    public partial class ProductCategory
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? HsnCode { get; set; }
        public double TaxPercentage { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string UpdatedBy { get; set; } = null!;
    }
}
