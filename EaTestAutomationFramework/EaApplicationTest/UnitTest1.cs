using AutoFixture.Xunit2;
using EaApplicationTest.Models;
using EaApplicationTest.Pages;
using EaFramework.Config;
using EaFramework.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EaApplicationTest;

public class UnitTest1:IDisposable
{

    private IDriverFixture _driverFixture;
    private ICustomDriverWait _driverWait;

    public UnitTest1(IDriverFixture injectedDriverFixture, ICustomDriverWait injectedDriverWait)
    {
        this._driverFixture = injectedDriverFixture;
        this._driverWait = injectedDriverWait;
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
    public void TestWithDDT(
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
    public void TestWithDTO(Product product)
    {
        var homePage = new HomePage(_driverFixture);
        var productPage = homePage.ClickProductWithNavigation();
        productPage.ClickCreateButton();
        productPage.CreateProduct( product );
    }

    //Is the equivalent to @TearDown on NUnit
    public void Dispose()
    {
        //Provisional wait to be able to see the result before closing the browser
        //Thread.Sleep(2000);
        Console.WriteLine("Running the Dispose method");
        _driverFixture.Driver.Quit();
    }
}
