using System;
using System.Collections.Generic;
using System.Text;

namespace WebSave.Model
{
    public class File
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string Url { get; set; }//在服务器中的地址

        public int FileTypeId { get; set; }//外键，表示当前文件属于哪个文件类型

        public FileType FileType { get; set; }
    }
}
