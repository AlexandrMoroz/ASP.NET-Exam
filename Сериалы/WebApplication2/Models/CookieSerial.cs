using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class CookieSerial
    {
        public int Id { get; set; }
        public int CookieId { get; set; }
        public int SerialId { get; set; }
        
        public virtual Cookie Cookie { get; set; }
        public virtual Serial Serial { get; set; }
    }
}