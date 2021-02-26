using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBotCore.Model
{
    public static class ExceptionManager
    {
        public static void Log(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
