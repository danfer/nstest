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
        [Route("comic/{id:int}")]
        public async Task<IActionResult> Index(int id)
        {
            int currentComicId = Convert.ToInt32(TempData["CurrentComicId"]);          

            var viewModel = await new ComicViewModel().GetComic(id, currentComicId);

            TempData["CurrentComicId"] = currentComicId;

            if (viewModel.GoBackToCurrent)
                return RedirectToAction("Index", "Home");
            if (viewModel.Unavailable)
                return RedirectToAction("Index", new { id = id + 1 });

            return View(viewModel);
        }
    }
}