using System;
using Koans.Lessons;
using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans.Tests
{
	[TestClass]
	public class Lesson7AsyncInvokeTest
	{
		[TestMethod]
		public void TestAllQuestions()
		{
			KoanUtils.AssertLesson<Lesson7AsyncInvoke>(l => l.TheBloodyHardAsyncInvokationPatter(), l =>
			                                                                                        	{
			                                                                                        		l.____ = "C";
			                                                                                        		l._____ = "A";
			                                                                                        		l.______ = "B";
			                                                                                        	});
			Verify(l => l.NiceAndEasyFromAsyncPattern(), 48);
			// Note: I don't know how to properly test AsynchronousRuntimeIsNotSummed
			Verify(l => l.TimeoutMeansStopListeningDoesNotMeanAbort(), "Give me 5, Joe");
			Verify(l => l.AsynchronousObjectsAreProperlyDisposed(), "D");
		}


		public void Verify(Action<Lesson7AsyncInvoke> test, object answer)
		{
			KoanUtils.AssertLesson(test, l => FillAll(l, answer));
		}

		private void FillAll(Lesson7AsyncInvoke l, object answer)
		{
			if (answer is string)
			{
				l.____ = (string) answer;
			}
			if (answer is int)
			{
				l.___ = (int) answer;
			}
		}
	}
}