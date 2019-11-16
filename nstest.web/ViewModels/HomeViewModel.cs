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

                viewModel.Comic = new XKCDDTO 
                { 
                    title = raw.title,
                    link = raw.link,
                    img = raw.img
                };

                return viewModel;
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }
    }
}
