using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WebSave.Model;
using WebSave.Services;

namespace WebSave.Controllers
{
    public class FileTypeController : Controller
    {
        private readonly IFileTypeService _iFileTypeService;
        private readonly UserManager<User> _userManager;

        public FileTypeController(IFileTypeService iFileTypeService,UserManager<User> userManager)
        {
            _iFileTypeService = iFileTypeService;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var fileTypes = await _iFileTypeService.GetAllByUserIdAsync(user.Id);
            return View(fileTypes);
        }

    }
}
