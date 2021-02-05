using API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.DbModels
{
    public class MainActivity:IEntity
    {
        public int Id { get; set; }
        public string Activity { get; set; }
    }
}
