using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Utilities.Result
{
    public interface IResult
    {
         bool Success { get; }
         string Message { get; }
    }
}
