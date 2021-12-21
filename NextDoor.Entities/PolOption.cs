using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
   public  class PolOption
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Poll_id { get; set; }
        public string Option_Name { get; set; }
        public int? Count { get; set; }
        public int? Count_total { get; set; }
        public double? Percentage_Count { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
