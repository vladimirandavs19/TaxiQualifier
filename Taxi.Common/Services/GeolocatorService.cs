using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Common.Services
{
    public class GeolocatorService : IGeolocatorService
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public async Task GetLocationAsync()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var location = await locator.GetPositionAsync(TimeSpan.FromSeconds(60));

                if (location == null)
                {
                    location = await locator.GetLastKnownLocationAsync();
                }

                if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                {
                    //not available or enabled
                    location = null;
                }

                Latitude = location.Latitude;
                Longitude = location.Longitude;
                Longitude = location.Longitude;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
