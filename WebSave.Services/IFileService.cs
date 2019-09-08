using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSave.Model;

namespace WebSave.Services
{
    public interface IFileService
    {
        Task<List<File>> GetAllAsync();

        Task<File> GetByIdAsync(int id);

        Task<File> AddAsync(File model);

        Task UpdateAsync(File model);

        Task DeleteAsync(File model);
    }
}
