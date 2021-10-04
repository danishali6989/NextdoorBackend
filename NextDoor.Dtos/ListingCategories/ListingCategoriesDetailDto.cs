using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Dtos.ListingCategories
{
    public class ListingCategoriesDetailDto
    {
        public int Id { get; set; }
        public string ListingCategoryName { get; set; }


        public Constants.RecordStatus Status { get; set; }
    }
}
