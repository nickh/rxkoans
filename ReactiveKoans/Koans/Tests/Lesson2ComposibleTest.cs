using System;
using Koans.Lessons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans.Tests
{
    [TestClass]
    public class Lesson2ComposibleTest
    {
        [TestMethod]
        public void TestAllQuestions()
        {

            Verify(l => l.ComposableAddition(), 1000);
            Verify(l => l.ComposableFilters(), 8);
            Verify(l => l.WeWroteThis(), 5);
            KoanUtils.AssertLesson<Lesson2ComposableObservations>(l => l.ConvertingEvents(), l => StringUtils.call = s => s.ToLower());
            KoanUtils.AssertLesson((Action<Lesson2ComposableObservations>) (l => l.CheckingEverything()), l1 => l1.____ = true);
        }


        public void Verify(Action<Lesson2ComposableObservations> test, int answer)
        {
            KoanUtils.AssertLesson(test, l => l.___ = answer);
        }
    }
}