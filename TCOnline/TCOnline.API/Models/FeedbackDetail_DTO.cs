using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCOnline.API.Models
{
    public class FeedbackDetail_DTO
    {
        public int Id { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }
    }
}