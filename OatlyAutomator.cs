using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NewsifyMe
{
    public class OatlyAutomator : IWebsiteAutomator
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public OatlyAutomator(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void SignUp(string firstName, string lastName, string email)
        {
            try
            {
                _driver.Navigate().GoToUrl("https://www.oatly.com/spam/sign-up");

                try
                {
                    var acceptCookiesButton = _wait.Until(driver => driver.FindElement(By.CssSelector("Your_Cookies_Accept_Button_CSS_Selector_Here")));
                    acceptCookiesButton.Click();
                }
                catch (WebDriverTimeoutException)
                {
                    // The cookies accept button did not appear within the wait time. Continue with the rest of the operations.
                }

                var firstNameInput = _wait.Until(driver => driver.FindElement(By.Id("first-name")));
                firstNameInput.SendKeys(firstName);

                var lastNameInput = _wait.Until(driver => driver.FindElement(By.Id("last-name")));
                lastNameInput.SendKeys(lastName);

                var emailInput = _wait.Until(driver => driver.FindElement(By.CssSelector("input[type='email']")));
                emailInput.Clear();
                emailInput.SendKeys(email);

                var checkbox = _wait.Until(driver => driver.FindElement(By.CssSelector(".Checkbox-module_FauxCheckbox__wSTQr")));
                checkbox.Click();

                var signUpButton = _wait.Until(driver => driver.FindElement(By.CssSelector(".BaseButton-module_BaseButton__G2Q7B")));
                signUpButton.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in Oatly SignUp: {ex.Message}");
            }
        }
    }
}