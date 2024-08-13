using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Core.Contracts.Middleware
{
    public interface IExceptionHandler
    {
        Task HandleAsync(HttpContext context, Exception exception);
    }
}
