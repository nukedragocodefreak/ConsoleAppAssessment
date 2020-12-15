using Assessment.Application.Interfaces;
using Assessment.Infrastructure.BL;
using Assessment.Infrastructure.Repositories;
using Assessment.Infrastructure;
using ConsoleTables;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.IO;

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
            var status = File.ReadAllLines("statuses.txt");
            var statuses = new List<string>(status);

            if (statuses.ElementAt(0) == "OK" & statuses.ElementAt(1) == "OK" & statuses.ElementAt(2) == "OK")
            {
                bLRequest.MakeARequest(input, 1);
            }
            else
            {
                var table1 = new ConsoleTable(MenuMessages.Messages.outcome);
                table1.Write(Format.Alternative);
                bLRequest.MakeARequest(input, 0);
            }

            Console.ReadKey();
        }
    }
}
