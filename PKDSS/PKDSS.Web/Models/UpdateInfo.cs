using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PKDSS.Web.Models
{
    public class UpdateInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Version { get; set; }
        public string Description { get; set; }
        public string UrlFirmware { get; set; }
    }
}
