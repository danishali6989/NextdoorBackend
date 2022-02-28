using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.Poll
{
    public  class PollAddModel
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string Question { get; set; }
        public string Description { get; set; }
       
        public string TimeStamp { get; set; }

        public List<string> image { get; set; }
        public List<string> video { get; set; }
        public string FileUrl { get; set; }
          public string FileData { get; set; }
        public string MediaType { get; set; }

        public List<AddPollOptionModel> Option { get; set; }
    }
}
