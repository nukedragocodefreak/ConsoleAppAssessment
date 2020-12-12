using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment.Application.Interfaces;


namespace Assessment.Infrastructure.BL
{
    public class BL
    {
        private IReadJsonFile _readJson;

        public BL(IReadJsonFile readJson)
        {
            _readJson = readJson;
        }

        public string ReadJsonFile(string location)
        {
          return  _readJson.ReadFile(location);
        }
    }
}
