

using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Dtos.Categories
{
    public class CategoriesDetailDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public Constants.RecordStatus Status { get; set; }
    }
}
