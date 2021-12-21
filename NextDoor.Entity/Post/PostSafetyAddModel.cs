using NextDoor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.Post
{
    public class PostSafetyAddModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string SafetyDescription { get; set; }
        public string SafetyPersonDescription { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public double Lan { get; set; }
        public double Lat { get; set; }
        public List<string> image { get; set; }
        public List<string> video { get; set; }
        public List<string> oldImage { get; set; }
        public List<string> oldVideo { get; set; }
        public string FileUrl { get; set; }
        public string MediaType { get; set; }
        public List<AddPersonModel> Person { get; set; }
        public List<AddVechileModel> Vechile { get; set; }
    }
}
