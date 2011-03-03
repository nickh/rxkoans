using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans.Utils
{
    public class KoanUtils
    {
        public static void AssertTypeOf<T>(Action<T> test, Type expected) where T : new()
        {
            var lesson = new T();
            string s = "Didn't Fail";
            try
            {
                test(lesson);

            }
            catch (Exception e)
            {
                s = e.Message;
            }
            var expectedMessage =
                String.Format(
                    "Assert.IsInstanceOfType failed.  Expected type:<System.String>. Actual type:<{0}>.",
                    expected);
            Assert.AreEqual(s,expectedMessage);


        }

        public static void AssertLesson<T>(Action<T> test, Action<T> answer) where T : new()
        {
            AssertLesson(test, answer,testFailure: true);
        }

        public static void AssertLesson<T>(Action<T> test, Action<T> answer, bool testFailure) where T : new()
        {
            var l =  new T();
            if (testFailure)
            {
                VerifyFailure(test, l);
            }
            answer(l);
            test(l);
            StringUtils.Reset();
        }

        private static void VerifyFailure<T>(Action<T> test, T l)
        {
            var failed = false;
            try
            {
                test(l);
            }
            catch (Exception)
            {
                failed = true;
            }
            Assert.IsTrue(failed);
        }
    }
}