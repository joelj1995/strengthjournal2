using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace system_test.Harness
{
    internal class ApplicationRunner : IDisposable
    {
        public ApplicationRunner()
        {
            config = new ApplicationRunnerConfig();
            driver = new JournalAppDriver(config);
            driver.Manage().Window.Maximize();
        }

        internal void Login()
        {
            driver.Url = $"{config.JournalAppBaseUrl}/";
            driver.WaitForElement("username");
            driver.SetFormInput("username", "strengthjournal@joelj.ca");
            driver.SetFormInput("password", SecretTestParameters.UserPassword);
            driver.SubmitForm();
        }

        internal bool ShowsWelcomeMessage()
        {
            driver.WaitForElement("welcomeMessage");
            var message = driver.GetElementText("welcomeMessage");
            return message.Equals("Welcome, Joel");
        }

        public void Dispose()
        {
            driver.Close();
            driver.Quit();
        }
        
        private readonly ApplicationRunnerConfig config;
        private JournalAppDriver driver;
    }
}
