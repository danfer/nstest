using nstest.model.Concrete;
using nstest.web.Models;
using System;
using System.Threading.Tasks;

namespace nstest.web.ViewModels
{
    public class HomeViewModel
    {
        public XKCDDTO Comic { get; set; }
        public async Task<HomeViewModel> GetMostRecentComic()
        {
            try
            {
                var raw =  await XKCD.GetMostRecentComic();

                var viewModel = new HomeViewModel();

                var previousComicId = 0;
                
                if (raw.num > 0)
                    previousComicId = raw.num - 1;

                viewModel.Comic = new XKCDDTO 
                { 
                    title = raw.title,
                    link = raw.link,
                    img = raw.img,
                    PreviousComicId = previousComicId,
                    CurrentComicId = raw.num
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
