using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Seria
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeriaId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public virtual SerialSeazon SeazonSerial { get; set; }
    }
}