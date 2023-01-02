using AutoFixture.Xunit2;
using EaApplicationTest.Pages;
namespace EaApplicationTest;

public class UnitTestClean
{
    private readonly IHomePageDI _homePageDI;

    public UnitTestClean(IHomePageDI injectedHomePage)
    {
        this._homePageDI = injectedHomePage;
    }

    /**
     * Implementing the initial test but using dependency injection
     */
    [Fact]
    public void CreateProductDI()
    {
        var productPage = _homePageDI.ClickProductWithNavigation();
        productPage.ClickCreateButton();
        productPage.CreateProduct("Headphone", "Description", "120", "MONITOR");
    }

    [Fact]
    public void CreateProductDISecond()
    {
        var productPage = _homePageDI.ClickProductWithNavigation();
        productPage.ClickCreateButton();
        productPage.CreateProduct("Keyboard", "Description second", "120", "MONITOR");
    }
}
