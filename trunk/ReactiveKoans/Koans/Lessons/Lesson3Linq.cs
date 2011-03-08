using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans.Lessons
{
    [TestClass]
    public class Lesson3Linq
    {
        /*
         * How to Run: Press Ctrl+R,T (go ahead, try it now)
         * Step 1: find the 1st method that fails
         * Step 2: Fill in the blank ____ to make it pass
         * Step 3: run it again
         * Note: Do not change anything other than the blank
         */
        [TestMethod]
        public void Linq()
        {
            var numbers = Observable.Range(1, 100);
            var results = from x in numbers
                          where x % ____ == 0
                          select x.ToString();
            var strings = results.ToEnumerable();
            Assert.AreEqual("11,22,33,44,55,66,77,88,99", String.Join(",", strings));
        }

        #region Ignore

        public int ____ = 1;
        #endregion
    }
}