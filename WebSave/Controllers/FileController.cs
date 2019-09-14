using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using WebSave.Models.FileViewModel;
using WebSave.Services;
using File = WebSave.Model.File;
using System.Text;

namespace WebSave.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IHostingEnvironment _e;

        public FileController(IFileService fileService, IHostingEnvironment e)
        {
            _fileService = fileService;
            _e = e;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(int id)
        {
            ViewData["FileTypeId"] = id;
            var files = await _fileService.GetAllByFileTypeIdAsync(id);
            return View(files);
        }

        [Authorize]
        public IActionResult Add(int id)
        {
            ViewData["FileTypeId"] = id;
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddViewModel addViewModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(addViewModel);
            }

            Stream htmlstream = await HtmlHelper.GetHtmlAsStream(addViewModel.HttpUrl);//爬取html文件流

            var filename = Path.Combine(_e.WebRootPath, addViewModel.FileName);//保存到本地
            using (var stream = new FileStream(filename, FileMode.Create))
            {
                await htmlstream.CopyToAsync(stream);
                var file = new File()
                {
                    FileName = addViewModel.FileName,
                    Url = addViewModel.FileName,
                    FileTypeId = id
                };
                var result = await _fileService.AddAsync(file);
                if (result > 0)//说明添加成功
                {
                    return RedirectToAction(nameof(Index), "FileType");
                }
            }

            return View(addViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Detail(int fileId)
        {
            string sourceCode;
            var file = await _fileService.GetByIdAsync(fileId);
            var filename = Path.Combine(_e.WebRootPath, file.Url);//保存到本地
            using (var stream = new FileStream(filename, FileMode.Open))
            {
                StreamReader readStream = new StreamReader(stream, Encoding.UTF8);
                sourceCode = await readStream.ReadToEndAsync();
            }
            ViewData["SourceCode"] = sourceCode;
            return View();
        }
    }
}
