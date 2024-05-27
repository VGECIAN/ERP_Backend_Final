using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ERP_Comman.Enums;

namespace ERP_Domain
{
    [Table("product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string InternalCode { get; set; } = null!;
        public long CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public ProductCategory ProductCategory { get; set; } = null!;
        [EnumDataType(typeof(UOM))]
        public UOM UOM { get; set; }
        [EnumDataType(typeof(ProductType))]
        public ProductType ProductType { get; set; }
        public int Version { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }

        public ICollection<ProductVariant> ProductVariants { get; set; }

    }
}
