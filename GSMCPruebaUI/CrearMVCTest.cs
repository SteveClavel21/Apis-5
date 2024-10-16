using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Microsoft.AspNetCore.Routing;

namespace GSMCPruebaUI
{
    [TestClass]
    public class CrearMVCTest
    {
            private IWebDriver driver;
            private string baseUrl = "https://localhost:7151"; 

            [TestInitialize]
            public void SetUp()
            {
                
                driver = new ChromeDriver();
            }

            [TestMethod]
            public void TestCreateProduct()
            {
              
                driver.Navigate().GoToUrl(baseUrl + "/ProductGSMC/Create");

               
                driver.FindElement(By.Id("NombreGSMC")).SendKeys("Producto de prueba");
                driver.FindElement(By.Id("DescripcionGSMC")).SendKeys("Descripción del producto de prueba");
                driver.FindElement(By.Id("PrecioGSMC")).SendKeys("123.45");

              
                driver.FindElement(By.CssSelector("input[type='submit']")).Click();

               
                Assert.AreEqual(baseUrl + "/ProductGSMC", driver.Url);

               
            }

            [TestCleanup]
            public void TearDown()
            {
               
                driver.Quit();
            }

        }
   }

