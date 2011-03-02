using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Koans.Lessons
{
    [TestClass]
    public class Lesson1ObservableStreams
    {
        /*
         * How to Run: Press Ctrl+R,T (go ahead, try it now)
         * Step 1: find the 1st method that fails
         * Step 2: Fill in the blank ____ to make it pass
         * Step 3: run it again
         * Note: Do not change anything other than the blank
         */
        [TestMethod]
        public void SimpleSubscription()
        {
            Observable.Return(42).Subscribe(x => Assert.AreEqual(___, x));
        }

        [TestMethod]
        public void SimpleReturn()
        {
            string received = "";
            Observable.Return("Foo").Subscribe(x => received = x);
            Assert.AreEqual(___, received);
        }

        [TestMethod]
        public void TheLastEvent()
        {
            string received = "";
            var names = new[] { "Foo", "Bar" };
            names.ToObservable().Subscribe(x => received = x);
            Assert.AreEqual(___, received);
        }

        [TestMethod]
        public void EveryThingCounts()
        {
            int received = 0;
            var names = new[] { 3, 4 };
            names.ToObservable().Subscribe(x => received += x);
            Assert.AreEqual(___, received);
        }
             #region Ignore

        public object ___ = "Please Fill in the blank";

        #endregion
    }
}