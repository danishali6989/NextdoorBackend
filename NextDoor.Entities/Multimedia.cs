using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
    public class Multimedia
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int CategoryiD { get; set; }
        public string Atachments { get; set; }
        public string AtachmentType { get; set; }
        public string FileData { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
