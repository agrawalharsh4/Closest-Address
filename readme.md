This web application provides the shortest distance between the address user input and the address that are in csv files.

Assumptions-

1. The Data provided in .csv file contains the latitude/longitude for test. Alternatively this value can also be fetched from
Google GeoCoding API (Sample code included)
2. The distance currently being calculated is implemented on the algorithm used by https://www.geodatasource.com/. This value
can also be fetched using the Google Distance Matrix API (this API will provide a real time distance between 2 location).

Configuration -
1. In Web.config file provide the file path of the .csv file in "filePath" setting.

Production Scope -

1. Google Distance Matrix API accepts multiple destination Coordinates which can return distance required in 1 API call.
2. The Coordinates of the address to be stored in CSV/DB should also be stored at the time of record creation.

  