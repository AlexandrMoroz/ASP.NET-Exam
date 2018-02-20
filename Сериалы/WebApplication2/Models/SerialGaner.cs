using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class SerialGaner
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SerialId { get; set; }
        public int GanerId { get; set; }

        public virtual Serial Serial { get; set; }
        public virtual Ganer Ganer { get; set; }
    }
}