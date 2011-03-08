using System;
using System.Collections.Generic;
using System.Concurrency;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans.Lessons
{
    [TestClass]
    public class Lesson3Linq
    {
        [TestMethod]
        public void Linq()
        {
            var numbers = Observable.Range(1, 100);
            var results = from x in numbers
                          where x%11 == 0
                          select x.ToString();
            var strings = results.ToEnumerable();
            Assert.AreEqual("11,22,33,44,55,66,77,88,99", String.Join(",",strings));
        }


        #region Ignore

        public const int ____ = 1000;
        public object ___ = "Please Fill in the blank";


        #endregion

      
    }

}