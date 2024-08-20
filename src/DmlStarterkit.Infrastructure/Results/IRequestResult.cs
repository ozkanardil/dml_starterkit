using System;
using System.Collections.Generic;
using System.Text;

namespace DmlStarterkit.Infrastructure.Results
{
    public interface IRequestResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
