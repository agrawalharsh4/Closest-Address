using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.AddressStore
{
    public static class DistanceCalculation
    {
        /// <summary>
        /// Calculate the distance between the origin and destination provided
        /// </summary>
        /// <param name="lat1">latitude of origin</param>
        /// <param name="lon1">longitude of origin</param>
        /// <param name="lat2">latitude of destination</param>
        /// <param name="lon2">longitude of destination</param>
        /// <param name="unit">the unit you desire for results
        ///            where: 'M' is statute miles (default)                         
        //                  'K' is kilometers                                      
        //                  'N' is nautical miles                                  
        /// </param>
        /// <returns></returns>
        public static double Distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            if ((lat1 == lat2) && (lon1 == lon2))
            {
                return 0;
            }
            else
            {
                double theta = lon1 - lon2;
                double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
                dist = Math.Acos(dist);
                dist = rad2deg(dist);
                dist = dist * 60 * 1.1515;
                if (unit == 'K')
                {
                    dist = dist * 1.609344;
                }
                else if (unit == 'N')
                {
                    dist = dist * 0.8684;
                }
                return (dist);
            }
        }

        static private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        static private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
