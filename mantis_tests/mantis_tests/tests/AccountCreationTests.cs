using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [SetUp]
        public void setUpConfig()
        {
            string workDir = @"C:\Users\master\source\repos\mantis-tests\mantis_tests\mantis_tests\";
            app.Ftp.BackupFile("/config_defaults_inc.php");
            using (Stream localFile = File.Open(workDir + "config_defaults_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_defaults_inc.php", localFile);
            }
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };

            app.Registration.Registration(account);
        }

        [TearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_defaults_inc.php");
        }
    }
}
