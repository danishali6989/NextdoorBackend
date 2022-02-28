using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.HelpMap
{
    public class AddHelpMapModel
    {
        public  int ParentMessageId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }
}
