using AutoFixture.Xunit2;
using EaApplicationTest.Models;
using EaApplicationTest.Pages;

namespace EaApplicationTest;

public class UnitTest1
{

    private IDriverFixture _driverFixture;
    private ICustomDriverWait _driverWait;
    private readonly IHomePageDI _homePageDI;

    public UnitTest1(IDriverFixture injectedDriverFixture,
        ICustomDriverWait injectedDriverWait,
        IHomePageDI injectedHomePage)
    {
        this._driverFixture = injectedDriverFixture;
        this._driverWait = injectedDriverWait;
        this._homePageDI = injectedHomePage;
    }

    [Fact]
    public void Test1()
    {
        var homePage = new HomePage(_driverFixture);
        homePage.ClickProduct();
        var productPage = new ProductPage(_driverFixture, _driverWait);
        productPage.ClickCreateButton();
        productPage.CreateProduct("Headphone", "Description", "120", "MONITOR");
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

    //The same test with Navigation on the Page Object
    [Fact]
    public void TestWithNavigation()
    {
        var homePage = new HomePage(_driverFixture);

        var productPage =  homePage.ClickProductWithNavigation();

        productPage.ClickCreateButton();
        productPage.CreateProduct("Hearphone", "Description", "120", "MONITOR");
    }

    //Data Driven Testing with InlineData
    [Theory]
    [InlineData("FirstProduct","New prod description","201","CPU")]
    [InlineData("Second", "New prod description", "202", "MONITOR")]
    [InlineData("Third", "New prod description", "203", "PERIPHARALS")]
    public void CreateProductWithDDT(
        string productName,
        string productDesc,
        string productPrice,
        string productType
    )
    {
        var homePage = new HomePage(_driverFixture);
        homePage.ClickProduct();
        var productPage = new ProductPage(_driverFixture, _driverWait);
        productPage.ClickCreateButton();
        productPage.CreateProduct(productName, productDesc, productPrice, productType);
    }

    /*
     * Data Driven Testing with a better approach using DTO
     * and adding random data by using AutoFixture.XUnit2 dependency
     */ 
    [Theory]
    [AutoData]
    public void CreateProductWithDTO(Product product)
    {
        var homePage = new HomePage(_driverFixture);
        var productPage = homePage.ClickProductWithNavigation();
        productPage.ClickCreateButton();
        productPage.CreateProduct( product );
    }

    //Is the equivalent to @TearDown on NUnit
    //Method commented out since it was moved to the DriverFixture class
    /*public void Dispose()
    {
        //Provisional wait to be able to see the result before closing the browser
        //Thread.Sleep(2000);
        Console.WriteLine("Running the Dispose method");
        _driverFixture.Driver.Quit();
    }*/
}
