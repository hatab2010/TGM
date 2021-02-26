using TelegramWebBot.Data;
using WebBotCore.Operation;
using WebBotCore;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System;
using WebBotCore.Interfase;
using WebBotCore.Model;
using System.Collections.Generic;

namespace TelegramWebBot.Operation
{
    class LoginOperation : OperationBase, ISiteAuthorize
    {
        public  IProfile Profile { private set; get; }
        public Action<IAuthorizedTicket> SuccessAction { get; private set; }

        public LoginOperation(TelegramProfile profile, Action<IAuthorizedTicket> successCallback)
        {
            SuccessAction = successCallback;
            Profile = profile;
            OperationPage = new Uri(Global.TELEGRAM_PAGE_LOGIN);
        }

        protected override void Action()
        {
            driver.Navigate().GoToUrl(Global.TELEGRAM_PAGE_LOGIN);

            var phoneInput = driver.WaitElement(By.XPath("//input[contains(@name, 'phone_number')]"), 10000);
            var correctPhone = Regex.Replace(Profile.Login, @"^\+7|^8", "");

            phoneInput.SendKeys(correctPhone);

            var nextButton = driver
                .FindElement(By.XPath("//a[contains(@class, 'login_head_submit_btn')]"));
            nextButton.Click();

            var modalConfirm = driver
                .FindElement(By.ClassName("confirm_modal_wrap"));

            if (modalConfirm.Displayed)
            {
                var confirmButton = modalConfirm
                    .FindElement(By.ClassName("btn-md-primary"));
                confirmButton.Click();
            }

            //TODO интегрировать API телефонию

            if (!string.IsNullOrEmpty(Profile.Password))
            {
                var passwordInput = driver
                    .WaitElement(By.XPath("//input[contains(@name, 'password')]"), 40000);

                passwordInput.SendKeys(Profile.Password);
                passwordInput.SendKeys(Keys.Enter);
            }


            driver.WaitElement(By.ClassName("dropdown-menu"), 10000);

            var currentCookies = driver.Manage().Cookies.AllCookies;

            var cookies = new List<ICustomeCookie>();

            foreach (var item in currentCookies)
            {
                cookies.Add(new MyCookie()
                {
                     Id = Guid.NewGuid(),
                    //Key = item.k
                });
            }

            SuccessAction?.Invoke(new AuthorizedTicket(OperationPage, Profile)
            {
                AuthorizedCookies = cookies,
            });
        }
    }
}
