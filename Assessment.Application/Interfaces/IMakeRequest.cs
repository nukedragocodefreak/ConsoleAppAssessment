using Assessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Application.Interfaces
{
    public interface IMakeRequest
    {
        Task<object> MakeRequests(InputJson input);
    }
}
