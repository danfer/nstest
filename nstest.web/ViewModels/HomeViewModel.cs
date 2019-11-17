using nstest.model.Concrete;
using nstest.web.Models;
using System;
using System.Threading.Tasks;

namespace nstest.web.ViewModels
{
    public class HomeViewModel : XKCDDTO
    {
        public int PreviousComicId { get; set; }
        public int CurrentComicId { get; set; }
        public int NextComicId { get; set; }
        public async Task<HomeViewModel> GetMostRecentComic()
        {
            try
            {
                var raw = await XKCD.GetMostRecentComic();

                var viewModel = new HomeViewModel();

                var previousComicId = 0;

                if (raw.num > 0)
                    previousComicId = raw.num - 1;

                viewModel.PreviousComicId = previousComicId;
                viewModel.CurrentComicId = raw.num;

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
