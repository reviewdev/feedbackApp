using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCOnline.API.Models
{
    public class User_DTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}