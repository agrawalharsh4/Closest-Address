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
    public static class DistanceMatrixApi
    {
        static string apiUrl = "https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins={0}&destinations={1}&key=YOUR_API_KEY";
        public static double GetDistance(Address origin, Address dest)
        {
            try
            {
                double dist = 0;
                apiUrl = string.Format(apiUrl, string.Join(",", origin.Latitude, origin.Longitude), string.Join(",", dest.Latitude, dest.Longitude));
                WebRequest request = WebRequest.Create(apiUrl);
                WebResponse response = request.GetResponse();
                Stream data = response.GetResponseStream();
                StreamReader reader = new StreamReader(data);
                string geCdjson = reader.ReadToEnd();
                response.Close();

                //TODO: parse json and assign distance with the value

                return dist;
            }
            catch (WebException ex)
            {
                return 0;
            }
            catch (Exception webEx)
            {
                throw webEx;
            }
        }
    }
}
