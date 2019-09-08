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
    public class FileTypeService : IFileTypeService
    {
        private readonly MyContext _context;

        public FileTypeService(MyContext context)
        {
            _context = context;
        }

        public async Task<FileType> AddAsync(FileType model)
        {
            _context.FileTypes.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task DeleteAsync(FileType model)
        {
            _context.FileTypes.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FileType>> GetAllByUserIdAsync(string id)
        {
            return await _context.FileTypes.Where(x=>x.UserId == id).ToListAsync();
        }

        public Task<FileType> GetByIdAsync(int id)
        {
            return _context.FileTypes.FindAsync(id);
        }

        public async Task UpdateAsync(FileType model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
