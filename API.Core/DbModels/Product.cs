using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace API.Core.DbModels
{
   public class Product:BaseEntity
    {
      
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string PictureUrl { get; set; }

        public int ProductTypeId { get; set; }
        //[JsonIgnore]
        public ProductType ProductType { get; set; }

        public int ProductBrandId { get; set; }
        //[JsonIgnore]
        public ProductBrand ProductBrand { get; set; }
      

    }
}
