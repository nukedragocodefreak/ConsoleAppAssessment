using Assessment.Core.Entities;
using Assessment.Infrastructure.Requests;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Infrastructure.BL
{
    public class Request
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetStringAsync(string input, int service)
        {
            var getdata = new RequestInfor();
            string responseBody = "";
            var output = "";
            List<string> request = new List<string>();
            List<string> status = new List<string>();

            var log = new LoggerConfiguration().WriteTo.Console().WriteTo.File("logrequests.txt").CreateLogger();

            try
            {
                log.Information("Start logging for the Make Request method");
                var inputdata = JsonConvert.DeserializeObject<InputJson>(input);
                RequestInfor[] getdata1 = new RequestInfor[inputdata.services[service].endpoints.Length];

                for (int i = 0; i < inputdata.services[service].endpoints.Length; i++)
                {
                    getdata = new RequestInfor()
                    {
                        BaseUrl = inputdata.services[service].baseURL,
                        Method = inputdata.services[service].endpoints[i].method,
                        Resource = inputdata.services[service].endpoints[i].resource,
                        DataType = inputdata.services[service].datatype
                    };

                    HttpResponseMessage response = await client.GetAsync(getdata.BaseUrl + getdata.Resource);
                    status.Add(response.StatusCode.ToString());
                    log.Information(response.StatusCode.ToString());
                    responseBody = await response.Content.ReadAsStringAsync();
                    request.Add(responseBody);
                    output = JsonConvert.SerializeObject(request);
                }
                log.Information("Finished with the requests");
                return output;
            }
            catch (HttpRequestException e)
            {
                log.Information(e.Message);
                return "\nException Caught!" + e.Message;

            }
        }
    }
}
