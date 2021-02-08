using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Utilities.Result
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message):base(success:false)
        {

        }
        public ErrorResult():base(success:false)
        {

        }

    }
}
