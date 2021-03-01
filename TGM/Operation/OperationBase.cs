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

        public OperationResult Execute(IWebDriver driver)
        {
            this.driver = driver;

            if (!timer.IsRunning)
                timer.Start();

            try
            {
                var result = Action();
                timer.Stop();
                return new OperationResult(result, true, this);
            }
            catch (Exception ex)
            {
                timer.Stop();
                ExceptionManager.Log(ex);
                return new OperationResult(null, false, this);
            }
        }

        protected virtual object Action()
        {
            throw new NotImplementedException();
        }
    }

    public class OperationResult
    {
        public OperationResult(object value, bool isSuccess, IOperation operation)
        {
            CurrentOpeartion = operation;
            Value = value;
            IsSuccess = isSuccess;
        }

        public readonly IOperation CurrentOpeartion;
        public object Value { private set; get; }
        public bool IsSuccess { private set; get; }
    }
}
