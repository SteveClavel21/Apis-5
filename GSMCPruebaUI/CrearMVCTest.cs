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
            private string baseUrl = "https://localhost:7151"; // Cambia esta URL por la que corresponda a tu proyecto

            [TestInitialize]
            public void SetUp()
            {
                // Iniciar el driver de Chrome
                driver = new ChromeDriver();
            }

            [TestMethod]
            public void TestCreateProduct()
            {
                // Navegar a la URL del formulario de creación
                driver.Navigate().GoToUrl(baseUrl + "/ProductGSMC/Create");

                // Buscar y rellenar los campos del formulario
                driver.FindElement(By.Id("NombreGSMC")).SendKeys("Producto de prueba");
                driver.FindElement(By.Id("DescripcionGSMC")).SendKeys("Descripción del producto de prueba");
                driver.FindElement(By.Id("PrecioGSMC")).SendKeys("123.45");

                // Hacer clic en el botón "Crear"
                driver.FindElement(By.CssSelector("input[type='submit']")).Click();

                // Verificar si el producto fue creado exitosamente
                Assert.AreEqual(baseUrl + "/ProductGSMC", driver.Url);

                // Opcional: Verificar algún texto en la página que confirme la creación
                // Assert.IsTrue(driver.PageSource.Contains("Producto creado exitosamente"));
            }

            [TestCleanup]
            public void TearDown()
            {
                // Cerrar el navegador al finalizar la prueba
                driver.Quit();
            }

        }
   }

