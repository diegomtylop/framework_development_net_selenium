using System;
using EaFramework.Config;
using EaFramework.Driver;
using Microsoft.Extensions.DependencyInjection;

namespace EaApplicationTest;

/**
 * Used to register the components to be used
 * by the Dependency injection
 */
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        //Registering the objects
        //Singleton because originally it was a static method
		services.AddSingleton(ConfigReader.ReadConfig());

        /*
         * The fist parameterized type is the Interface and the second one
         * is the concrete class that will be returned when an object
         * with the given interface is requested
         */
        services.AddScoped<IDriverFixture, DriverFixture>();

        /**
         * Without DI the instanciation of the driverFixture looked
         * like this, now the testSettings parameter is not
         * required bc the DI container injects it automatically
         * 
        _driverFixture = new DriverFixture(testSettings);
        */

        /**
         * In this case the DriverFixture and te testSettings
         * is automatically injected as well
         * _driverWait = new CustomDriverWait(_driverFixture, testSettings);
         */
        services.AddScoped<ICustomDriverWait, CustomDriverWait>();
    }
}

