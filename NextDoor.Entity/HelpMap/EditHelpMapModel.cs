using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.HelpMap
{
    public class EditHelpMapModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ParentMessageId { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string Message { get; set; }
    }
}
