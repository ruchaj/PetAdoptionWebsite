﻿using System;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace ContosoCrafts.WebSite.Services
{
    public class GeocodingService
    {
        private const string GeocodingApiUrl = "https://maps.googleapis.com/maps/api/geocode/json";

        public static (double Latitude, double Longitude) GetCoordinates(string location)
        {
            Debug.WriteLine("Location: "+location);
            string url = $"{GeocodingApiUrl}?address={Uri.EscapeDataString(location)}&key=AIzaSyAJ3rjDrbdnvWJer7FbGmIAbNdre6um3p8";
            string responseJson;

            using (WebClient client = new WebClient())
            {
                responseJson = client.DownloadString(url);
            }

            JObject response = JObject.Parse(responseJson);

            Debug.WriteLine(response);

            double latitude = (double)response["results"][0]["geometry"]["location"]["lat"];
            double longitude = (double)response["results"][0]["geometry"]["location"]["lng"];

            return (latitude, longitude);
        }
    }
}
