using OpenQA.Selenium;

namespace EaFramework.Driver;

//Recommended for when we're using DI
public interface IDriverFixture
{
    IWebDriver Driver { get; }
}