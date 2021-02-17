using API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.DbModels
{
    public class CompanyInfo:IEntity
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Faks { get; set; }
    }
}
