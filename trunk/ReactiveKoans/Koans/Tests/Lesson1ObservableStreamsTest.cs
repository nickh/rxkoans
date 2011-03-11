using System;
using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrentLesson = Koans.Lessons.Lesson1ObservableStreams;

namespace Koans.Tests
{
	[TestClass]
	public class Lesson1ObservableStreamsTest
	{
		[TestMethod]
		public void TestAllQuestions()
		{
			KoanUtils.Verify<CurrentLesson>(l => l.SimpleSubscription(), 42);
			KoanUtils.Verify<CurrentLesson>(l => l.WhatGoesInComesOut(), 101);
			KoanUtils.Verify<CurrentLesson>(l => l.SimpleReturn(), "Foo");
			KoanUtils.Verify<CurrentLesson>(l => l.TheLastEvent(), "Bar");
			KoanUtils.Verify<CurrentLesson>(l => l.EveryThingCounts(), 7);
			KoanUtils.Verify<CurrentLesson>(l => l.AllEventsWillBeRecieved(), "Working 98765");
			KoanUtils.Verify<CurrentLesson>(l => l.DoingInTheMiddle(), "Party");
			KoanUtils.AssertLesson<CurrentLesson>(l => l.NothingListensUntilYouSubscribe(),
			                                      l =>
			                                      StringUtils.call =
			                                      (s, p) => ObservableExtensions.Subscribe((IObservable<int>) s));
			KoanUtils.AssertLesson<CurrentLesson>(l => l.UnsubscribeAtAnyTime(),
			                                      l =>
			                                      StringUtils.call =
			                                      (s, p) =>
			                                      	{
			                                      		((IDisposable) s).Dispose();
			                                      		return 1;
			                                      	});
		}
	}
}