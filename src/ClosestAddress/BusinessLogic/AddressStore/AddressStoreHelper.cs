using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.AddressStore
{
    public static class AddressStoreHelper
    {
        public static List<string> ReadAddressFromCsv(string filePath)
        {
            List<string> Address = new List<string>();
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    Address.AddRange(values);
                }
            }
            return Address;
        }
    }
}
