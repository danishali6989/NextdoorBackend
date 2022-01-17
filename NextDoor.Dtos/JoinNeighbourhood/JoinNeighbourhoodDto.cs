using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Dtos.JoinNeighbourhood
{
    public class JoinNeighbourhoodDto
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int NeighbourhoodId { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
