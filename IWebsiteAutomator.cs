using OpenQA.Selenium;

namespace NewsifyMe
{
    public interface IWebsiteAutomator
    {
        void SignUp(string firstName, string lastName);
    }
}