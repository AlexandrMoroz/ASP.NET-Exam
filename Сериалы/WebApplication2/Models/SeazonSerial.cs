using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class SerialSeazon
    {
 
        [Key, ForeignKey("Serias")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        

        public Nullable<int> SeazonId { get; set; }
        public Nullable<int> SerialId { get; set; }

        public virtual ICollection<Seria> Serias { get; set; }
        public virtual Serial Serial { get; set; }
        public virtual Seazon Seazon { get; set; }

       
    }
}