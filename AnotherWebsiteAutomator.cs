using OpenQA.Selenium;

namespace NewsifyMe
{
    public class AnotherWebsiteAutomator : IWebsiteAutomator
    {
        private readonly IWebDriver _driver;

        public AnotherWebsiteAutomator(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SignUp(string firstName, string lastName)
        {
            try
            {
                _driver.Navigate().GoToUrl("https://www.anotherwebsite.com");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in AnotherWebsite SignUp: {ex.Message}");
            }
        }
    }
}
