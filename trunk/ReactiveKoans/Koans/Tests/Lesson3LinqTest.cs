using System;
using Koans.Lessons;
using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans.Tests
{
    [TestClass]
    public class Lesson3LinqTest
    {
        

        [TestMethod]
        public void TestAllQuestions()
        {
                 Verify(l => l.Linq(), 11);
        }


        public void Verify(Action<Lesson3Linq> test, int answer)
        {
            KoanUtils.AssertLesson<Lesson3Linq>(test, l => l.____ = answer);
        }
    }
}