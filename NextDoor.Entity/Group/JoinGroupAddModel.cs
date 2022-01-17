using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.Group
{
    public class JoinGroupAddModel
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public string TimeStamp { get; set; }

    }
}
