using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
    public class HelpMap
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public NextDoorUser NextDoorUser { get; set; }
        public string Message { get; set; }
        public int ParentMessageId { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
