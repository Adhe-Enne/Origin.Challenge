using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Abstractions
{
    public interface IGenericResult
    {
        bool HasError { get; set; }
        string Message { get; set; }
        string Value { get; set; }
    }
}
