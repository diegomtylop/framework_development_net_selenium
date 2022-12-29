using EaFramework.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace EaFramework.Driver;

//Factory pattern
//The Disposable interface is used to quit the driver
public class DriverFixture : IDriverFixture
{

    public IWebDriver Driver { get; }

    private readonly TestSettings _testSettings;

    public DriverFixture(TestSettings settings)
    {
        this._testSettings = settings;

        this.Driver = GetWebDriver(settings.BrowserType);
        Driver.Navigate().GoToUrl(settings.ApplicationUrl);
    }

    //It was initially used
    private DriverFixture(BrowserType browserType)
    {
        this.Driver = GetWebDriver(browserType);
        //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        Driver.Navigate().GoToUrl("http://localhost:8000");
    }

    private IWebDriver GetWebDriver(BrowserType browserType)
    {
        //In selenium 4 the chrome driver is setup automagically
        return browserType switch
        {
            BrowserType.Chrome => new ChromeDriver(),

            BrowserType.Firefox => new FirefoxDriver(),

            BrowserType.Safari => new SafariDriver(),
            _ => new ChromeDriver()
        };
    }
}

public enum BrowserType
{
	Chrome,
	Firefox,
	Safari
}
