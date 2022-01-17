using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.NextDoorUser
{
   public  class AddNextDoorUserModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Usr_FName { get; set; }
        public string Usr_LName { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postalcode { get; set; }
        public string StreetAdress { get; set; }
        public int ApartmentNo { get; set; }
        public string Email { get; set; }
        public double Lan { get; set; }
        public double Lat { get; set; }
        public string UserTimeStamp { get; set; }

    }
}
