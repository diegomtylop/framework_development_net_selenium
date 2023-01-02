using System;
using EaFramework.Driver;
using OpenQA.Selenium;

namespace EaApplicationTest.Pages;

/**
 * Interface of the HomePage to see how the DI
 * framework is used in the course
 */
public interface IHomePageDI
{
    void ClickHome();
    void ClickPrivacy();
    void ClickProduct();
    ProductPage ClickProductWithNavigation();
}

public class HomePageDI : IHomePageDI
{

    private readonly IDriverFixture _driverFixture;


    //Page Factory is deprecated and this is the suggested way
    private IWebElement lnkHome => _driverFixture.Driver.FindElement(By.LinkText("Home"));

    private IWebElement lnkPrivacy => _driverFixture.Driver.FindElement(By.LinkText("Privacy"));

    private IWebElement lnkProduct => _driverFixture.Driver.FindElement(By.LinkText("Product"));

    //Automatically injected
    public HomePageDI(IDriverFixture fixture)
    {
        _driverFixture = fixture;
    }

    //The methods can be implemented using lamda expressions as well
    public void ClickProduct() => lnkProduct.Click();

    public ProductPage ClickProductWithNavigation()
    {
        lnkProduct.Click();
        return new ProductPage(_driverFixture);
    }

    public void ClickHome() => lnkHome.Click();

    public void ClickPrivacy() => lnkPrivacy.Click();
}

