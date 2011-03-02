using System;
using Koans.Lessons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans.Tests
{
    [TestClass]
    public class Lesson3TimeTest
    {
        [TestMethod]
        [Timeout(2000)]
        public void TestAllQuestions()
        {
            Verify(l => l.Wait1Second(), 0);
            Verify(l => l.WaitingForGodot(), 0);
            Verify(l => l.AWatchedPot(), 0);
        }


        public void Verify(Action<Lesson3Time> test, int answer)
        {
            KoanUtils.AssertLesson(test, l => l.___ = answer, testFailure: false);
        }
    }
}