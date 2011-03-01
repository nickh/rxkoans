using System;
using Koans.Lessons;
using Koans.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class Lesson1RxTest
    {
        [TestMethod]
        public void TestTypeOfQuestions()
        {
          //  KoanUtils.AssertTypeOf<>(l => l.WhichTypeIs8(), typeof (int));
        }


        [TestMethod]
        public void TestAllQuestions()
        {
            Verify(l => l.SimpleSubscription(), 42);
            Verify(l => l.SimpleReturn(), "Foo");
            Verify(l => l.TheLastEvent(), "Bar");
            Verify(l => l.EveryThingCounts(), 7);
            KoanUtils.AssertLesson<Lesson1Rx>(l => l.ComposableAddition(), l => l.____ = 1000);
            KoanUtils.AssertLesson<Lesson1Rx>(l => l.ComposableFilters(), l => l.____ = 8);
            KoanUtils.AssertLesson<Lesson1Rx>(l => l.WeWroteThis(), l => l.____ = 5);
            KoanUtils.AssertLesson<Lesson1Rx>(l => l.ConvertingEvents(), l => StringUtils.call= s=>s.ToLower());
            Verify(l => l.CheckingEverything(), true);
        }


        public void Verify(Action<Lesson1Rx> test, object answer)
        {
            KoanUtils.AssertLesson<Lesson1Rx>(test, l => l.___ = answer);
        }
    }
}