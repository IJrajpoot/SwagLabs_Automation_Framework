using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;


namespace SwagLabs_Test_Framework
{
    [TestClass]
    public class TestExecution
    {
        [TestInitialize]
        public void TestInit()
        {
            BasePage.SeleniumtInit();
        }

        [TestCleanup]
        public void TestClean()
        {
            BasePage.SeleniumtCleanup();
        }

        [TestMethod]
        [Description("Verify successful login with valid credentials.")]
        public void Login_TC_001()
        {
            
            LoginPage loginPage = new LoginPage();
            BasePage.OpenUrl("https://www.saucedemo.com/v1/");
            loginPage.Login("standard_user", "secret_sauce");
        }

        [TestMethod]
        [Description("Verify unsuccessful login with invalid credentials.")]
        public void Login_TC_002()
        {
            LoginPage loginPage = new LoginPage();
            BasePage.OpenUrl("https://www.saucedemo.com/");
            loginPage.Login("user", "secret_sauce");
            Thread.Sleep(3000);
            BasePage.driver.FindElement(By.ClassName("error-button")).Click();
        }

        [TestMethod]
        [Description("Verify product selection from Homepage.")]
        public void ViewProduct_TC_003()
        {
            LoginPage loginPage = new LoginPage();
            HomePage home = new HomePage();
            BasePage.OpenUrl("https://www.saucedemo.com/v1/");
            loginPage.Login("standard_user", "secret_sauce");
            home.SelectProduct();
            string pr_name = BasePage.driver.FindElement(By.CssSelector(".inventory_details_name")).Text;

            Assert.AreEqual("Sauce Labs Backpack", pr_name);
            Thread.Sleep(5000);
        }

        [TestMethod]
        [Description("Verify Product Add To Cart from Homepage.")]
        public void AddToCart_TC_004()
        {
            LoginPage loginPage = new LoginPage();
            HomePage home = new HomePage();

            BasePage.OpenUrl("https://www.saucedemo.com/v1/");

            loginPage.Login("standard_user", "secret_sauce");
            home.AddToCart();

            Thread.Sleep(5000);
        }

        //multiple products to cart and think for others too

        [TestMethod]
        [Description("Verify Cart button click.")]
        public void ViewCart_TC_005()
        {
            LoginPage loginPage = new LoginPage();
            HomePage home = new HomePage();

            BasePage.OpenUrl("https://www.saucedemo.com/v1/");

            loginPage.Login("standard_user", "secret_sauce");
            home.ViewCart();

            Thread.Sleep(5000);
        }

        [TestMethod]
        [Description("Verify Product Add to Cart and then view same Product in Cart")]
        public void ViewCart_TC_006()
        {
            LoginPage loginPage = new LoginPage();
            HomePage home = new HomePage();

            BasePage.OpenUrl("https://www.saucedemo.com/v1/");

            loginPage.Login("standard_user", "secret_sauce");
            home.AddToCart();
            home.ViewCart();

            string cart_pr=BasePage.driver.FindElement(By.ClassName("inventory_item_name")).Text;
            Assert.AreEqual("Sauce Labs Backpack", cart_pr);

            Thread.Sleep(3000);
        }
    }
}
