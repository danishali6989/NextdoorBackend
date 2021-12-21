using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
    public class VechileSafety
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Post_Id { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public string RegNo { get; set; }
        public string Other_Details { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
