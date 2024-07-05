using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;

namespace SwagLabs_Test_Framework
{
    [TestClass]
    public class TestExecution
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

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
            BasePage.OpenUrl("https://www.saucedemo.com/");
            loginPage.Login("standard_user", "secret_sauce");
            // Add any relevant assertions or checks here
        }

        [TestMethod]
        [Description("Verify unsuccessful login with invalid credentials.")]
        public void Login_TC_002()
        {
            LoginPage loginPage = new LoginPage();
            BasePage.OpenUrl("https://www.saucedemo.com/");
            loginPage.Login("user", "wrong_password");
            Thread.Sleep(3000);
            Assert.IsTrue(BasePage.driver.FindElement(By.ClassName("error-button")).Displayed);
        }

        [TestMethod]
        [Description("Verify product selection from Homepage.")]
        public void ViewProduct_TC_003()
        {
            LoginPage loginPage = new LoginPage();
            HomePage home = new HomePage();
            BasePage.OpenUrl("https://www.saucedemo.com/");
            loginPage.Login("standard_user", "secret_sauce");
            home.SelectProduct();
            string pr_name = BasePage.driver.FindElement(By.CssSelector(".inventory_details_name")).Text;
            Assert.AreEqual("Sauce Labs Backpack", pr_name);
        }

        [TestMethod]
        [Description("Verify Product Add To Cart from Homepage.")]
        public void AddToCart_TC_004()
        {
            LoginPage loginPage = new LoginPage();
            HomePage home = new HomePage();
            BasePage.OpenUrl("https://www.saucedemo.com/");
            loginPage.Login("standard_user", "secret_sauce");
            home.AddToCart();
            // Add assertions or additional checks as needed
        }

        [TestMethod]
        [Description("Verify Cart button click.")]
        public void ViewCart_TC_005()
        {
            LoginPage loginPage = new LoginPage();
            HomePage home = new HomePage();
            BasePage.OpenUrl("https://www.saucedemo.com/");
            loginPage.Login("standard_user", "secret_sauce");
            home.ViewCart();
            // Add assertions or additional checks as needed
        }

        [TestMethod]
        [Description("Verify Product Add to Cart and then view same Product in Cart")]
        public void ViewCart_TC_006()
        {
            LoginPage loginPage = new LoginPage();
            HomePage home = new HomePage();
            BasePage.OpenUrl("https://www.saucedemo.com/");
            loginPage.Login("standard_user", "secret_sauce");
            home.AddToCart();
            home.ViewCart();
            string cart_pr = BasePage.driver.FindElement(By.ClassName("inventory_item_name")).Text;
            Assert.AreEqual("Sauce Labs Backpack", cart_pr);
        }
    }
}
