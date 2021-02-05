using API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.DbModels
{
   public class MainSlider_Image:IEntity
    {
        public int Id { get; set; }
        public string PictureUrl { get; set; }


    }
}
