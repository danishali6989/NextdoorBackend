using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
    public class CheckUserVote
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Poll_Id { get; set; }
        public int Response_Id { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
