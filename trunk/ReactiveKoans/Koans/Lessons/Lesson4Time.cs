using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
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
			Scheduler.Immediate.Schedule(delay, () => received = "Finished");
			Assert.AreEqual("Finished", received);
		}

		[TestMethod]
		[Timeout(2000)]
		public void LaunchingAnEventInTheFuture()
		{
			string received = null;
            var time = TimeSpan.FromSeconds(___);
			var people = new Subject<string>();
			people.Delay(time).Subscribe(x => received = x);
			people.OnNext("Godot");
			ThreadUtils.WaitUntil(()=> received != null );
			Assert.AreEqual("Godot", received);
		}

		[TestMethod]
		public void YouCanPlaceATimelimitOnHowLongAnEventShouldTake()
		{
			var received = new List<string>();
			var timeout = TimeSpan.FromSeconds(2);
			var timeoutEvent = Observable.Return("Tepid");
			var temperatures  = new Subject<string>();
			temperatures.Timeout(timeout, timeoutEvent).Subscribe(x => received.Add(x));
			temperatures.OnNext("Started");
			Thread.Sleep(___);
			temperatures.OnNext("Boiling");
			ThreadUtils.WaitUntil(() => received != null);
			Assert.AreEqual("Started, Tepid", String.Join(", ", received));
		}

		#region Ignore

		public int ___ = 100;

		#endregion
	}
}