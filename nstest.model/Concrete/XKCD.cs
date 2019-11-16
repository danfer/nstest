using Newtonsoft.Json;
using nstest.model.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace nstest.model.Concrete
{
    public class XKCD
    {
        public static async Task<XKCDModel> GetMostRecentComic()
        {
            var url = "https://xkcd.com/info.0.json";

            return await GetComicData(url);
        }

        public static async Task<XKCDModel> GetComic(int id)
        {
            var url = $"https://xkcd.com/{id}/info.0.json";

            return await GetComicData(url);            
        }

        private static async Task<XKCDModel> GetComicData(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(url))
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return JsonConvert.DeserializeObject<XKCDModel>(data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
