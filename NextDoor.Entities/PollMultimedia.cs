using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
    public class PollMultimedia
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Polld { get; set; }
        public int CategoryID { get; set; }
        public string Atachments { get; set; }
        public string AtachmentType { get; set; }
        public string FileData { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
