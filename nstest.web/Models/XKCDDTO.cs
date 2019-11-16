using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nstest.web.Models
{
    public class XKCDDTO
    {
        public string month { get; set; }
        public int num { get; set; }
        public string link { get; set; }
        public string year { get; set; }
        public string news { get; set; }
        public string safe_title { get; set; }
        public string transcript { get; set; }
        public string alt { get; set; }
        public string img { get; set; }
        public string title { get; set; }
        public string day { get; set; }
        public int PreviousComicId { get; set; }
        public int CurrentComicId { get; set; }
        public int NextComicId { get; set; }
        public bool Unavailable { get; set; }
    }
}
