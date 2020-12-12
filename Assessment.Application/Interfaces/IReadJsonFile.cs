using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment.Core.Entities;

namespace Assessment.Application.Interfaces
{
    public interface IReadJsonFile
    {
        string ReadFile(string Location);
    }
}
