using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.Post
{
    public class AddVechileModel
    {
        public int id { get; set; }
        public int User_id { get; set; }
        public int P_id { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public string RegNo { get; set; }
        public string Other_Details { get; set; }
    }
}
