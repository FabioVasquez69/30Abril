using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;



namespace SeleniumPrueba
{    
    public class UnitTest1
    {

        public void TestMethod1()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            ChromeDriver driver = new ChromeDriver(@"D:\chromedriver_win32\", options);
            //ChromeDriver driver = new ChromeDriver(options);
            driver.Url = "https://demoqa.com/browser-windows";
            driver.FindElement(By.XPath("//button[@id='tabButton']")).Click();
            driver.FindElement(By.Id("windowButton")).Click();
            string handle = driver.CurrentWindowHandle;

            Console.WriteLine("Esta es mi ventana actual:" + handle);

            foreach (var windows in driver.WindowHandles)
            {
                Console.WriteLine(windows);

            }

            //driver.Close(); // Para cerrar la pestaña actual

            //  Console.WriteLine(driver.Title);
            Thread.Sleep(5000);

            CambiarseVentana("Google", driver);

            string body = driver.FindElement(By.TagName("body")).Text;
            Console.WriteLine(body);
            Thread.Sleep(5000);
            driver.Quit(); // Para cerrar todo el navegador 
        }

        public static void CambiarseVentana(string titulo, ChromeDriver driver)
        {
            Console.WriteLine(driver.Title);
            //  driver.SwitchTo().Window("Codigo unico");
            foreach (var windows in driver.WindowHandles)
            {
                driver.SwitchTo().Window(windows);
                if (driver.Title.Contains(titulo))
                    break;
                //Console.WriteLine(windows);

            }

        }

        public static void CambiarseVentana2(ChromeDriver driver)
        {
            Console.WriteLine(driver.Title);
            //  driver.SwitchTo().Window("Codigo unico");
            foreach (var windows in driver.WindowHandles)
            {

                if (!driver.CurrentWindowHandle.Equals(windows))
                    driver.SwitchTo().Window(windows);
                //Console.WriteLine(windows);

            }

        }

        public void MetodoIframes()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            ChromeDriver driver = new ChromeDriver(@"D:\chromedriver_win32\", options);
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("frame1")));
            driver.SwitchTo().Frame("Nombre Iframe");
            driver.SwitchTo().Frame("Número");
        }
    }
}