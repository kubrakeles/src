using API.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Infrastructure.DataContext
{
    public class DemiralpContext : DbContext
    {
        public DemiralpContext()
        {
        }

        public DemiralpContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<MainActivity> MainActivities { get; set; }
        public DbSet<MainCompany> MainCompanies { get; set; }
        public DbSet<MainNews> MainNews { get; set; }
        public DbSet<MainReference> MainReferences { get; set; }
        public DbSet<MainSlider_Image> MainSlider_Images { get; set; }

    }
}