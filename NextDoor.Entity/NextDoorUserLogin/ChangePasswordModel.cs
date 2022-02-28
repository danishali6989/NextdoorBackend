using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NextDoor.Models.NextDoorUserLogin
{
    public class ChangePasswordModel
    {
       
        public string oldPassword { get; set; }

        public string NewPassword { get; set; }

        public int Userid{ get; set; }
    }
}
