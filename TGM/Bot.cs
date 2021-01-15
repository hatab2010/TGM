using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TGM.Operation;

namespace TGM
{
    public class Bot
    {
        public Guid ID { private set; get; }
        public string ProfilePath { get => $"{Directory.GetCurrentDirectory()}/{ID}"; }

        private IWebDriver _driver;
        private List<IOperation> _operations;

        public Bot()
        {
            ID = Guid.NewGuid();
            SetDriver();
        }

        public Bot(Guid id)
        {
            ID = id;
            SetDriver();
        }

        private void SetDriver()
        {
            var services = ChromeDriverService.CreateDefaultService();
            var options = new ChromeOptions();

            options.AddArgument($"--user-data-dir={ProfilePath}");

            _driver = new ChromeDriver(services, options);

            Task.Run(Process);
        }

        public void AddOperation(IOperation operation)
        {
            lock (_operations)
            {
                _operations.Add(operation);
            }
        }

        public void Process()
        {
            while (true)
            {
                if (_driver == null || _operations.Count == 0) continue;

                var maxPriorety = _operations.Max(_ => _.Priorety);
                var currentOpertion = _operations.First(_ => _.Priorety == maxPriorety);

                var operationSuccess = currentOpertion.Execute();

                if (operationSuccess)
                {
                    lock (_operations)
                    {
                        _operations.Remove(currentOpertion);
                    }
                }
                else
                {

                }

                Thread.Sleep(300);
            }
        }
    }
}
