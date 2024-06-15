using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs_Test_Framework
{
    public class LoginPage:BasePage
    {
        By usernameTxt = By.Id("user-name");
        By passwordTxt = By.Id("password");
        By loginBtn = By.Id("login-button");
        

        public void Login(string url,string user, string pass)
        {

            driver.FindElement(usernameTxt).SendKeys(user);
            driver.FindElement(passwordTxt).SendKeys(pass);
            driver.FindElement(loginBtn).Click();

        }

        public void Login(string user, string pass)
        {
            Write(usernameTxt, user);
            Write(passwordTxt, pass);
            Click(loginBtn);

        }

    }
}
