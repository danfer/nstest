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
                            var test = JsonConvert.DeserializeObject<XKCDModel>(data);

                            return test;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }
    }
}
