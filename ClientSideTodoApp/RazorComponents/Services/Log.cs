using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorComponents.Services
{
    public static class Log
    {
        public static void Debug(object obj)
        {
            System.Console.WriteLine(obj.ToString());
        }
    }
}
