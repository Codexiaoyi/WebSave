using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WebSave.Model;
using WebSave.Models;
using WebSave.Services;

namespace WebSave.Controllers
{
    public class FileTypeController : Controller
    {
        private readonly IFileTypeService _iFileTypeService;
        private readonly UserManager<User> _userManager;

        public FileTypeController(IFileTypeService iFileTypeService, UserManager<User> userManager)
        {
            _iFileTypeService = iFileTypeService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var fileTypes = await _iFileTypeService.GetAllByUserIdAsync(user.Id);
            return View(fileTypes);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddViewModel addViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addViewModel);
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var fileType = new FileType()
            {
                TypeName = addViewModel.TypeName,
                UserId = user.Id
            };
            await _iFileTypeService.AddAsync(fileType);
            return RedirectToAction("Index", "FileType");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var fileType = await _iFileTypeService.GetByIdAsync(id);
            await _iFileTypeService.DeleteAsync(fileType);
            return RedirectToAction("Index", "FileType");
        }
    }
}
