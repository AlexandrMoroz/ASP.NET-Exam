using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Ganer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GanerId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<SerialGaner> SerialGaners { get; set; }
    }
}