﻿using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.DbModels
{
    /// <summary>
    /// Bu sınıftan miras alan her enetitiy sınıfıın  Primary Keyini buradan tanımladık
    /// </summary>
    public class BaseEntity
    {
        public int Id { get; set; }
    }
}