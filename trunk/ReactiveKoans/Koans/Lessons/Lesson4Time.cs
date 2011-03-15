using System;
using System.Concurrency;
using System.Linq;
using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans.Lessons
{
    [TestClass]
    public class Lesson4Time
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
        public void LaunchingAnActionInTheFuture()
        {
            string received = "";
            TimeSpan delay = TimeSpan.FromSeconds(___);
            Scheduler.Immediate.Schedule(() => received = "Finished", delay);
            Assert.AreEqual("Finished", received);
        }

        [TestMethod]
        [Timeout(2000)]
        public void LaunchingAnEventInTheFuture()
        {
            string received = "";
            var time = TimeSpan.FromSeconds(___);
            Observable.Return("Godot", Scheduler.Immediate).Delay(time).Run(x => received = x);
            Assert.AreEqual("Godot", received);
        }

        [TestMethod]
        public void AWatchedPot()
        {
            string received = "";
            var delay = TimeSpan.FromSeconds(___);
            var timeout = TimeSpan.FromSeconds(2);
            var timeoutEvent = Observable.Return("Tepid");
            Observable.Return("Boiling").Delay(delay).Timeout(timeout, timeoutEvent).Run(x => received = x);
            Assert.AreEqual("Boiling", received);
        }

         #region Ignore
        public int ___ = 100;
        #endregion
    }
}