﻿using Koans.Lessons;
using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrentLesson = Koans.Lessons.Lesson7AsyncInvoke;

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
			KoanUtils.Verify<CurrentLesson>(l => l.NiceAndEasyFromAsyncPattern(), 48);
			// Note: I don't know how to properly test AsynchronousRuntimeIsNotSummed
			KoanUtils.Verify<CurrentLesson>(l => l.TimeoutMeansStopListeningDoesNotMeanAbort(), "Give me 5, Joe");
			KoanUtils.Verify<CurrentLesson>(l => l.AsynchronousObjectsAreProperlyDisposed(), "D");
		}
		
	}
}