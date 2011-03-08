using System;
using Koans.Lessons;
using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans.Tests
{
    [TestClass]
    public class Lesson1ObservableStreamsTest
    {
        [TestMethod]
        public void TestAllQuestions()
        {
            Verify(l => l.SimpleSubscription(), 42);
            Verify(l => l.SimpleReturn(), "Foo");
            Verify(l => l.TheLastEvent(), "Bar");
            Verify(l => l.EveryThingCounts(), 7);
            Verify(l => l.DoingInTheMiddle(), "Party");
            KoanUtils.AssertLesson<Lesson1ObservableStreams>(l => l.NothingListensUntilYouSubscribe(), l => StringUtils.call = (s,p) => ObservableExtensions.Subscribe((IObservable<int>)s));
           
        }


        public void Verify(Action<Lesson1ObservableStreams> test, object answer)
        {
            KoanUtils.AssertLesson(test, l => l.___ = answer);
        }
    }
}