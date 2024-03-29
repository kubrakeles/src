﻿using API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.DbModels
{
   public class ProductType:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
