using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Koans.Utils;


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
            var numbers = new[] { 3, 4 };
            numbers.ToObservable().Subscribe(x => received += x);
            Assert.AreEqual(___, received);
        }
        [TestMethod]
        public void DoingInTheMiddle()
        {
            var status = new List<String>();
            var daysTillTest = Range.Create(4, 1).ToObservable();
            daysTillTest.Do(d => status.Add(d + "=" + (d == 1 ? "Study Like Mad" : ___))).Subscribe();
            Assert.AreEqual("[4=Party, 3=Party, 2=Party, 1=Study Like Mad]", status.AsString());
        }
        [TestMethod]
        public void NothingListensUntilYouSubscribe()
        {
            int sum = 0;
            var numbers = Range.Create(1,10).ToObservable();
            var observable = numbers.Do(n =>sum += n);
            Assert.AreEqual(0, sum);
            observable.___();
            Assert.AreEqual(10*11/2,sum);
        }
             #region Ignore

        public object ___ = "Please Fill in the blank";

        #endregion
    }
}