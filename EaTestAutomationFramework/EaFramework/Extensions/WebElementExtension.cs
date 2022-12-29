using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EaFramework.Extentions;

/*
 * Class with different extension methos on the WebElements
 * 
 * The class must be static as well as the methods
 */
public static class WebElementExtension
{

	public static void SelectDropDownByText( this IWebElement webElement, string text)
	{
		new SelectElement(webElement).SelectByText(text);
	}

    public static void SelectDropDownByValue(this IWebElement webElement, string value)
    {
        new SelectElement(webElement).SelectByValue(value);
    }

    public static void SelectDropDownByIndex(this IWebElement webElement, int index)
    {
        new SelectElement(webElement).SelectByIndex( index );
    }

    public static void ClearAndEnterText(this IWebElement webElement, string text)
    {
        webElement.Clear();
        webElement.SendKeys(text);
    }
}

