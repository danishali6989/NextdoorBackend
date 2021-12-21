using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.Location
{
    public class AddLocationModel
    {
        public int userid { get; set; }
        public int NeighbourhoodId { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }
}
