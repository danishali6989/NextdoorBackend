using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string GroupName { get; set; }
        public string GroupTimeStamp { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }
    }
}
