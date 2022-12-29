using OpenQA.Selenium;

namespace EaFramework.Driver
{
    public interface ICustomDriverWait
    {
        IWebElement FindElement(By elementLocator);
        IEnumerable<IWebElement> FindElements(By elementLocator);
    }
}