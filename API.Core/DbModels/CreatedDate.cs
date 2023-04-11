using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.DbModels
{
    public class CreatedDate
    {
        public int Id { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public Product Product { get; set; } 
    }
}
