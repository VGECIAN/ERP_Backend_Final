using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Domain
{
    [Table("product_variant")]
    public class ProductVariant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductVariantId { get; set; }
        public string Name { get; set; } = null!;
        public string InternalCode { get; set; } = null!;
        public long ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
        public int Version { get; set; }
        public string? Description { get; set; }
        public float CostPrice { get; set; }
        public float SalePrice { get; set; }
        public string Size { get; set; }
        public float Volume { get; set; }
        public float Weight { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }


        public ICollection<InventoryList> InventoryLists { get; set; }
    }
}
