using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = true;
        protected ApplicationManager app;

        [SetUp]  //[TestFixtureSetUp] //CS0246: The type or namespace name 'TestFixtureSetUpAtribute' could not  be found(are you missing a using directive or assembly reference?)
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i < l; i++)
            {
                int rI = 65 + Convert.ToInt32(rnd.NextDouble() * 26);
                builder.Append(Convert.ToChar(rI));
            }
            return builder.ToString();
        }
    }
}
