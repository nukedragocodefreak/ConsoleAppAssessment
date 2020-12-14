using Assessment.Application.Interfaces;
using Assessment.Infrastructure.BL;
using Assessment.Infrastructure.Repositories;
using ConsoleTables;
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
            //UI.RegisterType<ReadJsonFile>();
            UI.RegisterType<IReadJsonFile, ReadJsonFile>();
            UI.RegisterType<IMakeRequest, MakeRequest>();

            BL bL = UI.Resolve<BL>();
            BLRequest bLRequest = UI.Resolve<BLRequest>();

            //bL.ReadJsonFile(MenuMessages.Messages.Location);
            var table = new ConsoleTable(MenuMessages.Messages.Welcome);        
            table.Write(Format.Alternative);
            Console.WriteLine(bL.ReadJsonFile(MenuMessages.Messages.Location));
            string input = bL.ReadJsonFile(MenuMessages.Messages.Location);
            Console.WriteLine(bLRequest.MakeARequest(input));
            Console.ReadKey();
        }
    }
}
