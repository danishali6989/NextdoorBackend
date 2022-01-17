using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.Group
{
    public class GroupAddModel
    {
        public int id { get; set; }
        public string GroupName { get; set; }
        public int UserId { get; set; }
        public string TimeStamp { get; set; }

    }
}
