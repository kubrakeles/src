using API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.DbModels
{
    public class OperationClaim:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }


    }
}
