using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
    public class JoinNeighbourhood
    {
        public int Id { get; set; }
        public int NeighbourhoodId { get; set; }
        public Neighbourhood Neighbourhood { get; set; }
        public int UserId { get; set; }
        public string TimeStamp { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }
    }
}
