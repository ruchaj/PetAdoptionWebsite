using NUnit.Framework;
using System;
using System.Net;
using Newtonsoft.Json.Linq;
using ContosoCrafts.WebSite.Services;
using System.Diagnostics;

public class GeocodingServiceTests
{

    [Test]
    public void GetCoordinates_ValidLocation_ReturnsCoordinates()
    {
        // Arrange
        string location = "Seattle, WA";

        // Act

        (double latitude, double longitude) = GeocodingService.GetCoordinates(location);

        Console.WriteLine(location);
        Console.WriteLine("latitue: " + latitude + "longitude: " + longitude);

        // Assert
        Assert.AreEqual(latitude, 47.606209499999999);
        Assert.AreEqual(longitude, -122.3320708);
    }

    [Test]
    public void GetCoordinates_InvalidLocation_ReturnsDefaultCoordinates()
    {
        // Arrange
        string location = "Invalid Location";
        string expectedResponse = "{\"result\": null}";

        // Act
        (double latitude, double longitude) = GeocodingService.GetCoordinates(location);

        // Assert
        Assert.AreEqual(0.0, latitude);
        Assert.AreEqual(0.0, longitude);
    }
}
