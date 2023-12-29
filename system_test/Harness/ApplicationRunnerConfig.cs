using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_test.Harness
{
    internal class ApplicationRunnerConfig
    {
        public string WebDriverBin => ContainerMode ?
            "/chromedriver-linux64/chromedriver"
            : @"C:\Users\colte\Downloads\chromedriver-win64\chromedriver-win64\chromedriver.exe";
        public bool RunChromeInHeadlessMode => ContainerMode;
        public string JournalAppBaseUrl => AppBaseUrl;
        private static bool ContainerMode => Environment.GetEnvironmentVariable("CONTAINER_MODE")?.Equals("true") ?? false;
        private string AppBaseUrl => ContainerMode ? "https://spa/app" : "http://localhost:4200";
    }
}
