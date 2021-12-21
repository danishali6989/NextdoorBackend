using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.Poll
{
    public class VoteAddModel
    {
        public int Poll_id { get; set; }
        public int User_id { get; set; }
        public int ResponseId { get; set; }
    }
}
