using System;
using System.Concurrency;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans.Lessons
{
    [TestClass]
    public class Lesson3Time
    {
        /*
         * How to Run: Press Ctrl+R,T (go ahead, try it now)
         * Step 1: find the 1st method that fails
         * Step 2: Fill in the blank ____ to make it pass
         * Step 3: run it again
         * Note: Do not change anything other than the blank
         */


        [TestMethod]
        [Timeout(2000)]
        public void Wait1Second()
        {
            string received = "";
            TimeSpan time = TimeSpan.FromSeconds(___);
            Scheduler.Immediate.Schedule(() => received = "Finished", time);
            Assert.AreEqual("Finished", received);
        }

        [TestMethod]
        [Timeout(2000)]
        public void WaitingForGodot()
        {
            string received = "";
            var time = TimeSpan.FromSeconds(___);
            Observable.Return("Godot").Delay(time).Run(x => received = x);
            Assert.AreEqual("Godot", received);
        }

        [TestMethod]
        public void AWatchedPot()
        {
            string received = "";
            var time = TimeSpan.FromSeconds(___);
            var quick = TimeSpan.FromSeconds(2);
            var tepid = Observable.Return("tepid");
            Observable.Return("Boiling").Delay(time).Timeout(quick, tepid).Run(x => received = x);
            Assert.AreEqual("Boiling", received);
        }

         #region Ignore
        public int ___ = 100;
        #endregion
    }
}