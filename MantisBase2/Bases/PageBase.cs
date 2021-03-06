using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MantisBase2.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace MantisBase2.Bases
{
    public class PageBase
    {
        #region Objects and constructor
        protected OpenQA.Selenium.Support.UI.WebDriverWait wait { get; private set; }
        protected IWebDriver driver { get; private set; }
        protected IJavaScriptExecutor javaScriptExecutor { get; private set; }

        public PageBase()
        {
            wait = new OpenQA.Selenium.Support.UI.WebDriverWait(DriverFactory.INSTANCE, TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["timeout_default"].ToString())));
            driver = DriverFactory.INSTANCE;
            javaScriptExecutor = (IJavaScriptExecutor)driver;
        }
        #endregion

        #region Custom Actions

        private void WaitUntilPageReady()
        {
            Stopwatch timeOut = new Stopwatch();
            timeOut.Start();

            while (timeOut.Elapsed.Seconds <= Convert.ToInt32(ConfigurationManager.AppSettings["timeout_default"].ToString()))
            {
                string documentState = javaScriptExecutor.ExecuteScript("return document.readyState").ToString();
                if (documentState.Equals("complete"))
                {
                    timeOut.Stop();
                    break;
                }
            }
        }

        protected IWebElement WaitForElement(By locator)
        {
            WaitUntilPageReady();
            wait.Until(ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            return element;
        }

        protected IWebElement WaitForElementByTime(By locator, int seconds)
        {
            WaitUntilPageReady();
            OpenQA.Selenium.Support.UI.WebDriverWait waitTime = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            waitTime.Until(ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            waitTime.Until(ExpectedConditions.ElementToBeClickable(element));
            return element;
        }

        protected IWebElement WaitForElementDisabled(By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            return element;
        }

        //Função usada para acessar os elementos que estão dentro de um #shadow-root
        //Ex:  WebElement root1 = driver.findElement(By.tagName("driver-app-shell"))---> elemento onde se encontra o shadow-root
        //     WebElement shadowRoot1 = expandShadowRootElement(root); ----> pegando os elementos que estão dentro do shadow-root
        //OBSERVAÇÃO: após o primeiro shaddowRoot só é possível localizar os elementos através de id e css Selectors
        protected IWebElement ExpandShadowRootElement(IWebElement element)
        {
            IWebElement shadowRootElement = (IWebElement) javaScriptExecutor.ExecuteScript("return arguments[0].shadowRoot", element);
            return shadowRootElement;
        }

        protected void Click(By locator)
        {
            Stopwatch timeOut = new Stopwatch();
            timeOut.Start();

            while (timeOut.Elapsed.Seconds <= Convert.ToInt32(ConfigurationManager.AppSettings["timeout_default"].ToString()))
            {
                try
                {
                    WaitForElement(locator).Click();
                    timeOut.Stop();
                    ExtentReportHelpers.AddTestInfo(3, "");
                    return;
                }
                catch (System.Reflection.TargetInvocationException)
                {

                }
                catch (StaleElementReferenceException)
                {

                }
                catch (System.InvalidOperationException)
                {

                }
                catch (WebDriverException e)
                {
                    if (e.Message.Contains("Other element would receive the click"))
                    {
                        continue;
                    }

                    if (e.Message.Contains("Element is not clickable at point"))
                    {
                        continue;
                    }

                    throw e;
                }
            }

            throw new Exception("Given element isn't visible");
        }

        protected void SendKeys(By locator, string text)
        {
            WaitForElement(locator).SendKeys(text);
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + text);
        }

        protected void SendKeysSlowly(By locator, string text)
        {
            foreach(char c in text)
            {
                Thread.Sleep(100);
                WaitForElement(locator).SendKeys(c.ToString());
            }
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + text);

        }

        protected void SendKeysWithoutWaitVisible(By locator, string text)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            element.SendKeys(text);
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + text);
        }

        protected void ComboBoxSelectByVisibleText(By locator, string text)
        {
            OpenQA.Selenium.Support.UI.SelectElement comboBox = new OpenQA.Selenium.Support.UI.SelectElement(WaitForElement(locator));
            comboBox.SelectByText(text);
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + text);
        }

        protected void MouseOver(By locator)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(WaitForElement(locator)).Build().Perform();
            ExtentReportHelpers.AddTestInfo(3, "");
        }

        protected string GetText(By locator)
        {
            string text = WaitForElement(locator).Text;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + text);
            return text;
        }

        protected string GetValue(By locator)
        {
            string text = WaitForElement(locator).GetAttribute("value");
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + text);
            return text;
        }

        protected bool ReturnIfElementIsDisplayed(By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            bool result = driver.FindElement(locator).Displayed;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }

        protected bool ReturnIfElementIsEnabled(By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            bool result = driver.FindElement(locator).Enabled;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }

        protected bool ReturnIfElementIsSelected(By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            bool result = driver.FindElement(locator).Selected;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }

        protected void Clear(By locator)
        {
            WaitForElement(locator).Clear();
        }

        protected void ClearAndSendKeys(By locator, String text)
        {
            WaitForElement(locator).Clear();
            WaitForElement(locator).SendKeys(text);
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + text);
        }

        protected string ReturnAllAtributesOfAnElement(By locator)
        {
            return WaitForElement(locator).GetAttribute("outerHTML");
        }
        #endregion

        #region JavaScript Actions
        protected void SendKeysJavaScript(By locator, string value)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            javaScriptExecutor.ExecuteScript("arguments[0].value='" + value + "';", element);
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + value);
        }

        protected void ClickJavaScript(By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            javaScriptExecutor.ExecuteScript("arguments[0].click();", element);
            ExtentReportHelpers.AddTestInfo(3, "");
        }

        protected void ScrollToElementJavaScript(By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
            IWebElement element = driver.FindElement(locator);
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            ExtentReportHelpers.AddTestInfo(3, "");
        }

        protected void ScrollToTop()
        {
            javaScriptExecutor.ExecuteScript("window.scrollTo(0, 0);");
            ExtentReportHelpers.AddTestInfo(3, "");
        }
        #endregion

        #region Default Actions
        public void Refresh()
        {
            DriverFactory.INSTANCE.Navigate().Refresh();
            ExtentReportHelpers.AddTestInfo(2, "");
        }

        public void NavigateTo(string url)
        {
            DriverFactory.INSTANCE.Navigate().GoToUrl(url);
            ExtentReportHelpers.AddTestInfo(2, "PARAMETER: " + url);
        }

        public void OpenNewTab()
        {
            javaScriptExecutor.ExecuteScript("window.open();");
            ExtentReportHelpers.AddTestInfo(2, "");
        }

        public void SetFocusToLastTab()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            ExtentReportHelpers.AddTestInfo(2, "");
        }

        public void SetFocusToFirstTab()
        {
            driver.SwitchTo().Window(driver.WindowHandles.First());
            ExtentReportHelpers.AddTestInfo(2, "");
        }

        public string GetTitle()
        {
            string title = driver.Title;
            ExtentReportHelpers.AddTestInfo(2, "RETURN: "+title);

            return title;
        }

        public string GetURL()
        {
            string url = driver.Url;
            ExtentReportHelpers.AddTestInfo(2, "RETURN: "+url);

            return url;
        }
        #endregion
    }
}
