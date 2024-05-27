using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ERP_Domain
{
    public partial class ERPDbContext : DbContext
    {
        public ERPDbContext(DbContextOptions<ERPDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<InventoryList> InventoryLists { get; set; }
        public DbSet<ProductInventoryInfo> ProductInventoryInfos { get; set; }
    }
}
