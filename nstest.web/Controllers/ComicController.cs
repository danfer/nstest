using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using nstest.web.ViewModels;

namespace nstest.web.Controllers
{
    public class ComicController : Controller
    {
        [Route("Comic/{id:int}/{currentId:int}")]
        public async Task<IActionResult> Index(int id, int currentId)
        {
            var viewModel = await new ComicViewModel().GetComic(id, currentId);

            if (viewModel.Comic.NextComicId > currentId)
                return RedirectToAction("Index", "Home");

            return View(viewModel);
        }
    }
}