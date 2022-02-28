using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Dtos.HelpMap
{
    public class HelpMapDto
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ParentMessageId { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
