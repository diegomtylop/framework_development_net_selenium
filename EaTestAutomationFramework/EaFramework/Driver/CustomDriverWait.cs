using System;
using EaFramework.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EaFramework.Driver;

public class CustomDriverWait : ICustomDriverWait
{
    private readonly IDriverFixture _driverFixture;
    private readonly TestSettings _testSettings;

    //Lazy initialization
    private readonly Lazy<WebDriverWait> _lazyWait;

    public CustomDriverWait(IDriverFixture driverFixture, TestSettings testSettings)
    {
        this._driverFixture = driverFixture;
        this._testSettings = testSettings;

        //Lazy initialization
        _lazyWait = new Lazy<WebDriverWait>(GetWebDriverWait);
    }

    public IWebElement FindElement(By elementLocator)
    {
        return _lazyWait.Value.Until(drv => drv.FindElement(elementLocator));
    }

    public IEnumerable<IWebElement> FindElements(By elementLocator)
    {
        return _lazyWait.Value.Until(drv => drv.FindElements(elementLocator));
    }

    private WebDriverWait GetWebDriverWait()
    {
        return new(_driverFixture.Driver, timeout: TimeSpan.FromSeconds(_testSettings.TimeOutInterval ?? 30))
        {
            PollingInterval = TimeSpan.FromMilliseconds(500)
        };
    }
}

