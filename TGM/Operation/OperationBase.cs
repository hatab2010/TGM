using OpenQA.Selenium;
using System;
using System.Diagnostics;
using WebBotCore.Interfase;
using WebBotCore.Model;

namespace WebBotCore.Operation
{
    public abstract class OperationBase : IOperation
    {
        protected IWebDriver driver;
        public int Priorety { get; set; } = 0;

        public long Duration => timer.ElapsedMilliseconds;

        public Uri OperationPage { protected set;  get; }

        private Stopwatch timer = new Stopwatch();

        public void Execute()
        {
            if (!timer.IsRunning)
                timer.Start();

            try
            {
                Action();
                timer.Stop();
            }
            catch (Exception ex)
            {
                timer.Stop();
                ExceptionManager.Log(ex);
            }
        }

        public void SetDriver(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected virtual void Action()
        {
            throw new NotImplementedException();
        }
    }
}
