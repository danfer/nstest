using nstest.model.Concrete;
using nstest.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nstest.web.ViewModels
{
    public class ComicViewModel
    {
        public XKCDDTO Comic { get; set; }
        public async Task<ComicViewModel> GetComic(int id, int currentId)
        {
            try
            {
                var viewModel = new ComicViewModel();
                
                var raw = await XKCD.GetComic(id);

                if (raw == null)
                {
                    viewModel.Comic = new XKCDDTO { NextComicId = 0 };
                    return viewModel;
                }
              
                var previousComicId = 0;
                var nextComicId = id + 1;
                if (raw.num > 0)
                    previousComicId = raw.num - 1;
               
                viewModel.Comic = new XKCDDTO
                {
                    title = raw.title,
                    link = raw.link,
                    img = raw.img,
                    PreviousComicId = previousComicId,
                    NextComicId = nextComicId,
                    CurrentComicId = currentId
                };

                return viewModel;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
