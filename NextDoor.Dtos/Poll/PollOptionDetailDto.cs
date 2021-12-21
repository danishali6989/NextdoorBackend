using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Dtos.Poll
{
    public class PollOptionDetailDto
    {

        public int Id { get; set; }
        public int User_id { get; set; }
        public int Poll_id { get; set; }
        public int response_id { get; set; }
       
        public string OptionName { get; set; }
        public int? count { get; set; }
        

        /* public string Attachment { get; set; }
         public string AttachmentType { get; set; }*/
        // public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
