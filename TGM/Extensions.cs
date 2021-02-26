using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebBotCore
{
    public static class Extensions
    {
        public static bool IsElementExist(this IWebDriver driver, By options)
        {
            try
            {
                driver.FindElement(options);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static IWebElement WaitElement(this IWebDriver driver, By options, int milliseconds)
        {
            int totalDuration = 0;
            var delay = 300;

            while (true)
            {
                if (driver.IsElementExist(options))
                {
                    return driver.FindElement(options);
                }
                
                Thread.Sleep(delay);
                totalDuration += delay;

                if (totalDuration > milliseconds)
                {
                    throw new NoSuchElementException("Element not exist: " + options.ToString());
                }
            }           
        }
    }
}
