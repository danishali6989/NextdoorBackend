using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Dtos.Post
{
    public  class PostMultimediaDetailDto
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Postid { get; set; }
        public int Category_id { get; set; }
        public string Attachment { get; set; }
        public string AttachmentType { get; set; }


        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
      //  public List<PostMultimedia> multimedia { get; set; }
    }
}
