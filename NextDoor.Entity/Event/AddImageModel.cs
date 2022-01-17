using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.Event
{
    public class AddImageModel
    {
        public int id { get; set; }
        public string image { get; set; }
        public string FileUrl { get; set; }
        public string MediaType { get; set; }
        public string FileData { get; set; }
       
    }
}
