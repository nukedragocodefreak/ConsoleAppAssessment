using Assessment.Application.Interfaces;
using Assessment.Core.Entities;
using Assessment.Infrastructure.Requests;
using Assessment.Infrastructure.Utility;
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
       

        public async Task MakeRequests(string input)
        {
            var getdata = new RequestInfor();
            string responseBody = "";
            var output = "";
            List<string> request = new List<string>();

            try
            {
                var inputdata = JsonConvert.DeserializeObject<InputJson>(input);           
                RequestInfor[] getdata1 = new RequestInfor[inputdata.services[0].endpoints.Length];

                for (int i = 0; i < inputdata.services[0].endpoints.Length; i++)
                {
                    getdata = new RequestInfor()
                    {
                      BaseUrl = inputdata.services[0].baseURL,
                      Method = inputdata.services[0].endpoints[i].method,
                      Resource = inputdata.services[0].endpoints[i].resource,
                      DataType = inputdata.services[0].datatype
                    };
                    
                    HttpResponseMessage response = await client.GetAsync(getdata.BaseUrl + getdata.Resource);
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                    request.Add(responseBody);
                    output = JsonConvert.SerializeObject(request);                 
                }           
                //Console.WriteLine(inputdataa);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }
    }
}
