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
        public async Task<InputJson> ReadFile(string Location)
        {

            var inputData = "";
           
            try
            {
                using (var sr = new StreamReader(Location))
                {
                  inputData = await sr.ReadToEndAsync();            
                }
                var response = JsonConvert.DeserializeObject<InputJson>(inputData);

                return response;
            }
            catch (FileNotFoundException ex)
            {
                inputData = ex.Message;
                throw;
            }

            //throw new NotImplementedException();

        }

    }
}
