﻿using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
   public class Location
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public int NeighbourhoodId { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
