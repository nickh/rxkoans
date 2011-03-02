using System;
using Koans.Lessons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans.Tests
{
    [TestClass]
    public class Lesson4EventsTest
    {
        

        [TestMethod]
        [Timeout(2000)]
        public void TestAllQuestions()
        {
                 Verify(l => l.TheMainEvent(), "[B, A, R]");
        }


        public void Verify(Action<Lesson4Events> test, object answer)
        {
            KoanUtils.AssertLesson<Lesson4Events>(test, l => l.___ = answer);
        }
    }
}