using BusinessLogic.AddressStore;
using GoogleMapApiIntegration.ApiCalls;
using Respositories.AddressStore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClosestAddress.Pages
{
    public partial class Index : System.Web.UI.Page
    {

        List<Address> addressStore = new List<Address>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string filePath = string.Empty;
                filePath = ConfigurationManager.AppSettings["filePath"];
                List<string> addressString = AddressStoreHelper.ReadAddressFromCsv(filePath);
                GetAddressObj(addressString); //Get Lat/Long from CSV file
                //GetAddreObjGApi(addressString); //Get Lat/Long from Google GeoCoding API
            }
        }

        protected void btnSubmitAddress_Click(object sender, EventArgs e)
        {
            string inputAddress = txtAddress.Text;
            Address inputLatLong = GeoCodingApi.GetGeoCod(inputAddress);
            if (!string.IsNullOrEmpty(inputAddress))
            {
                foreach (Address address in addressStore)
                {
                    if (address != null)
                    {
                        address.Distance = DistanceCalculation.Distance(address.Latitude, address.Longitude, inputLatLong.Latitude, inputLatLong.Longitude, 'K');
                        //address.Distance = DistanceMatrixApi.GetDistance(address, inputLatLong); Get distance from Google Distance Matrix API
                    }
                }
                var closestAddress = addressStore.OrderBy(x => x.Distance).Take(5);
                repAddress.DataSource = closestAddress;
                repAddress.DataBind();
            }
        }

        /// <summary>
        /// Create the Address objects using the data of csv file
        /// </summary>
        /// <param name="addresses"></param>
        void GetAddressObj(List<string> addresses)
        {
            foreach (string address in addresses)
            {
                var splitAddress = address.Replace("\"", "").Replace("\\", "").Split(',');
                double lat;
                double lng;
                addressStore.Add(new Address
                {
                    AddressName = splitAddress[0] + ", " + splitAddress[1],
                    Latitude = (double.TryParse(splitAddress[splitAddress.Length - 2], out lat)) ? lat : 0,
                    Longitude = (double.TryParse(splitAddress[splitAddress.Length - 1], out lng)) ? lng : 0
                });
            }
        }

        void GetAddreObjGApi(List<string> addresses)
        {
            foreach (string address in addresses)
            {
                var splitAddress = address.Replace("\"", "").Replace("\\", "").Split(',');
                addressStore.Add(GeoCodingApi.GetGeoCod(splitAddress[0] + ", " + splitAddress[1]));
            }
        }
        protected void repAddress_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Address add = (Address)e.Item.DataItem;
                ((Label)e.Item.FindControl("lblRepAddress")).Text = add.AddressName;
                ((Label)e.Item.FindControl("lblRepDistance")).Text = add.Distance.ToString("#.##");
            }
        }
    }
}