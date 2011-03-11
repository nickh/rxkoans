using System;
using System.Collections.Generic;
using System.Concurrency;
using System.Linq;
using System.Threading;
using Koans.Utils;
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
		public void WhatGoesInComesOut()
		{
			Observable.Return(___).Subscribe(x => Assert.AreEqual(101, x));
		}

		[TestMethod]
		public void SimpleReturn()
		{
			var received = "";
			Observable.Return("Foo").Subscribe((string s) => received = s);
			Assert.AreEqual(___, received);
		}

		[TestMethod]
		public void TheLastEvent()
		{
			var received = "";
			var names = new[] {"Foo", "Bar"};
			names.ToObservable().Subscribe((s) => received = s);
			Assert.AreEqual(___, received);
		}

		[TestMethod]
		public void EveryThingCounts()
		{
			var received = 0;
			var numbers = new[] {3, 4};
			numbers.ToObservable().Subscribe((int x) => received += x);
			Assert.AreEqual(___, received);
		}

		[TestMethod]
		public void AllEventsWillBeRecieved()
		{
			var received = "Working ";
			var numbers = Range.Create(9, 5);
			numbers.ToObservable().Subscribe((int x) => received += x);
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
			var sum = 0;
			var numbers = Range.Create(1, 10).ToObservable();
			var observable = numbers.Do(n => sum += n);
			Assert.AreEqual(0, sum);
			observable.___();
			Assert.AreEqual(10*11/2, sum);
		}

		[TestMethod]
		public void UnsubscribeAtAnyTime()
		{
			var received = "";
			var numbers = Range.Create(1, 9);
			IDisposable un = null;
			un = numbers.ToObservable(Scheduler.NewThread).Subscribe((int x) =>
			                                                         	{
			                                                         		received += x;
			                                                         		if (x == 5)
			                                                         		{
			                                                         			un.___();
			                                                         		}
			                                                         	});
			Thread.Sleep(100);
			Assert.AreEqual("12345", received);
		}

		#region Ignore

		public object ___ = "Please Fill in the blank";

		#endregion
	}
}