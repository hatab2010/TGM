using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebBotCore.Data;
using WebBotCore.Interfase;
using WebBotCore.Operation;

namespace WebBotCore.Model
{

    //TODO реализовать IDispoce
    public class WorkerBase : IWorker
    {
        public IChromeProfile Profile { private set; get; }
        public event Action<OperationResult> OperationExecuted;
        public bool IsActive { private set; get; } = false;
        public List<IOperation> Operations { private set; get; } = new List<IOperation>();
        private IWebDriver driver;
        private Task process;

        public WorkerBase()
        {
            Profile = new ChromeProfile(Guid.NewGuid().ToString());
        }

        public WorkerBase(IChromeProfile profile)
        {
            Profile = profile;
        }

        public void Start(IChromeProfile profile = null)
        {
            IsActive = true;
            SetDriver(Profile.Id.ToString());

            process = new Task(() =>
            {
                while (IsActive)
                {
                    Process();
                }

                lock (driver)
                {
                    driver?.Quit();
                }
            });

            IsActive = true;
            process.Start();
        }

        public async Task StopAsync()
        {
            IsActive = false;
            await process;
        }

        public void setCookies()
        {
            lock (driver)
            {
                throw new NotImplementedException();
            }
        }

        private void SetDriver(string folderName = null)
        {
            var services = ChromeDriverService.CreateDefaultService();
            var options = new ChromeOptions();

            if (!string.IsNullOrEmpty(folderName))
            {
                options
                    .AddArgument($"--user-data-dir={Directory.GetCurrentDirectory()}/{folderName}");
            }

            driver = new ChromeDriver(services, options);
        }

        public void AddOperation(IOperation operation)
        {
            lock (Operations)
            {
                Operations.Add(operation);
            }
        }

        public void Dispose()
        {
            IsActive = false;
            process.Wait();
        }

        //TODO сделать последовательную очередь задач
        private void Process()
        {
            if (driver == null || Operations.Count == 0)
            {
                Thread.Sleep(500);
                return;
            };

            var maxPriorety = Operations.Max(_ => _.Priorety);
            var currentOpertion = Operations.First(_ => _.Priorety == maxPriorety);
            var operationResult = currentOpertion.Execute(driver);

            if (operationResult.IsSuccess)
            {
                Task.Run(() => OperationExecuted?.Invoke(operationResult));
            }
            else
            {

            }               

            lock (Operations)
            {
                Operations.Remove(currentOpertion);
            }

            Thread.Sleep(300);
        }
    }
}