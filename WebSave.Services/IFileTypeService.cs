using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSave.Model;

namespace WebSave.Services
{
    public interface IFileTypeService
    {
        /// <summary>
        /// 获取所有文件类型
        /// </summary>
        /// <returns></returns>
        Task<List<FileType>> GetAllByUserIdAsync(string id);

        /// <summary>
        /// 根据Id获取文件类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<FileType> GetByIdAsync(int id);

        /// <summary>
        /// 添加文件类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<FileType> AddAsync(FileType model);

        /// <summary>
        /// 更新文件类型信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateAsync(FileType model);

        /// <summary>
        /// 删除文件类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task DeleteAsync(FileType model);
    }
}
