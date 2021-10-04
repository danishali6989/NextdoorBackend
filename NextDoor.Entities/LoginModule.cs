
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
    public  class LoginModule
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? createdOn { get; set; }
        public bool? status1 { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
