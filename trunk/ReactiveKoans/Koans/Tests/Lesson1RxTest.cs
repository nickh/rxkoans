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
        [Timeout(2000)]
        public void TestAllQuestions()
        {
            Verify(l => l.SimpleSubscription(), 42);
            Verify(l => l.SimpleReturn(), "Foo");
            Verify(l => l.TheLastEvent(), "Bar");
            Verify(l => l.EveryThingCounts(), 7);
            VerifyInt(l => l.ComposableAddition(), 1000);
            VerifyInt(l => l.ComposableFilters(), 8);
            VerifyInt(l => l.WeWroteThis(), 5);
            KoanUtils.AssertLesson<Lesson1Rx>(l => l.ConvertingEvents(), l => StringUtils.call= s=>s.ToLower());
            Verify(l => l.CheckingEverything(), true);
            KoanUtils.AssertLesson<Lesson1Rx>(l => l.Wait1Second(), l1 => l1.____ = 0, testFailure: false);
            KoanUtils.AssertLesson<Lesson1Rx>(l => l.WaitingForGodot(), l1 => l1.____ = 0, testFailure: false);
            KoanUtils.AssertLesson<Lesson1Rx>(l => l.AWatchedPot(), l1 => l1.____ = 0, testFailure: false);
            Verify(l => l.TheMainEvent(), "[B, A, R]");
        }

        private void VerifyInt(Action<Lesson1Rx> action, int answer)
        {
            KoanUtils.AssertLesson<Lesson1Rx>(action, l => l.____ = answer);
        }


        public void Verify(Action<Lesson1Rx> test, object answer)
        {
            KoanUtils.AssertLesson<Lesson1Rx>(test, l => l.___ = answer);
        }
    }
}