using System;
using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrentLesson = Koans.Lessons.Lesson4Time;

namespace Koans.Tests
{
	[TestClass]
	public class Lesson4TimeTest
	{
		[TestMethod]
		
		public void TestAllQuestions()
		{
			Verify(l => l.LaunchingAnActionInTheFuture(), 0);
			Verify(l => l.LaunchingAnEventInTheFuture(), 0);
			Verify(l => l.YouCanPlaceATimelimitOnHowLongAnEventShouldTake(), 2100);
		}


		public void Verify(Action<CurrentLesson> test, int answer)
		{
			KoanUtils.AssertLesson(test, l => l.___ = answer, testFailure: false);
		}
	}
}