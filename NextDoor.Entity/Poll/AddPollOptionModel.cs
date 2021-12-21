using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.Poll
{
    public class AddPollOptionModel
    {
        public int Id { get; set; }
        public int user_id { get; set; }
        public int poll_id { get; set; }
        public string OptionName { get; set; }
    }
}
