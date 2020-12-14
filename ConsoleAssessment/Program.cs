using Assessment.Application.Interfaces;
using Assessment.Infrastructure.BL;
using Assessment.Infrastructure.Repositories;
using ConsoleTables;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ConsoleAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
          
            // "Data/endpoints.json"
            UnityContainer UI = new UnityContainer();

            UI.RegisterType<BL>();
            UI.RegisterType<BLRequest>();
            
            UI.RegisterType<IReadJsonFile, ReadJsonFile>();
            UI.RegisterType<IMakeRequest, MakeRequest>();

            BL bL = UI.Resolve<BL>();
            BLRequest bLRequest = UI.Resolve<BLRequest>();

            var table = new ConsoleTable(MenuMessages.Messages.Welcome);        
            table.Write(Format.Alternative);
            Console.WriteLine(bL.ReadJsonFile(MenuMessages.Messages.Location));
            string input = bL.ReadJsonFile(MenuMessages.Messages.Location);
            bLRequest.MakeARequest(input, 0);

            Console.ReadKey();
        }
    }
}
