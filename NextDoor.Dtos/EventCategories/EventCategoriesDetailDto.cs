using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Dtos.EventCategories
{
    public class EventCategoriesDetailDto
    {
        public int Id { get; set; }
        public string EventCategoryName { get; set; }
        public Constants.RecordStatus Status { get; set; }
    }
}
