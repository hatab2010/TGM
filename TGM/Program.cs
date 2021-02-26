using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBotCore.Model;

namespace WebBotCore
{
    class Program
    {
        static Worker worker = new Worker();
        static void Main(string[] args)
        {
            Task.Delay(-1).Wait();
        }
    }
}
