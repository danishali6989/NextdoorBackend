using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
    public class Neighbourhood
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public string NeighbourhoodName { get; set; }
        public string Postalcode { get; set; }
        public string NeighbourhoodTimeStamp { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
