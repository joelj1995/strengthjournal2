using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_test.Harness
{
    internal static class SecretTestParameters
    {
        public static string UserPassword => 
            Environment.GetEnvironmentVariable("SJ_USER_PASSWORD") 
            ?? throw new NullReferenceException("Environment variable SJ_USER_PASSWORD not set");
    }
}
