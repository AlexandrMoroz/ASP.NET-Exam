using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication2.Models
{
    public class UserSerial
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int SerialId { get; set; }

        public Serial Serial { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}