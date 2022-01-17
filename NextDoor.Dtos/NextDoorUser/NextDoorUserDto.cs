using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;


namespace UserManagement.Dtos.NextDoorUser
{
    public  class NextDoorUserDto
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string FAPronounce { get; set; }
        public string TimeStamp { get; set; }

        public string PostalCode { get; set; }
       
        public string StreetAdress { get; set; }
        public int ApartmentNo { get; set; }
        public string Email { get; set; }
        public double Lan { get; set; }
        public double Lat { get; set; }
        public Constants.RecordStatus Status { get; set; }
    }
}
