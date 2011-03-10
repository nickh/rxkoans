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
			Verify(l => l.Wait1Second(), 0);
			Verify(l => l.WaitingForGodot(), 0);
			Verify(l => l.AWatchedPot(), 0);
		}


		public void Verify(Action<CurrentLesson> test, int answer)
		{
			KoanUtils.AssertLesson(test, l => l.___ = answer, testFailure: false);
		}
	}
}