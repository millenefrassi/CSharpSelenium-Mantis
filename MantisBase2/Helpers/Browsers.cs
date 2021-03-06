using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2.Helpers
{
    public class Browsers
    {
        private static string seleniumHub = ConfigurationManager.AppSettings["seleniumHub"].ToString();

        #region Chrome
        public static IWebDriver GetLocalChrome()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            chromeOptions.AddArgument("enable-automation");
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--disable-infobars");
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            chromeOptions.AddArgument("--disable-browser-side-navigation");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            
            return new ChromeDriver(chromeOptions);
        }

        public static IWebDriver GetRemoteChrome()
        {
            ChromeOptions chromeOptions = new ChromeOptions();

            chromeOptions.AddArgument("no-sandbox");
            chromeOptions.AddArgument("--allow-running-insecure-content");
            chromeOptions.AddArgument("--lang=pt-BR");

            return new RemoteWebDriver(new Uri(seleniumHub), chromeOptions.ToCapabilities()); ;
        }

        public static IWebDriver GetLocalChromeHeadless()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");

            return new ChromeDriver(chromeOptions);
        }

        public static IWebDriver GetRemoteChromeHeadless()
        {
            ChromeOptions chromeOptions = new ChromeOptions();

            chromeOptions.AddArgument("no-sandbox");
            chromeOptions.AddArgument("--allow-running-insecure-content");
            chromeOptions.AddArgument("--lang=pt-BR");
            chromeOptions.AddArgument("--headless");

            return new RemoteWebDriver(new Uri(seleniumHub), chromeOptions.ToCapabilities()); ;
        }
        #endregion

        #region Firefox
        public static IWebDriver GetLocalFirefox()
        {
            return new FirefoxDriver();
        }

        public static IWebDriver GetRemoteFirefox()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.SetPreference("intl.accept_languages", "pt-BR");

            return new RemoteWebDriver(new Uri(seleniumHub), firefoxOptions.ToCapabilities());
        }
        #endregion

        #region Internet Explorer
        public static IWebDriver GetLocalInternetExplorer()
        {
            InternetExplorerOptions ieOption = new InternetExplorerOptions();
            ieOption.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            ieOption.IgnoreZoomLevel = true;
            return new InternetExplorerDriver(ieOption);
           // return new InternetExplorerDriver();
        }

        public static IWebDriver GetRemoteInternetExplorer()
        {
            InternetExplorerOptions ieOptions = new InternetExplorerOptions();
            ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            ieOptions.IgnoreZoomLevel = true;

            return new RemoteWebDriver(new Uri(seleniumHub), ieOptions.ToCapabilities());
            //return new RemoteWebDriver(ieOptions);
        }
        #endregion

        #region Edge
        public static IWebDriver GetLocalEdge()
        {
            EdgeOptions options = new EdgeOptions();
            return new EdgeDriver(EdgeDriverService.CreateDefaultService(@"C:\git\MantisBase2\MantisBase2\bin\Debug", "msedgedriver.exe"));
            //return new EdgeDriver(new EdgeOptions());
        }

        public static IWebDriver GetRemoteEdge()
        {
            EdgeOptions edgeOptions = new EdgeOptions();

            return new RemoteWebDriver(new Uri(seleniumHub), edgeOptions.ToCapabilities());
        }
        #endregion
    }
}
