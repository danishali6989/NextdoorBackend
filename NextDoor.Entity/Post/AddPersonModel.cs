using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.Post
{
    public class AddPersonModel
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int Pid { get; set; }
        public string Hair { get; set; }
        public string Top { get; set; }
        public string Bottom { get; set; }
        public string Shoes { get; set; }
        public string Age { get; set; }
        public string Build { get; set; }
        public string Ethinicity { get; set; }
        public string Sex { get; set; }
        public string OtherDetails { get; set; }
    }
}
