using NextDoor.Models.Location;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.Neigbourhood
{
    public class NeighbourhoodAddModel
    {
        public int id { get; set; }
        public int userid { get; set; }
        public string NeighbourhoodName { get; set; }
        public string PostalCode { get; set; }
        public string NeighbourhoodTimeStamp { get; set; }
        public string TimeStamp { get; set; }

        public List<AddLocationModel> location{ get; set; }
    }
}
