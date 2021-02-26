using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramWebBot;
using TelegramWebBot.Data;
using TelegramWebBot.Operation;
using WebBotCore.Model;
using WebBotCore.Operation;

namespace TelegramWebBot
{
    class Program
    {
        static Worker worker = new Worker();
        static void Main(string[] args)
        {
            worker.Run();

            var loginOperation = new LoginOperation(
                    new TelegramProfile()
                    {
                        Password = "216910",
                        Login = "89516622107"
                    },

                    (ticket) => { 
                        //TODO сохранить тикет авторизации
                    }
                );

            worker.AddOperation(loginOperation);
            

            Task.Delay(-1).Wait();
        }

        private static void OnOperationExecuted(IOperationResult result)
        {
            if (result is LoginOperation)
            {

            }
        }
    }
}
