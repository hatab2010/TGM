using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebBotCore.Interfase;
using WebBotCore.Operation;

namespace WebBotCore.Model
{
    public class Worker
    {
        public event Action<IOperation> OperationExecuted;
        public bool IsActive = false;
        public List<IOperation> operations { private set; get; } = new List<IOperation>();
        private IWebDriver driver;

        public void Run()
        {
            IsActive = true;

            SetDriver();
            Task.Run(() =>
            {
                while (IsActive)
                {
                    Process();
                }

                lock (driver)
                {
                    driver?.Dispose();
                }
            });
        }

        public void setCookies()
        {
            lock (driver)
            {

            }
        }

        private void SetDriver()
        {
            var services = ChromeDriverService.CreateDefaultService();
            var options = new ChromeOptions();

            //options.AddArgument($"--user-data-dir={ProfilePath}");

            driver = new ChromeDriver(services, options);
        }

        public void AddOperation(IOperation operation)
        {
            lock (operations)
            {
                operation.SetDriver(driver);
                operations.Add(operation);
            }
        }

        public void Dispose()
        {
            IsActive = false;
        }

        public void Process()
        {
            if (driver == null || operations.Count == 0) 
            {
                Thread.Sleep(500);
                return;
            };

            var maxPriorety = operations.Max(_ => _.Priorety);
            var currentOpertion = operations.First(_ => _.Priorety == maxPriorety);
            currentOpertion.Execute();

            OperationExecuted?.Invoke(currentOpertion);

            lock (operations)
            {
                operations.Remove(currentOpertion);
            }

            Thread.Sleep(300);
        }
    }
}
