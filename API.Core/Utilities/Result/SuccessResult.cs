using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Utilities.Result
{
  public class SuccessResult:Result
    {
        public SuccessResult(String message):base(success:true,message)
        {

        }
        public SuccessResult():base(success:true)
        {
                    
        }   
    
    }
}
