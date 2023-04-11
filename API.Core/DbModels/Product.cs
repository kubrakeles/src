using API.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace API.Core.DbModels
{
   public class Product:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ProductTypeId { get; set; }
        public int CreatedId { get; set; }
        //[JsonIgnore]
        public ProductType ProductType { get; set; }
      
        public List<ProductImage> Images { get; set; }
        public CreatedDate Created { get; set; }
   
    }
}
