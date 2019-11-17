using Microsoft.VisualStudio.TestTools.UnitTesting;
using nstest.model.Concrete;

namespace nstest.test
{
    [TestClass]
    public class XKCDUnitTest
    {
        [TestMethod]
        public void GetCurrentComicTest()
        {
            var xkcdCurrentComic = XKCD.GetMostRecentComic();

            Assert.IsNotNull(xkcdCurrentComic);
        }

        [TestMethod]
        public void GetComic()
        {
            var comicId = 403;

            var xkcdComic = XKCD.GetComic(comicId);

            Assert.IsNotNull(xkcdComic);
        }
    }
}
