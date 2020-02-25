using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PKDSS.Web.Models
{
    public class OutputData
    {
        public bool IsSucceed { set; get; }
        public object Data { set; get; }
        public string ErrorMessage { set; get; }
    }
}
