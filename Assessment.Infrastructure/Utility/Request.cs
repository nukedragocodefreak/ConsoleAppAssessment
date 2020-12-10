using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Infrastructure.Utility
{
    public class Request
    {
        public static async Task<string> GetStringAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(url);
            }
        }
    }
}
