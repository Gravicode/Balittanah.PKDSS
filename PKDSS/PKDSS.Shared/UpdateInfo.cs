using System;
using System.Collections.Generic;
using System.Text;

namespace PKDSS.Shared
{
    public class UpdateInfo
    {

        public int Id { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Version { get; set; }
        public string Description { get; set; }
        public string UrlFirmware { get; set; }
    }
}
