using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public int U_Id { get; set; }
        public int P_Id { get; set; }

        public string Hair { get; set; }
        public string Top { get; set; }
        public string Bottom { get; set; }
        public string Shoes { get; set; }
        public string Age { get; set; }
        public string Build { get; set; }
        public string Ethinicity { get; set; }
        public string Sex { get; set; }
        public string OtherDetails { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
