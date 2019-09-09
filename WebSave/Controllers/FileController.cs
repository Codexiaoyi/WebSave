using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebSave.Services;

namespace WebSave.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(int id)
        {
            var files = await _fileService.GetAllByFileTypeIdAsync(id);
            return View(files);
        }

    }
}
