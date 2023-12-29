using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_test.Harness
{
    internal class JournalAppDriver : ChromeDriver
    {
        public JournalAppDriver(ApplicationRunnerConfig config) : base(config.WebDriverBin, BuildChromeOptions(config)) 
        {
            itemExistsWait = new DefaultWait<IWebDriver>(this);
            itemExistsWait.Timeout = TimeSpan.FromSeconds(5);
            itemExistsWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            itemExistsWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public void SubmitForm()
        {
            this.FindElement(By.TagName("form")).Submit();
        }

        public string GetElementText(string elementId)
        {
            var element = this.FindElement(By.Id(elementId));
            return element.Text;
        }

        public void SetFormInput(string inputId, string inputValue)
        {
            this.FindElement(By.Id(inputId)).SendKeys(inputValue);
        }

        public void WaitForElement(string elementId)
        {
            itemExistsWait.Until(d => d.FindElement(By.Id(elementId)).Displayed);
        }

        private static ChromeOptions BuildChromeOptions(ApplicationRunnerConfig config)
        {
            var options = new ChromeOptions();
            if (config.RunChromeInHeadlessMode)
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");
                options.AddArgument("--window-size=1920x1080");
                options.AddArgument("--window-size=1920x1080");
                options.AddArgument("--ignore-certificate-errors");
            }
            return options;
        }

        private DefaultWait<IWebDriver> itemExistsWait;
    }
}
