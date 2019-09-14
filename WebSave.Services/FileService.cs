using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebSave.Data;
using WebSave.Model;

namespace WebSave.Services
{
    public class FileService : IFileService
    {
        private readonly MyContext _context;

        public FileService(MyContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(File model)
        {
            _context.Files.Add(model);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task DeleteAsync(File model)
        {
            _context.Files.Remove(model);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 获取所有文件
        /// </summary>
        /// <returns></returns>
        public async Task<List<File>> GetAllByFileTypeIdAsync(int id)
        {
            return await _context.Files.Where(x => x.FileTypeId == id).ToListAsync();
        }

        /// <summary>
        /// 根据Id获取文件信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<File> GetByIdAsync(int id)
        {
            return _context.Files.FindAsync(id);
        }

        /// <summary>
        /// 更新文件信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateAsync(File model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
