using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
    public class ImageCollection
    {
        public int Id { get; set; }
       
        public string Atachments { get; set; }
        public string AtachmentType { get; set; }
        public DateTime CreatedOn { get; set; }
        public Constants.RecordStatus Status { get; set; }
    }
}
