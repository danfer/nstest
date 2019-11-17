using nstest.model.Concrete;
using nstest.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nstest.web.ViewModels
{
    public class ComicViewModel: XKCDDTO
    {
        public int PreviousComicId { get; set; }
        public int CurrentComicId { get; set; }
        public int NextComicId { get; set; }
        public bool Unavailable { get; set; }
        public bool IsTheFirstOne { get; set; }
        public bool GoBackToCurrent { get; set; }
        public async Task<ComicViewModel> GetComic(int id, int currentId)
        {
            try
            {
                var viewModel = new ComicViewModel();

                if (id >= currentId)
                {
                    viewModel.GoBackToCurrent = true;
                    return viewModel;
                }

                var raw = await XKCD.GetComic(id);

                if (raw == null)
                {
                    viewModel.Unavailable = true;
                    return viewModel;
                }
                if (id == 1)
                    viewModel.IsTheFirstOne = true;
              
                viewModel.PreviousComicId = 0;
                viewModel.NextComicId = id + 1;
                if (raw.num > 0)
                    viewModel.PreviousComicId = raw.num - 1;

                viewModel.title = raw.title;
                viewModel.img = raw.img;

                return viewModel;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
