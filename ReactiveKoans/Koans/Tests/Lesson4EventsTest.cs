using System;
using Koans.Lessons;
using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans.Tests
{
    [TestClass]
    public class Lesson4EventsTest
    {
        

        [TestMethod]
        public void TestAllQuestions()
        {
                 Verify(l => l.TheMainEvent(), "BAR");
        }


        public void Verify(Action<Lesson4Events> test, object answer)
        {
            KoanUtils.AssertLesson<Lesson4Events>(test, l => l.___ = answer);
        }
    }
}