using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs_Test_Framework
{
    public class BasePage
    {
        public static IWebDriver driver;
        

        public static void SeleniumtInit()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }


        public void Write(By by, string data)
        {
            driver.FindElement(by).SendKeys(data);
        }

        public void Click(By by)
        {
            driver.FindElement(by).Click();
        }

        public static void OpenUrl(string url)
        {
            driver.Url = url;
        }

        public static void SeleniumtCleanup()
        {
            driver.Close();
        }


    }
}
