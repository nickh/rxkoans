using System;
using System.Collections.Generic;
using System.Concurrency;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans.Lessons
{
    [TestClass]
    public class Lesson1Rx
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
            var names = new[] {"Foo", "Bar"};
            names.ToObservable().Subscribe(x => received = x);
            Assert.AreEqual(___, received);
        }

        [TestMethod]
        public void EveryThingCounts()
        {
            int received = 0;
            var names = new[] {3, 4};
            names.ToObservable().Subscribe(x => received += x);
            Assert.AreEqual(___, received);
        }

        [TestMethod]
        public void ComposableAddition()
        {
            int received = 0;
            var numbers = new[] {10, 100, ____};
            numbers.ToObservable().Sum().Subscribe(x => received = x);
            Assert.AreEqual(1110, received);
        }

        [TestMethod]
        public void ComposableFilters()
        {
            var numbers = Observable.Range(1, 10);
            numbers.Where(x => x > ____).Sum().Subscribe(x => Assert.AreEqual(19, x));
        }

        [TestMethod]
        public void WeWroteThis()
        {
            var received = new List<String>();
            var names = new[] {"Bart", "Marge", "Wes", "Linus", "Erik"};
            names.ToObservable().Where(n => n.Length < ____).Subscribe(x => received.Add(x));
            Assert.AreEqual("[Bart, Wes, Erik]", received.AsString());
        }

        [TestMethod]
        public void ConvertingEvents()
        {
            string received = "";
            var names = new[] {"wE", "hOpE", "yOU", "aRe", "eNJoyIng", "tHiS"};
            names.ToObservable().Select(x => x.___()).Subscribe(x => received += x + " ");
            Assert.AreEqual("we hope you are enjoying this ", received);
        }

        [TestMethod]
        public void CheckingEverything()
        {
            bool? received = null;
            var names = new[] {2, 4, 6, 8};
            names.ToObservable().All(x => x.IsEven()).Subscribe(x => received = x);
            Assert.AreEqual(___, received);
        }

        [TestMethod]
        [Timeout(2000)]
        public void Wait1Second()
        {
            string received = "";
            TimeSpan time = TimeSpan.FromSeconds(____);
            Scheduler.Immediate.Schedule(() => received = "Finished", time);
            Assert.AreEqual("Finished", received);
        }

        [TestMethod]
        [Timeout(2000)]
        public void WaitingForGodot()
        {
            string received = "";
            TimeSpan time = TimeSpan.FromSeconds(____);
            Observable.Return("Godot").Delay(time).Run(x => received = x);
            Assert.AreEqual("Godot", received);
        }

        [TestMethod]
        public void AWatchedPot()
        {
            string received = "";
            TimeSpan time = TimeSpan.FromSeconds(____);
            TimeSpan quick = TimeSpan.FromSeconds(2);
            var tepid = Observable.Return("tepid");
            Observable.Return("Boiling").Delay(time).Timeout(quick, tepid).Run(x => received = x);
            Assert.AreEqual("Boiling", received);
        }

        public event EventHandler<TextChangedEventArgs> TextChanged;

        [TestMethod]
        public void TheMainEvent()
        {
            var received = new List<String>();
            var textChanges = Observable.FromEvent<TextChangedEventArgs>(this, "TextChanged");
            using (textChanges.Subscribe(e => received.Add(e.EventArgs.value)))
            {
                TextChanged(null, new TextChangedEventArgs { value = "B" });
                TextChanged(null, new TextChangedEventArgs { value = "A" });
                TextChanged(null, new TextChangedEventArgs { value = "R" });
            }
            TextChanged(null, new TextChangedEventArgs { value = "T" });
            Assert.AreEqual(___, received.AsString());
        }

        #region Ignore

        public object ___ = "Please Fill in the blank";
        public int ____ = 100;

        public Lesson1Rx()
        {
            TextChanged += (o,e) => { };
        }
        #endregion
    }

    public class TextChangedEventArgs : EventArgs
    {
        public string value;
    }
}