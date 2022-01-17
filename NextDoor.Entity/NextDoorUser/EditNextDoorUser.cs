using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.NextDoorUser
{
    public class EditNextDoorUser
    {
       // public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string TimeStamp { get; set; }

        public string FA_Preference { get; set; }
        public string Pronoun { get; set; }
        public string Language { get; set; }
    }
}
