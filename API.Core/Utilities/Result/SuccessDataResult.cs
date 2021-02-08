using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace API.Core.Utilities.Result
{
   public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message):base(data,success:true,message)
        {

        }
        public SuccessDataResult(T data):base(data,success:true)
        {

        }
        public SuccessDataResult(string message):base(default,success:true,message)
        {

        }
        public SuccessDataResult():base(default,success:true)
        {

        }
    }
}
