using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSave.Models
{
    public class AddViewModel
    {
        public string TypeName { get; set; }
        public string UserId { get; set; }//User的ID是GUID，字符串形式。
    }
}
