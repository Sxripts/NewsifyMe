using NewsifyMe;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace NewsifyMe
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the Gmail to use:");
            string gmail = Console.ReadLine();

            try
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                using IWebDriver driver = new ChromeDriver();
                RandomUserGenerator randomUser = new();

                IWebsiteAutomator oatlyAutomator = new OatlyAutomator(driver);
                var (oatlyFirstName, oatlyLastName) = randomUser.GenerateRandomUserName();
                oatlyAutomator.SignUp(oatlyFirstName, oatlyLastName, gmail);

                IWebsiteAutomator anotherWebsiteAutomator = new AnotherWebsiteAutomator(driver);
                var (anotherFirstName, anotherLastName) = randomUser.GenerateRandomUserName();
                anotherWebsiteAutomator.SignUp(anotherFirstName, anotherLastName, gmail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in Main: {ex.Message}");
            }
        }
    }
}