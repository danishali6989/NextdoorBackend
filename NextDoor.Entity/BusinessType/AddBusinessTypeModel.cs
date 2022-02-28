using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.BusinessType
{
    public class AddBusinessTypeModel
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public int UserId { get; set; }
    }
}
