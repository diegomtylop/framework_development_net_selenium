using System;
using EaFramework.Driver;

namespace EaFramework.Config;

//Settings used on each test
public class TestSettings
{
	public BrowserType BrowserType { get; set; }

    public Uri ApplicationUrl { get; set; }

    public float? TimeOutInterval { get; set; }

    public int? PollingInterval { get; set; }
}

