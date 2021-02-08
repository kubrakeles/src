using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Utilities.Result
{
   public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T Data,string message):base(data:Data,success:false,message:message)
        {

        }
        public ErrorDataResult(T Data):base(default,success:false)
        {

        }
        public ErrorDataResult(string message):base(default,success:false,message)
        {

        }
        public ErrorDataResult():base(default,success:false)
        {

        }
    }
}
