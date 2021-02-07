using API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.DbModels
{
    public class ProductImage:IEntity
    {
        public int Id { get; set; }
        public string PictureUrl { get; set; }
        //ForeignKey

        public int productID { get; set; }
        public Product product { get; set; }
    }
}
