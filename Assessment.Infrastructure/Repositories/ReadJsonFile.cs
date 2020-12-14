using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment.Application.Interfaces;
using Assessment.Core.Entities;
using Newtonsoft.Json;
using Serilog;

namespace Assessment.Infrastructure.Repositories
{
    public class ReadJsonFile : IReadJsonFile
    {

        public  string ReadFile(string Location)
        {  
            var inputData = "";
            var log = new LoggerConfiguration().WriteTo.Console().WriteTo.File("log.txt") .CreateLogger();
   
            try
            {
                log.Information("Start logging for the read json method");
                using (var sr = new StreamReader(Location))
                {
                    inputData = sr.ReadToEnd();
                }
                var response = JsonConvert.DeserializeObject<InputJson>(inputData);
                log.Information("Reading endpoint.json was successful");
                return inputData;
            }
            catch (FileNotFoundException ex)
            {
                log.Information(ex.Message);
                return ex.Message;
              
            }

        }

    }
}
