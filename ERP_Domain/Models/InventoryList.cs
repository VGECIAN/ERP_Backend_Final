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
    [Table("product_inventory_list")]
    public class InventoryList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long InventoryListId { get; set; }
        public long ProductVariantId { get; set; }
        [ForeignKey(nameof(ProductVariantId))]
        public ProductVariant ProductVariant { get; set; } = null!;
        public string InventoryLocation { get; set; } = null!;
        public bool IsAvailable { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; } = null!;
        public DateTime? RemovedDate { get; set; }
        public string? ReleasedBy { get; set; }
        [EnumDataType(typeof(UOM))]
        public UOM UOM { get; set; }
        [EnumDataType(typeof(InventoryStatus))]
        public InventoryStatus InventoryStatus { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }
    }
}
