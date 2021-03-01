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
        OperationResult Execute(IWebDriver driver);
    }
}
