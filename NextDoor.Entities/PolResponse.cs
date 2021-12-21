using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
    public class PolResponse
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Poll_Id { get; set; }
        public string OptionName  { get; set; }
        public int? Count { get; set; }
        public int? TotalCount { get; set; }
        public double? PercentageCount { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
