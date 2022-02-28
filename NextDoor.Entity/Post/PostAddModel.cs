using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.Post
{
    public class PostAddModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int Listing_CategoryId { get; set; }
        public double Price { get; set; } 
        public double free { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public double Lan { get; set; }
        public double Lat { get; set; }
        public string TimeStamp { get; set; }

        public List<string> image { get; set; }
        public List<string> video { get; set; }
        public List<string> document { get; set; }
        public string FileUrl { get; set; }
    
        public string MediaType { get; set; }
        public string FileData { get; set; }
    }
}
