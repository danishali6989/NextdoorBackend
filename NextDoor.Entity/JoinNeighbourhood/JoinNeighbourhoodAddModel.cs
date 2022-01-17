using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.JoinNeighbourhood
{
    public class JoinNeighbourhoodAddModel
    {
        public int id { get; set; }
        public int NeighbourhoodId { get; set; }
        public int UserId { get; set; }
        public string TimeStamp { get; set; }
    }
}
