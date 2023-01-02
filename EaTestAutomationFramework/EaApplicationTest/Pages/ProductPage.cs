using System;
using EaApplicationTest.Models;
using EaFramework.Driver;
using EaFramework.Extentions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EaApplicationTest.Pages;

public class ProductPage
{

    private readonly IDriverFixture _driverFixture;
    private readonly ICustomDriverWait? _driverWithWait;

    //Page Factory is deprecated and this is the suggested way
    //private IWebElement lnkCreate => _driverFixture.Driver.FindElement(By.LinkText("Create"));
    private IWebElement lnkCreate {
        get {
                //Workaround to support the custom DriverWait
                return _driverWithWait == null ?
                    _driverFixture.Driver.FindElement(By.LinkText("Create")) :
                    _driverWithWait.FindElement(By.LinkText("Create"));
        }
    }

    //Product creation
    private IWebElement txtName => _driverFixture.Driver.FindElement(By.Id("Name"));
    private IWebElement txtDescription => _driverFixture.Driver.FindElement(By.Id("Description"));
    private IWebElement txtPrice => _driverFixture.Driver.FindElement(By.Id("Price"));
    private IWebElement ddlProductType => _driverFixture.Driver.FindElement(By.Id("ProductType"));
    private IWebElement btnCreate => _driverFixture.Driver.FindElement(By.LinkText("Create"));

    //Automatically injected
    public ProductPage(IDriverFixture fixture, ICustomDriverWait driverWithWait)
    {
        _driverFixture = fixture;
        this._driverWithWait = driverWithWait;
    }

    public ProductPage(IDriverFixture fixture)
    {
        _driverFixture = fixture;
    }

    public void ClickCreateButton() => lnkCreate.Click();

    public void CreateProduct(string name,
        string desc,
        string price,
        string productType)
    {
        txtName.SendKeys(name);
        txtDescription.SendKeys(desc);
        txtPrice.SendKeys(price);

        //Custom extension method
        ddlProductType.SelectDropDownByText(productType);
        //The previos extension method replaces this one
        //new SelectElement(ddlProductType).SelectByText(productType);

        //btnCreate.Click();
    }

    //Create a product accepting a model object
    public void CreateProduct(Product product)
    {

        CreateProduct(product.Name,
            product.Description,
            product.Price.ToString(),
            product.ProductType.ToString());
    }

}

