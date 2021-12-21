using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NextDoor.Models.NextDoorUserLogin
{
    public class ChangePasswordModel
    {
       
        public string oldPassword { get; set; }

        /*[Required]
        [MinLength(6)]
        [MaxLength(50)]*/
        public string NewPassword { get; set; }

        public int Userid{ get; set; }
    }
}
