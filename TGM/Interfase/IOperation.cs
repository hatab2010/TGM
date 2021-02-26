using WebBotCore.Operation;
using OpenQA.Selenium;
using System;

namespace WebBotCore.Interfase
{
    public interface IOperation
    {
        Uri OperationPage { get; }
        long Duration { get; }
        int Priorety { set; get; }
        void Execute();

        void SetDriver(IWebDriver driver);
    }
}
