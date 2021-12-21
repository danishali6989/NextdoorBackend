using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
//using static NextDoor.Utilities.Constants;

namespace NextDoor.Entities
{
    public class Likes
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Post_id { get; set; }
        public int Event_id { get; set; }
        public int Poll_id { get; set; }
        public int Comment_id { get; set; }
       
        public Constants.ReactionStatus Reaction_Id { get; set; } 
       
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
      
    }
}
