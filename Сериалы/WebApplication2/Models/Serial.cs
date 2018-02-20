using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Serial
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SerialId { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public string Name { get; set; }
        public string EnglishName { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Coments { get; set; }
        //[Range(1900,2020, ErrorMessage ="Set Year between 1900 and 2020")]
        public string YearsOfEdition { get; set; }
        [Required]
        public string Time { get; set; }
        public int DirectorId { get; set; }
        public int StudioId { get; set; }
        public int Rate { get; set; }

        public virtual ICollection<SerialGaner> SerialGaners { get; set; }
        public virtual ICollection<SerialSeazon> SerialSeazons { get; set; }
        public virtual ICollection<CookieSerial> SerialCookies { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<UserSerial> UserSerials { get; set; }
        public virtual Director Director { get; set; }
        public virtual Studio Studio { get; set; }
    }
}