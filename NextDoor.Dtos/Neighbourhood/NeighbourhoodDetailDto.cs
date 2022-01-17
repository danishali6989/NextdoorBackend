using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Dtos.Neighbourhood
{
    public class NeighbourhoodDetailDto
    {
        public int id { get; set; }
        public int userid { get; set; }
        public string Neighbourhood_Name { get; set; }
        public string NeighbourhoodTimeStamp { get; set; }
        public string PostalCode { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<AddLocation> location { get; set; }
    }

    public class AddLocation
    {
        public int id { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }
}
