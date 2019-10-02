using Respositories.AddressStore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapApiIntegration.ApiCalls
{
    public static class GeoCodingApi
    {
        static string apiUrl = "https://maps.googleapis.com/maps/api/geocode/json?{0}&key=YOUR_API_KEY";

        /// <summary>
        /// Get the geo location (lat/long) of address prvided
        /// </summary>
        /// <param name="address">address input</param>
        /// <returns></returns>
        public static Address GetGeoCod(string address)
        {
            try
            {
                Address userAddress = new Address();
                userAddress.AddressName = address;
                apiUrl = string.Format(apiUrl, address);
                WebRequest request = WebRequest.Create(apiUrl);
                WebResponse response = request.GetResponse();
                Stream data = response.GetResponseStream();
                StreamReader reader = new StreamReader(data);
                string geCdjson = reader.ReadToEnd();
                response.Close();

                //TODO: parse json and return lat/long in dictionary
                userAddress.Latitude = Convert.ToDouble("-32.12212");
                userAddress.Longitude = Convert.ToDouble("16.12412");
                return userAddress;
            }
            catch(WebException ex)
            {
                Address userAddress = new Address();
                userAddress.AddressName = address;
                userAddress.Latitude = Convert.ToDouble("-32.12212");
                userAddress.Longitude = Convert.ToDouble("16.12412");
                return userAddress;
            }
            catch(Exception webEx)
            {
                throw webEx;
            }
        }
    }
}
