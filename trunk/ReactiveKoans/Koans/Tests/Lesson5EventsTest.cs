using System;
using Koans.Lessons;
using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans.Tests
{
    [TestClass]
    public class Lesson5EventsTest
    {
        

        [TestMethod]
        public void TestAllQuestions()
        {
                 Verify(l => l.TheMainEvent(), "BAR");
        }


        public void Verify(Action<Lesson5Events> test, object answer)
        {
            KoanUtils.AssertLesson<Lesson5Events>(test, l => l.___ = answer);
        }
    }
}