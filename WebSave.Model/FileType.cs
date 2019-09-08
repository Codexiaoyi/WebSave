using System;
using System.Collections.Generic;
using System.Text;

namespace WebSave.Model
{
    public class FileType
    {
        public FileType()
        {
            Files = new List<File>();
        }

        public int Id { get; set; }

        public string TypeName { get; set; }

        public string UserId { get; set; }//User的ID是GUID，字符串形式。

        public User User { get; set; }

        public List<File> Files { get; set; }//一种文件类型里面有多个文件
    }
}
