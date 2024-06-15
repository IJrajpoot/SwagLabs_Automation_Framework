using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs_Test_Framework
{
    public class HomePage:BasePage
    {
        By product = By.ClassName("inventory_item_img");
        By addToCart_btn = By.ClassName("btn_inventory");
        By cart_btn = By.ClassName("shopping_cart_link");

        public void SelectProduct()
        {
            Click(product);

        }
        public void AddToCart()
        {
            Click(addToCart_btn);
        }

        public void ViewCart()
        {
            Click(cart_btn);
        }

    }
}
