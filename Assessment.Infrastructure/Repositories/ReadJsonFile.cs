using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment.Application.Interfaces;
using Assessment.Core.Entities;
using Newtonsoft.Json;

namespace Assessment.Infrastructure.Repositories
{
    public class ReadJsonFile : IReadJsonFile
    {
        public  string ReadFile(string Location)
        {
       
            var inputData = "";

            try
            {
                using (var sr = new StreamReader(Location))
                {
                    inputData = sr.ReadToEnd();
                }
                var response = JsonConvert.DeserializeObject<InputJson>(inputData);

                return inputData;
            }
            catch (FileNotFoundException ex)
            {
               return ex.Message;
              
            }

        }

    }
}
