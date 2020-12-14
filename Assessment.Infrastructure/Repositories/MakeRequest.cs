using Assessment.Application.Interfaces;
using Assessment.Core.Entities;
using Assessment.Infrastructure.BL;
using Assessment.Infrastructure.Requests;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Infrastructure.Repositories
{
    public class MakeRequest : IMakeRequest
    {
        static readonly HttpClient client = new HttpClient();
       

        public async Task<string> MakeRequests(string input, int service)
        {
            var response = await Request.GetStringAsync(input, service);

            return response;
        }
    }
}
