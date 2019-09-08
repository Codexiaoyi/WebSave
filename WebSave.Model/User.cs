using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace WebSave.Model
{
    public class User : IdentityUser
    {
        public User()
        {
            FileTypes = new List<FileType>();//一个人有多种文件类型
        }

        public List<FileType> FileTypes { get; set; }
    }
}
